using advanded_csharp_dto.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_database.Models
{
    [Table("Orders")]
    public class Order : BaseEntity, ITransfrom<OrderResponse>
    {
        [Column("List_Product_Id")]
        public string ListProduct { get; set; } = string.Empty;
        public Int16 Number { get; set; }
        public decimal Payment { get; set; }
        public Guid UserID { get; set; }

        public OrderResponse Transfrom()
        {
             return new OrderResponse()
             {
                 Id=Id,
                 ListProduct = ListProduct,
                 Number = Number,
                 Payment = (double)Payment,
                 UserID = UserID  
             };
        }
    }
}
