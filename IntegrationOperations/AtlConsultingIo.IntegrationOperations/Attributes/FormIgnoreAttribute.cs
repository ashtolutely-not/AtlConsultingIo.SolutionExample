
namespace AtlConsultingIo.IntegrationOperations;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field , AllowMultiple = false, Inherited = true )]
public sealed class FormIgnoreAttribute : Attribute
{
    public FormIgnoreAttribute()
    {
        
    }
}


