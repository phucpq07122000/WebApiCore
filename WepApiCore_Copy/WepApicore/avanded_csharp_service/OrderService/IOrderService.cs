using advanded_csharp_dto.Response;

namespace advanded_csharp_service.OrderService
{
    public interface IOrderService
    {
        /// <summary>
        /// Insert data cart to order
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<GetListOrderResponse> InsertOrder(Guid cartId);

        /// <summary>
        /// DetDetai infrom in order
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task<GetListOrderResponse> GetOrder(Guid OrderId);
    }
}
