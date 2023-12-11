using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using advanded_csharp_service;
using advanded_csharp_service.Log4net;
using advanded_csharp_service.ProductService;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace advanded_csharp_main.Controllers
{
    [Route("api/ProductRun")]
    [ApiController]
    public class ProdcutController : ControllerBase
    {

        private readonly ILoggingService _loggingService;
        private readonly IProductService _iProductService;

        public ProdcutController()
        {
            _iProductService = new ProductService();
            _loggingService = new LoggingService();
        }

        /// <summary>
        /// Get all data or data by name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("get-ProductListn")]
        [HttpGet()]
        public async Task<IActionResult> GetListProduct([FromQuery] GetListProductRequest request)
        {
            try
            {
                GetDataProductResponse response = await _iProductService.GetProductList(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-ProdcutDetails")]
        [HttpGet()]
        public async Task<IActionResult> GetDetailProduct([FromQuery] Guid id)
        {
            try
            {
                ProductDto response = await _iProductService.GetDetailProduct(id);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// add new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("add-Product")]
        [HttpPost()]
        public async Task<IActionResult> AddNewProduct([FromQuery] ProductDto request)
        {
            try
            {
                bool i = await _iProductService.AddNewProduct(request);
                if (i)
                {
                    _loggingService.LogInfo(JsonSerializer.Serialize(i));
                    return new JsonResult("success");
                }
                else
                {
                    return new JsonResult("Fail");
                }
            }

            catch (Exception ex)
            {
                // send to logging service

                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// add new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("update-Product")]
        [HttpPost()]
        public async Task<IActionResult> UpdateProduct([FromQuery] ProductDto request)
        {
            try
            {
                ProductDto response = await _iProductService.UpdateProduct(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }

            catch (Exception ex)
            {
                // send to logging service

                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Delete-Product")]
        [HttpDelete]
        public async Task<IActionResult> DeletetProduct([FromQuery] Guid requestID)
        {
            try
            {
                bool deleteReturn = await _iProductService.DeleteProduct(requestID);
                _loggingService.LogInfo(JsonSerializer.Serialize(deleteReturn));
                return new JsonResult(deleteReturn);
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
