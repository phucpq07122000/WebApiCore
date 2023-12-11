using advanded_csharp_database;
using advanded_csharp_database.Models;
using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using Microsoft.EntityFrameworkCore;

namespace advanded_csharp_service.UserService
{
    public class UserService : IUserService
    {
        public async Task<bool> AddNewUser(UserDto request)
        {
            bool value = false;
            using (DataDbContext context = new())
            {
                if (context.Users != null)
                {
                    User newUser = new()
                    {
                        User_Name = request.User_Name,
                        User_Email = request.User_Email,
                        User_Password = BCrypt.Net.BCrypt.HashPassword(request.User_Password),
                        Role = "user"
                    };
                    _ = await context.Users.AddAsync(newUser);
                    int i = context.SaveChanges();
                    return value = i > 0;
                }
            }
            return value;

        }

        public Task<UserResponse> GetUserDetail(Guid id)
        {
            UserResponse userResponse = new();
            using( DataDbContext context = new())
            {
                if (context.Users != null)
                {
                    User? user =  context.Users.Find(id);
                    if (user != null)
                    {
                       userResponse = user.Transfrom();
                      
                        return Task.FromResult(userResponse);
                    }
                }
            }     
            return Task.FromResult(userResponse);
        }

        public async Task<UserListrResponse> GetUserListIsActive(GetListUserRequest request)
        {
            UserListrResponse userListrResponse = new()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };
            using (DataDbContext context = new())
            {
                if (context.Users != null)
                {
                    IQueryable<User> query = context.Users
                    .Where(a => a.IsActive && a.User_Name.Contains(request.UserName))
                    .OrderBy(a => a.CreatedAt)
                    .AsQueryable(); // not excute

                    userListrResponse.Data = await query
                        .Skip(request.PageSize * (request.PageIndex - 1))
                        .Take(request.PageSize)
                        //.Select(a => a.Transfrom()).ToListAsync();
                        .Select(a => new UserResponse()
                        {
                            Id = a.Id,
                            User_Name = a.User_Name,
                            User_Email = a.User_Email,
                            User_Password = a.User_Password
                        }).ToListAsync();
                    userListrResponse.Total = await query.CountAsync();
                }
            }
            return userListrResponse;
        }

        public async Task<UserResponse> UpdateUser(UserRequest requestUpdate)
        {
            using (DataDbContext context = new())
            {
                if (context.Users != null)
                {
                    User? existingUser = context.Users.Find(requestUpdate.id);
                    if (existingUser != null)
                    {
                        //Check Vallue update which is not have value
                        existingUser.User_Name = (requestUpdate.User_Name != "") ? requestUpdate.User_Name: existingUser.User_Name;
                        existingUser.User_Password = (requestUpdate.User_Password != "") ? BCrypt.Net.BCrypt.HashPassword(requestUpdate.User_Password) : existingUser.User_Password;
                        existingUser.User_Email = (requestUpdate.User_Email != "") ? requestUpdate.User_Email : existingUser.User_Email ;
                       
                        //executed update
                        _ = context.Users.Update(existingUser);
                        _ = await context.SaveChangesAsync();
                        return await GetUserDetail(requestUpdate.id);
                    }
                }
                return await GetUserDetail(requestUpdate.id);
            }
        }

        public Task<bool> DeleteUser(Guid id)
        {
            UserRequest deleteUesr = new()
            {
                id = id,
                IsActiveOrNot=false,           
            };
            bool i = (UpdateUser(deleteUesr) != null);
            return Task.FromResult(i);      
        }
    }
}
