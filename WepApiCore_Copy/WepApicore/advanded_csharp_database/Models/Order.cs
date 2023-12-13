using advanded_csharp_dto.Response;
using System.ComponentModel.DataAnnotations.Schema;

namespace advanded_csharp_database.Models
{
    [Table("Orders")]
    public class Order : BaseEntity, ITransfrom<OrderResponse>
    {
        [Column("List_Product_Id")]
        public string ListProduct { get; set; } = string.Empty;
        public short Number { get; set; }
        public decimal Payment { get; set; }
        public Guid UserID { get; set; }

        public OrderResponse Transfrom()
        {
            return new OrderResponse()
            {
                Id = Id,
                ListProduct = ListProduct,
                Number = Number,
                Payment = (double)Payment,
                UserID = UserID
            };
        }
    }
}
