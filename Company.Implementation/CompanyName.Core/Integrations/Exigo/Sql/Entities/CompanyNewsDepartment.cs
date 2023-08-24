using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("NewsId", "DepartmentId")]
public partial class CompanyNewsDepartment
{
    [Key]
    [Column("NewsID")]
    public int NewsId { get; set; }

    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }
}
