using FluentValidation;

namespace AtlConsultingIo.IntegrationOperations;

internal class TextFileLogOptionsValidator : AbstractValidator<TextFileLoggingOptions?>
{
    public TextFileLogOptionsValidator()
    {
        RuleFor( x => x ).NotNull();
        RuleFor( x => x!.LogFileName ).NotNull().NotEmpty().WithMessage( $"{nameof( TextFileLoggingOptions.LogFileName )} required to use local file logger." );
        RuleFor( x => x!.LogDirectoryPath ).NotNull().NotEmpty().WithMessage( $"{nameof( TextFileLoggingOptions.LogDirectoryPath )} required to use local file logger." );
    }
}


