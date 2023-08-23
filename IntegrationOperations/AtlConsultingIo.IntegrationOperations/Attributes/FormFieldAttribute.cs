
namespace AtlConsultingIo.IntegrationOperations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field , AllowMultiple = false, Inherited = true )]
public sealed class FormFieldAttribute: Attribute
{
    public string Name { get; set; }
    public FormFieldAttribute( string FieldName )
    {
        Name = FieldName;
    }
}
