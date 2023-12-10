using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;


namespace advanded_csharp_service.ProductService
{
    public interface IProductService
    {

        /// <summary>
        /// Add new Product to database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> AddNewProduct(ProductDto request);

        /// <summary>
        /// Get Detail Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ProductDto> GetDetailProduct(Guid id);

        /// <summary>
        /// Get Product by Name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDataProductResponse> GetProductList(GetListProductRequest request);

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ProductDto> UpdateProduct(ProductDto request);

        /// <summary>
        /// Delete  product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> DeleteProduct(Guid requestID);




    }
}
