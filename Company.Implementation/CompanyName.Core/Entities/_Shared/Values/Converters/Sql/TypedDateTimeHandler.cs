using System.Data;
namespace CompanyName.Core.Entities;

public sealed class TypedDateTimeHandler<T> : Dapper.SqlMapper.TypeHandler<T> where T : struct, IDateTimeValue
{
    public override T Parse( object value ) => value is not DateTime _dbValue ? new T() : IDateTimeValue.Create<T>( _dbValue );
    public override void SetValue( IDbDataParameter parameter , T typedDateTime ) => parameter.Value = typedDateTime.Value;
}
