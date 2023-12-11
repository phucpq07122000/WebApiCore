
using advanded_csharp_service.Log4net;
using advanded_csharp_service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using advanded_csharp_service.UserService;
using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;

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

        /// <summary>
        /// Get List USer still active or not active
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("get-UserDetails")]
        [HttpGet()]
        public async Task<IActionResult> GetUserDetail([FromQuery]Guid id)
        {
            try
            {
                UserResponse response = await _iUserService.GetUserDetail(id);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get List USer still active or not active
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Get-UserActive")]
        [HttpGet()]
        public async Task<IActionResult> GetUserActive([FromQuery]GetListUserRequest request)
        {
            try
            {
                UserListrResponse response = await _iUserService.GetUserListIsActive(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("Update-UserActive")]
        [HttpPost()]
        public async Task<IActionResult> UpdateUserActive([FromQuery] UserRequest request)
        {
            try
            {
                UserResponse response = await _iUserService.UpdateUser(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("Delete-UserActive")]
        [HttpPost()]
        public async Task<IActionResult> DeleteUserActive([FromQuery] Guid id)
        {
            try
            {
                bool i = await _iUserService.DeleteUser(id);
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
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
