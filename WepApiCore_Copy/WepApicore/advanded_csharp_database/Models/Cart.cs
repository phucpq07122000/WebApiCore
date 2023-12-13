using advanded_csharp_dto.Response;
using System.ComponentModel.DataAnnotations.Schema;

namespace advanded_csharp_database.Models
{
    [Table("Cart")]
    public class Cart : BaseEntity, ITransfrom<CartResponse>
    {
        [Column("List_Product_Id")]
        public string ListProduct { get; set; } = string.Empty;

        public CartResponse Transfrom()
        {
            return new CartResponse()
            {
                UserId = Id,
                ListProduct = ListProduct
            };
        }
    }
}
