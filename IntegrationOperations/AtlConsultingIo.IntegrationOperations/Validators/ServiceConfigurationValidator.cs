using FluentValidation;
using FluentValidation.Validators;

namespace AtlConsultingIo.IntegrationOperations;
public class IntegrationRequestValidator<T> : AbstractValidator<IntegrationRequest<T>>
    where T : class
{
    public IntegrationRequestValidator()
    {
        RuleFor( x => x.Key.Value ).NotNull().NotEmpty().WithMessage( "IntegrationName must have a value." );
        RuleFor( x => x.ContextID.Value ).NotNull().NotEmpty().WithMessage( "OperationContextID must have a value." );
    }
}
internal class IntegrationServiceConfigurationValidator : AbstractValidator<IntegrationServiceConfiguration>
{
    public IntegrationServiceConfigurationValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor( x => x.Value ).NotNull();
        RuleFor( x => x.Value!.IntegrationOptions ).Must( x => x.HasItems() ).WithMessage( "Integration configurations required to use operations." );
        RuleFor( x => x.Value!.ServiceLoggingOptions ).SetValidator( new LogSettingValidator() );
    }
}
internal class LogSettingValidator : AbstractValidator<IntegrationServiceLogSetting>
{
    public LogSettingValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        When( x => x.StorageLoggingEnabled , () => RuleFor( x => x.Value ).NotNull() );
        When( x => x.Value != null , () =>
        {
            RuleFor( x => x.Value! ).SetValidator( new ServiceLogOptionsValidator() );
        } );
    }

    class ServiceLogOptionsValidator : AbstractValidator<IntegrationServiceLogSetting.Options>
    {
        public ServiceLogOptionsValidator()
        {
            When( x => !x.UseDocumentStorage , () => RuleFor( x => x.UseBlobStorage ).Must( x => x.Equals( true ) ) );
            When( x => !x.UseBlobStorage , () => RuleFor( x => x.UseDocumentStorage ).Must( x => x.Equals( true ) ) );

            RuleFor( x => x.StorageLogResourceName ).SetValidator( new ResourceNameValidator() ).WithMessage( "Invalid StorageLoggingConfiguration detected." );
            RuleFor( x => x.StorageLogConnection.Value ).NotNull().NotEmpty().WithMessage( $"StorageAccountConnection required for operation storage logging." );

        }

        class ResourceNameValidator : PropertyValidator<IntegrationServiceLogSetting.Options , string?>
        {
            public override string Name => "ResourceNameValidator";

            private readonly static ResourceNameValidators.TableNameValidator _tableValidator = new();
            private readonly static ResourceNameValidators.BlobContainerNameValidator _containerValidator = new();

            public override bool IsValid( ValidationContext<IntegrationServiceLogSetting.Options> context , string? value )
            {
                if ( !value.HasValue() )
                    return false;
                return (context.InstanceToValidate.UseDocumentStorage, context.InstanceToValidate.UseBlobStorage) switch
                {
                    (true, false ) => _tableValidator.Validate( new StorageTableName( value! ) ).IsValid,
                    (false, true ) => _containerValidator.Validate( new StorageBlobContainerName( value! ) ).IsValid,
                    _ => false
                };
            }

        }
    }
}

internal class IntegrationOptionValidator : AbstractValidator<IntegrationOption>
{
    public IntegrationOptionValidator()
    {
        RuleFor( x => x.Type ).NotEqual( IntegrationType.Unknown ).WithMessage( "Invalid integration type detected." );
        RuleFor( x => x.Name.Value ).NotNull().NotEmpty().WithMessage( "IntegrationName required to configure option." );
        RuleFor( x => x.ClientConfiguration).NotNull();
        RuleFor( x => x.ClientConfiguration ).Must( x => x.IsSqlConfiguration || x.IsStorageConfiguration || x.IsRestConfiguration );
        RuleFor( x => x.ClientConfiguration ).SetValidator( new ClientSettingsValidator() );
    }
}
internal class ClientSettingsValidator : PropertyValidator<IntegrationOption , IntegratedClientSettings>
{
    public override string Name => nameof( ClientSettingsValidator );
    private static readonly SqlIntegrationValidator _sqlValidator = new();
    private static readonly StorageIntegrationValidator _storageValidator = new();
    private static readonly RestIntegrationValidator _restValidator = new();
    public override bool IsValid( ValidationContext<IntegrationOption> context , IntegratedClientSettings value )
    {
        if ( value.IsSqlConfiguration )
            return _sqlValidator.Validate( value.AsSqlOptions ).IsValid;

        if ( value.IsStorageConfiguration )
            return _storageValidator.Validate( value.AsStorageOptions ).IsValid;

        if ( value.IsRestConfiguration )
            return _restValidator.Validate( value.AsRestOptions ).IsValid;

        return false;
    }

    internal class RestIntegrationValidator : AbstractValidator<RestClientConfiguration>
    {
        public RestIntegrationValidator()
        {
            RuleFor( x => x.BaseUrl.Value )
                .NotNull()
                .NotEmpty()
                .WithMessage( x => $"BaseUrl required to configure Rest Client." );


            //There has to be some type of auth options configured
            When( x => x.OAuthCredentials is null && x.ApiUser is null , () =>
            {
                RuleFor( x => x.ApiKey ).NotNull().WithMessage( _authError );
            } );
            When( x => x.OAuthCredentials is null && x.ApiKey is null , () =>
            {
                RuleFor( x => x.ApiUser ).NotNull().WithMessage( _authError );
            } );
            When( x => x.ApiKey is null && x.ApiUser is null , () =>
            {
                RuleFor( x => x.OAuthCredentials ).NotNull().WithMessage( _authError );
            } );

            //If you say the custom headers are required, there should be headers configured
            When( x => x.CustomHeadersRequired , () =>
            {
                RuleFor( x => x.CustomHeaders ).Must( x => x.HasItems() )
                .WithMessage( "Configuration indicates custom headers are required, but no custom headers have been provided." );
            } );
        }

        const string _authError = $"{nameof(RestClientConfiguration)} must have an authentication option configured.";
    }
    internal class SqlIntegrationValidator : AbstractValidator<SqlClientConfiguration>
    {
        public SqlIntegrationValidator()
        {
            RuleFor( x => x.SqlConnectionString )
                .NotNull()
                .NotEmpty()
                .WithMessage( x => $"Sql Connection String required." );
        }
    }
    internal class StorageIntegrationValidator : AbstractValidator<StorageClientConfiguration>
    {
        public StorageIntegrationValidator()
        {
            RuleFor( x => x.ServiceConnectionString ).Must( x => !string.IsNullOrWhiteSpace( x ) ).WithMessage( "ServiceConnectionString required for storage integration." );

        }
    }
}


