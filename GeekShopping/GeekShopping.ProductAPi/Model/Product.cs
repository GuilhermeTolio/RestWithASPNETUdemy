using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.ProductAPi.Model.Base;

namespace GeekShopping.ProductAPi.Model;


[Table("product")]
public class Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }
    
    [Column("price")]
    [Required]
    [Range(1, int.MaxValue)]
    public decimal Price { get; set; }
    
    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; }
    
    [Column("category_name")]
    [StringLength(50)]
    public string CategoryName { get; set; }
    
    [Column("image_url")]
    [StringLength(300)]
    public string ImageUrl { get; set; }
}