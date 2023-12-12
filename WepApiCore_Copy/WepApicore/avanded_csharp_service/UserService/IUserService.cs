using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
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

        /// <summary>
        /// Get All User 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <returns></returns>
        Task<UserListrResponse> GetUserListIsActive(GetListUserRequest request);

        /// <summary>
        /// Update USer
        /// </summary>
        /// <param name="requestUpdate"></param>
        /// <returns></returns>
        Task<UserResponse> UpdateUser(UserRequest requestUpdate);

        /// <summary>
        /// Del user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(Guid id);
        /// <summary>
        /// Get USer details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponse> GetUserDetail(Guid id);

    }
}
