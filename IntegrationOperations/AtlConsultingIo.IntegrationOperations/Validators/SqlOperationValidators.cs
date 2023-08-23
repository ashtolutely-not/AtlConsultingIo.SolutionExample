
using FluentValidation;
namespace AtlConsultingIo.IntegrationOperations;

public class SqlSearchValidator : AbstractValidator<SearchSqlEntities>

{
    public SqlSearchValidator()
    {
        Include(new IntegrationRequestValidator<SearchSqlEntities>());
        RuleFor( x => x.SearchProcedure ).Must( x => !string.IsNullOrWhiteSpace( x.SafeString ) );
    }
}

public class SqlInsertValidator : AbstractValidator<InsertSqlRow> 
{
    public SqlInsertValidator()
    {
        Include(new IntegrationRequestValidator<InsertSqlRow>());
        RuleFor( x => x.RowData ).NotNull();
        RuleFor( x => x.PrimaryKeyColumn.Value ).NotNull().NotEmpty();
        RuleFor( x => x.TableName.Value).NotNull().NotEmpty();
    }
}

public class SqlUpdateValidator : AbstractValidator<UpdateSqlRow> 
{
    public SqlUpdateValidator()
    {
        Include(new IntegrationRequestValidator<UpdateSqlRow>());
        RuleFor( x => x.RowData ).NotNull();
        RuleFor( x => x.PrimaryKeyColumn.Value ).NotNull().NotEmpty();
        RuleFor( x => x.RowId.Id ).Must( v => v.Value.Match( str => !string.IsNullOrWhiteSpace(str), num => num > 0 ));
        RuleFor( x => x.TableName.Value).NotNull().NotEmpty();
    }
}

public class SqlDeleteValidator : AbstractValidator<DeleteSqlRow>
{
    public SqlDeleteValidator()
    {
        Include(new IntegrationRequestValidator<DeleteSqlRow>());
        RuleFor( x => x.TableName).NotNull().NotEmpty();
        RuleFor( x => x.PrimaryKeyColumn.Value ).NotNull().NotEmpty();
        RuleFor( x => x.TableName.Value).NotNull().NotEmpty();
    }
}

public class SqlQueryValidator : AbstractValidator<FindSqlRow>
{
    public SqlQueryValidator()
    {
        Include(new IntegrationRequestValidator<FindSqlRow>());
        RuleFor( x => x.TableName.Value).NotNull().NotEmpty();
        RuleFor( x => x.PrimaryKeyColumn.Value ).NotNull().NotEmpty();
        RuleFor( x => x.RowId.Id ).Must( x => x.Value.Match( str => !string.IsNullOrWhiteSpace(str), num => num > 0 ));
    }

}

