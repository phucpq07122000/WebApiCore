using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class GetListOrderResponse
    {
        public int PageSize { get; set; } 
        public int PageIndex { get; set; }
        public List<ProductRespone> ListProduct { get; set; } = new List<ProductRespone>();
        public int Number { get; set; }
        public string Payment { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
