using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("ImageName", Name = "IX_ItemImages_ImageName")]
public partial class ItemImage
{
    [Key]
    [Column("ItemImageID")]
    public int ItemImageId { get; set; }

    [StringLength(500)]
    public string ImageName { get; set; } = null!;

    public byte[]? ImageData { get; set; }

    [Column("CompressionTypeID")]
    public int? CompressionTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
