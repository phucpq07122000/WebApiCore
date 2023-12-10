using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Response;

namespace advanded_csharp_service.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// Add new User to database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> AddNewUser(UserDto request);

        Task<UserResponse> GetUserList(Guid id);

    }
}
