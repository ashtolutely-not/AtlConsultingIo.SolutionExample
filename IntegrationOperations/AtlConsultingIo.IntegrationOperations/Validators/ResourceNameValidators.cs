using FluentValidation;

namespace AtlConsultingIo.IntegrationOperations;
internal struct ResourceNameValidators
{
    public class BlobNameValidator : AbstractValidator<StorageBlobName>
    {
        public BlobNameValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor( n => n.Value )
                .MinimumLength( Limits.BlobNameMinLength )
                .MaximumLength( Limits.BlobNameMaxLength )
                    .WithMessage( n => ErrorMessages.LengthError( Limits.BlobNameMinLength , Limits.BlobNameMaxLength , n.Value.Length ) );

            RuleFor( n => n.PathSegments )
                .Must( v => v.Count() <= Limits.BlobSegmentsMaxCount )
                .WithMessage( n => ErrorMessages.SegmentsError( n.PathSegments.Count() ) );
        }
    }

    public class BlobContainerNameValidator : AbstractValidator<StorageBlobContainerName>
    {
        public BlobContainerNameValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor( n => n.Value )
                .MinimumLength( Limits.ResourceNameMinLength )
                .MaximumLength( Limits.ResourceNameMaxLength )
                    .WithMessage( n => ErrorMessages.LengthError( Limits.ResourceNameMinLength , Limits.ResourceNameMaxLength , n.Value.Length ) )
                .Must( v => v.All( c => c.Equals( '-' ) || char.IsLetterOrDigit( c ) || c.Equals( '.' ) ) )
                    .WithMessage( n => ErrorMessages.IllegalCharacterError( n.Value.Where( c => !c.Equals( '-' ) && !char.IsLetterOrDigit( c ) && !c.Equals( '.' ) ) ) )
                .Must( v => !v.Contains( "--" ) )
                    .WithMessage( n => ErrorMessages.ConsecutiveDashError( n.Value ) )
                .Must( v => char.IsLetterOrDigit( v[ 0 ] ) && char.IsLetterOrDigit( v[ ^1 ] ) )
                    .WithMessage( name => ErrorMessages.FirstAndLastError( name.Value ) )
                .Must( v => v.Where( c => char.IsLetter( c ) ).All( c => char.IsLower( c ) ) )
                    .WithMessage( n => ErrorMessages.LowercaseNameError( n.Value ) );
        }
    }

    public class QueueNameValidator : AbstractValidator<StorageQueueName>
    {
        public QueueNameValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor( n => n.Value )
                .MinimumLength( Limits.ResourceNameMinLength )
                .MaximumLength( Limits.ResourceNameMaxLength )
                    .WithMessage( n => ErrorMessages.LengthError( Limits.ResourceNameMinLength , Limits.ResourceNameMaxLength , n.Value.Length ) )
                .Must( v => v.All( c => c.Equals( '-' ) || char.IsLetterOrDigit( c ) ) )
                    .WithMessage( n => ErrorMessages.IllegalCharacterError( n.Value.Where( c => !c.Equals( '-' ) && !char.IsLetterOrDigit( c ) ) ) )
                .Must( v => !v.Contains( "--" ) )
                    .WithMessage( n => ErrorMessages.ConsecutiveDashError( n.Value ) )
                .Must( v => char.IsLetterOrDigit( v[ 0 ] ) && char.IsLetterOrDigit( v[ ^1 ] ) )
                    .WithMessage( name => ErrorMessages.FirstAndLastError( name.Value ) )
                .Must( v => v.Where( c => char.IsLetter( c ) ).All( c => char.IsLower( c ) ) )
                    .WithMessage( n => ErrorMessages.LowercaseNameError( n.Value ) );
        }
    }

    public class TableNameValidator : AbstractValidator<StorageTableName>
    {
        public TableNameValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor( n => n.Value )
                .MinimumLength( Limits.ResourceNameMinLength )
                .MaximumLength( Limits.ResourceNameMaxLength )
                    .WithMessage( n => ErrorMessages.LengthError( Limits.ResourceNameMinLength , Limits.ResourceNameMaxLength , n.Value.Length ) )
                .Must( v => v.All( c => char.IsLetterOrDigit( c ) ) )
                    .WithMessage( n => ErrorMessages.IllegalCharacterError( n.Value.Where( c => !char.IsLetterOrDigit( c ) ) ) )
                .Must( v => char.IsLetter( v[ 0 ] ) )
                    .WithMessage( n => ErrorMessages.FirstCharError( n.Value[ 0 ] ) );
        }
    }
    struct Limits
    {
        public const int ResourceNameMinLength = 3;
        public const int ResourceNameMaxLength = 63;

        public const int BlobSegmentsMaxCount = 254;
        public const char BlobSegmentsDelimiter = '/';

        //The Azure storage resource actually supports names up to 1024 characters in length
        //But the emulator used for local development only supports 256 so we'll enforce this
        //limit to ensure code can be tested using this tool
        public const int BlobNameMinLength = 1;
        public const int BlobNameMaxLength = 256;
    }
    struct ErrorMessages
    {
        internal static string FirstAndLastError( string name )
        => string.Format(
                "Invalid name, names must start and end with a number or letter.  (Actual Values: FirstChar [{0}] | LastChar [{1}])" ,
                name[ 0 ] ,
                name[ ^1 ]
            );

        internal static string FirstCharError( char firstChar )
            => string.Format(
                    "Invalid name, names must start with a  letter.  (Actual Value: {0})" ,
                    firstChar
                );
        internal static string LengthError( int min , int max , int actualLength )
            => string.Format(
                    "Invalid name. Name must be between {0} and {1} characters long.  Actual Length is {2}" ,
                    min ,
                    max ,
                    actualLength
                );
        internal static string IllegalCharacterError( IEnumerable<char> illegalCharacters )
            => string.Format(
                    "Invalid container name.  Names may only include letters, numbers, or dashes.  Illegal Characters: {0}" ,
                    string.Join( ',' , illegalCharacters )
                );
        internal static string ConsecutiveDashError( string name )
            => string.Format(
                    "Name cannot include consecutive dashes.  Actual Value:  {0}" ,
                    name
                );
        internal static string LowercaseNameError( string name )
            => string.Format(
                    "Name can only contain lowercase values.  Actual Value:  {0}" ,
                    name.EmptyIfNull()
                );
        internal static string SegmentsError( int actualCount )
            => string.Format(
                    "Invalid blob name. Name may only contain up to {0} path segements.  Actual segments found is {1}" ,
                    Limits.BlobSegmentsMaxCount ,
                    actualCount
                );
    }
}




