using advanded_csharp_DTO;

namespace advanded_csharp_dto.Request
{
    public class GetListProductRequest : IPaging
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public string ProductName { get; set; } = string.Empty;

    }
}
