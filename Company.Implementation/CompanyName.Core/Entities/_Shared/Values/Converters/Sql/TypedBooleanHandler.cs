using System.Data;
namespace CompanyName.Core.Entities;

public sealed class TypedBooleanHandler<T> : Dapper.SqlMapper.TypeHandler<T> where T : struct, IBooleanValue
{
    public override T Parse( object value ) => value is not bool _dbValue ? new T() : IBooleanValue.Create<T>( _dbValue  );
    public override void SetValue( IDbDataParameter parameter , T typedBool ) => parameter.Value = typedBool.Value;
}
