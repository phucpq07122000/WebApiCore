using advanded_csharp_dto.DTOEnitity;

namespace advanded_csharp_dto.Response
{
    public class GetDataProductResponse
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public List<ProductDto> Data { get; set; } = new List<ProductDto>();

        public int Total { get; set; }
    }
}
