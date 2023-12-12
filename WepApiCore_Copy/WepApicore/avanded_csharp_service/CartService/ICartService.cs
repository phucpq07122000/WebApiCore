using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;

namespace advanded_csharp_service.CartService
{
    public interface ICartService
    {
        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListProductInCartResponse> AddToCart(CartProductRequest request);


        /// <summary>
        /// Get detail Cart
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        Task<ListProductInCartResponse> GetCart(Guid cardId);

        /// <summary>
        /// Del item in prodcut cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListProductInCartResponse> DeleteItemCart(CartProductRequest request);


    }
}
