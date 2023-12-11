using advanded_csharp_dto.Response;
using System.ComponentModel.DataAnnotations.Schema;

namespace advanded_csharp_database.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Unit { get; set; } = "VND";
        public string Images { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ProductRespone CloneProductToCart()
        {
            return new ProductRespone()
            {
              Id= Id,
              Name= Name,
              Price= Price,
              Unit= Unit,
              Quantity=Quantity,
            };
        }
    }
}
