using System.Data;

namespace CompanyName.Core.Entities;
public sealed class TypedIntegerHandler<T> : Dapper.SqlMapper.TypeHandler<T> where T : struct,IIntegerValue
{
    public override T Parse( object value ) => value is not int _columnValue ? new() : IIntegerValue.Create<T>( _columnValue );
    public override void SetValue( IDbDataParameter parameter , T id ) => parameter.Value = id.Value;
}
