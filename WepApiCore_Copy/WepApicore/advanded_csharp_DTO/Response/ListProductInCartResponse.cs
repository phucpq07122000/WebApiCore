using advanded_csharp_dto.DTOEnitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class ListProductInCartResponse
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<ProductRespone> Data { get; set; } = new List<ProductRespone>();
        public int Count { get; set; }
        public int TotalPay { get; set; }
        public int Total { get; set; }
    }
}
