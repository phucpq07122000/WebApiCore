
using advanded_csharp_dto.Response;
using advanded_csharp_service;
using advanded_csharp_service.Log4net;
using advanded_csharp_service.OrderService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace advanded_csharp_main.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly IOrderService _iOrderService;

        public OrderController()
        {
            _iOrderService = new OrderService();
            _loggingService = new LoggingService();
        }

        /// <summary>
        /// Insert Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("InsertCart")]
        [HttpPost]
        public async Task<IActionResult> InserOrder([FromQuery] Guid cartId)
        {
            try
            {
                GetListOrderResponse getListOrderResponse = await _iOrderService.InsertOrder(cartId);
                _loggingService.LogInfo(JsonSerializer.Serialize(getListOrderResponse));
                return new JsonResult(getListOrderResponse);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Order
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Route("GetDetail-OrderOfUser")]
        [HttpGet]
        public async Task<IActionResult> GetOrder([FromQuery] Guid orderId)
        {
            try
            {
                GetListOrderResponse getListOrderResponse = await _iOrderService.GetOrder(orderId);
                _loggingService.LogInfo(JsonSerializer.Serialize(getListOrderResponse));
                return new JsonResult(getListOrderResponse);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
