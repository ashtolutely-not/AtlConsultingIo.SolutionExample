
namespace CompanyName.Core;

    [AttributeUsage( AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class NewtonsoftConverterAttribute : Attribute
	{

        public NewtonsoftConverterAttribute( )
        {

        }
    }

	[AttributeUsage( AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class DapperHandlerAttribute : Attribute
	{

        public DapperHandlerAttribute( )
        {

        }
    }

