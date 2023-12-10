
using advanded_csharp_service.Log4net;
using advanded_csharp_service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using advanded_csharp_service.UserService;
using advanded_csharp_dto.DTOEnitity;

namespace advanded_csharp_main.Controllers
{
    [Route("api/UserRun")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly IUserService _iUserService;

        public UserController()
        {
            _iUserService = new UserService();
            _loggingService = new LoggingService();
        }

        /// <summary>
        /// Get all data or data by name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("get-AddnewUser")]
        [HttpPost()]
        public async Task<IActionResult> AddNewUser([FromQuery]UserDto request)
        {
            try
            {
                bool i = await _iUserService.AddNewUser(request);
                if (i)
                {
                    _loggingService.LogInfo(JsonSerializer.Serialize(i));
                    return new JsonResult("success");
                }
                else
                {
                    _loggingService.LogInfo(JsonSerializer.Serialize(i));
                    return new JsonResult("Fail");

                }
            }catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
