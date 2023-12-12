using advanded_csharp_service.Log4net;
using advanded_csharp_service;
using Microsoft.AspNetCore.Mvc;
using advanded_csharp_service.CartService;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using System.Text.Json;


namespace advanded_csharp_main.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly ICartService _iCartService;

        public CartController()
        {
            _iCartService = new CartService();
            _loggingService = new LoggingService();
        }

        /// <summary>
        /// update add cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddandUpdateCart")]
        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] CartProductRequest request)
        {
            try
            {
                ListProductInCartResponse cartOfUserResponse = await _iCartService.AddToCart(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(cartOfUserResponse));
                return new JsonResult(cartOfUserResponse);
            }
            catch (Exception ex)
            {
                // send to logging service

                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get cart value
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("get_cart")]
        [HttpGet]
        public async Task<IActionResult> getCart([FromQuery] Guid userID)
        {
            try
            {
                ListProductInCartResponse cartOfUserResponse = await _iCartService.GetCart(userID);
                return new JsonResult(cartOfUserResponse);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// DeleteItem in cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Del-ItemInCart")]
        [HttpPost]
        public async Task<IActionResult> DeleteItemCart([FromQuery] CartProductRequest request)
        {
            try
            {
                ListProductInCartResponse cartOfUserResponse = await _iCartService.DeleteItemCart(request);
                return new JsonResult(cartOfUserResponse);
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
