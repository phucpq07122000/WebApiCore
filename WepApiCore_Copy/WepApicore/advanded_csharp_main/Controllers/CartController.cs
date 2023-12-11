using advanded_csharp_service.Log4net;

using advanded_csharp_service;
using Microsoft.AspNetCore.Mvc;
using advanded_csharp_service.CartService;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using System.Text.Json;
using System.Collections.Generic;

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

        [HttpGet]
        public async Task<IActionResult> Addry([FromQuery] AddProductToCart request)
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


        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> getCart([FromQuery]Guid userID)
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

        //[Route("update")]
        //[HttpPost]
        //public async Task<IActionResult> updatetCart([FromQuery] AddProductToCart request)
        //{
        //    try
        //    {
        //       CartResponse cartOfUserResponse = await _iCartService.UpdateCart(request);
        //        return new JsonResult(cartOfUserResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        // send to logging service
        //        _loggingService.LogError(ex);
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
