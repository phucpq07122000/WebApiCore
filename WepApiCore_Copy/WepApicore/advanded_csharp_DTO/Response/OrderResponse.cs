using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string ListProduct { get; set; } = string.Empty;
        public int Number { get; set; }
        public double Payment { get; set; }
        public Guid UserID { get; set; }
    }
}
