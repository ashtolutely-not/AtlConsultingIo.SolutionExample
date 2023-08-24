using System.Data;
namespace CompanyName.Core.Entities;

public sealed class TypedDecimalHandler<T> : Dapper.SqlMapper.TypeHandler<T> where T : struct, IDecimalValue
{
    public override T Parse( object value ) => value is not decimal _dbValue ? new T ( ) : IDecimalValue.Create<T> ( _dbValue );
    public override void SetValue( IDbDataParameter parameter , T typedDecimal ) => parameter.Value = typedDecimal.Value;
}
