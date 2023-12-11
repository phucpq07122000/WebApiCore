using advanded_csharp_dto.DTOEnitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Response
{
    public class UserListrResponse
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<UserResponse> Data { get; set; } = new List<UserResponse>();
        public int Total { get; set; }
    }
}
