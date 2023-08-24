using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("Path", "Name")]
public partial class ImageFile
{
    [Key]
    [StringLength(700)]
    public string Path { get; set; } = null!;

    [Key]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public int Size { get; set; }

    public byte[] ImageData { get; set; } = null!;
}
