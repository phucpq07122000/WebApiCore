using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Request
{
    public class AddProductToCart
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
