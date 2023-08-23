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
using System.Data;

namespace CompanyName.Core.Entities;
public sealed class TypedIntegerHandler<T> : Dapper.SqlMapper.TypeHandler<T> where T : struct,IIntegerValue
{
    public override T Parse( object value ) => value is not int _columnValue ? new() : IIntegerValue.Create<T>( _columnValue );
    public override void SetValue( IDbDataParameter parameter , T id ) => parameter.Value = id.Value;
}
