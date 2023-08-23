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
namespace CompanyName.Core.Entities.Order;

public  struct OrderTasksCanExecute : IBooleanValue, IEquatable<bool>, IEquatable<int>, IEquatable<int?>
{
    private static readonly int[] _processedStatuses = new int[]{ 7 , 8 , 9 };
    public bool Value { get; set; }
    private OrderTasksCanExecute( bool value ) => Value = value;

    public static implicit operator bool( OrderTasksCanExecute _ ) => _.Value;

    public static OrderTasksCanExecute Create( int status )
        => new OrderTasksCanExecute( _processedStatuses.Contains(status) );
	public bool Equals( bool other ) => Value.Equals( other );
	public bool Equals( int other ) => _processedStatuses.Contains( other );
	public bool Equals( int? other ) => _processedStatuses.Contains( other.GetValueOrDefault() );
}
