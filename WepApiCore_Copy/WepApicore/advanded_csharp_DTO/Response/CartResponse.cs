using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class CartResponse
    {
        public Guid UserId { get; set; }
        public string ListProduct { get; set; } = string.Empty;
    }
}
