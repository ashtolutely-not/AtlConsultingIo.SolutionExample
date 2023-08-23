
using FluentValidation;

namespace AtlConsultingIo.IntegrationOperations;

public class BlobInsertValidator : AbstractValidator<UploadJsonBlob>
{
    public BlobInsertValidator()
    {
        Include(new IntegrationRequestValidator<UploadJsonBlob>());
        RuleFor( x => x.BlobName ).SetValidator( new ResourceNameValidators.BlobNameValidator() );
        RuleFor( x => x.ContainerName ).SetValidator( new ResourceNameValidators.BlobContainerNameValidator() ) ;
        RuleFor( x => x.BlobContent).NotNull();
    }
}

public class BlobQueryValidator : AbstractValidator<FindJsonBlob>
{
    public BlobQueryValidator()
    {
        Include(new IntegrationRequestValidator<FindJsonBlob>());
        RuleFor( x => x.BlobName ).SetValidator( new ResourceNameValidators.BlobNameValidator() );
        RuleFor( x => x.ContainerName ).SetValidator( new ResourceNameValidators.BlobContainerNameValidator() ) ;
    }
}

public class FindDocumentValidator : AbstractValidator<FindTableDocument>
{
    public FindDocumentValidator()
    {
        Include(new IntegrationRequestValidator<FindTableDocument>());
        RuleFor( x => x.TableName).SetValidator( new ResourceNameValidators.TableNameValidator() );
        RuleFor( x => x.PartitionKey).NotNull().NotEmpty();
        RuleFor( x => x.RowKey).NotNull().NotEmpty();
    }
}

public class InsertQueueItemValidator : AbstractValidator<InsertQueueItem>
{
    public InsertQueueItemValidator()
    {
        Include(new IntegrationRequestValidator<InsertQueueItem>());
        RuleFor( x => x.QueueName).SetValidator( new ResourceNameValidators.QueueNameValidator() );
        RuleFor( x => x.QueueItem).NotNull();
    }
}

public class DocumentSearchValidator : AbstractValidator<SearchTableDocuments>
{
    public DocumentSearchValidator()
    {
        Include(new IntegrationRequestValidator<SearchTableDocuments>());
        RuleFor( x => x.TableName).SetValidator( new ResourceNameValidators.TableNameValidator() );
        RuleFor( x => x.FilterConditions).Must( x => x.HasItems() );
    }
}

public class DocumentUpsertValidator : AbstractValidator<UpsertTableDocument> 
{
    public DocumentUpsertValidator()
    {
        Include(new IntegrationRequestValidator<UpsertTableDocument>());
        RuleFor( x => x.TableName).SetValidator( new ResourceNameValidators.TableNameValidator() );
        RuleFor( x => x.EntityData.PartitionKey).NotNull().NotEmpty();
        RuleFor( x => x.EntityData.RowKey).NotNull().NotEmpty();
        RuleFor( x => x.EntityData).NotNull();
        RuleFor( x => x.EntityData.Keys).Must( k => k.HasItems());
    }
}





