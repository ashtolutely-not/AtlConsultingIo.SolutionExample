using FluentValidation;
namespace AtlConsultingIo.IntegrationOperations;

//Note:
//  I'm not validating the SendUrl because it is possible that a client can be configured for a specific route instead of the API's base URL
//  Therefore, it's possible requests for that integration will not ever include a relative route (aka SendUrl)

public class RestClientFormCommandValidator: AbstractValidator<RestClientFormCommand> 
{
    public RestClientFormCommandValidator()
    {
        Include(new IntegrationRequestValidator<RestClientFormCommand>());
        RuleFor( x => x.FormContent).NotNull();
    }
}
public class RestClientFormTransactionValidator : AbstractValidator<RestClientFormTransaction> 
{
    public RestClientFormTransactionValidator()
    {
        Include(new IntegrationRequestValidator<RestClientFormTransaction>());
        RuleFor( x => x.FormContent).NotNull();
        RuleFor( x => x.Convert).NotNull();
    }
}
public class HttpJsonRequestValidator : AbstractValidator<RestClientJsonTransaction>
{
    public HttpJsonRequestValidator()
    {
        Include(new IntegrationRequestValidator<RestClientJsonTransaction>());
        RuleFor( x => x.JsonData ).NotNull();
        RuleFor( x => x.HttpMethod ).NotNull();
    }
}
public class HttpJsonCommandValidator: AbstractValidator<RestClientJsonCommand>
{
    public HttpJsonCommandValidator()
    {
        Include(new IntegrationRequestValidator<RestClientJsonCommand>());
        RuleFor( x => x.JsonData ).NotNull();
    }
}
// We either need to have additional route values, for example /{entity}/{id}
// Or we need query params to attach a query string to the base url
public class RestClientJsonQueryValidator : AbstractValidator<RestClientJsonQuery>
{
    public RestClientJsonQueryValidator()
    {
        Include(new IntegrationRequestValidator<RestClientJsonQuery>());
        When( x => !x.QueryParams.HasItems() , () => RuleFor( x => x.SendUrl.Value ).NotNull().NotEmpty());
        When( x => !x.SendUrl.Value.HasValue(), () => RuleFor( x => x.QueryParams).Must( x => x.HasItems() ));
    }
}

