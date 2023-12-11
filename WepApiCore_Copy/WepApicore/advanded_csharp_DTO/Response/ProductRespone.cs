using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class ProductRespone
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Unit { get; set; }= string.Empty;
        public int Quantity { get; set; } = 0;
        public string Images { get; set; } = string.Empty;
       
    }
}
