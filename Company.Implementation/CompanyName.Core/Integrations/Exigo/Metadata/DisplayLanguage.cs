using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
namespace CompanyName.Core.Integrations.Exigo;
[DapperHandler]
[NewtonsoftConverter]
public struct DisplayLanguage : IExigoTypeMetadata, IEquatable<DisplayLanguage>,
    IEquatable<ExigoTypeID>, IEquatable<TwoLetterISOCode>, IEquatable<string>
{
    public ExigoTypeID TypeID { get;  }
    public UIDisplayString? Description { get; }
    public TwoLetterISOCode TwoLetterISOCode { get;  }
    public bool IsDefault => TypeID.Equals(0);
    public DisplayLanguage( ExigoTypeID exigoID, string description, TwoLetterISOCode isoCode)
        => ( TypeID, Description, TwoLetterISOCode ) = ( exigoID, new(description) , isoCode );

    public DisplayLanguage( ExigoTypeID exigoID )
    {
        TypeID = exigoID;
        TwoLetterISOCode = TwoLetterISOCode.Default;
        Description = null;
    }

    public static readonly DisplayLanguage None = new();
    public static readonly DisplayLanguage English = new( new ExigoTypeID(0), "English", TwoLetterISOCode.English );

    public static implicit operator int( DisplayLanguage _ ) => _.TypeID;
    public static implicit operator ExigoTypeID( DisplayLanguage _ ) => new( _.TypeID );

    public bool Equals( ExigoTypeID other )
        => TypeID.Equals( other );

	public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && Description.Equals( other );
	public bool Equals( TwoLetterISOCode other )
        => TwoLetterISOCode.Equals( other );

    public bool Equals( DisplayLanguage other ) => other.TypeID.Equals ( TypeID ) || other.TwoLetterISOCode.Value.Equals ( TwoLetterISOCode.Value );
}
