using advanded_csharp_database;
using advanded_csharp_database.Models;
using advanded_csharp_dto.DTOEnitity;


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
                        Role= advanded_csharp_database.Enum.ERole.User
                    };
                    _ = await context.Users.AddAsync(newUser);
                    int i = context.SaveChanges();
                    return value = i > 0;
                }
            }
            return value;

        }
    }
}
