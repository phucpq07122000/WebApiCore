﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_dto.Request
{
    public class GetListUserRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public string UserName { get; set; } = string.Empty;

        public readonly bool IsActive ;
    }
}
