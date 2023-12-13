using advanded_csharp_dto.Response;
using System.ComponentModel.DataAnnotations.Schema;

namespace advanded_csharp_database.Models
{
    [Table("Users")]
    public class User : BaseEntity, ITransfrom<UserResponse>
    {
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string Role { get; set; } = string.Empty;

        public UserResponse Transfrom()
        {
            return new UserResponse()
            {
                Id = Id,
                User_Name = User_Name,
                User_Email = User_Email,
                User_Password = User_Password,
            };
        }
    }
}
/// <summary>
/// thử dùng enum đễ truyền dữ liệu những lỗi
/// public ERole Role { get; set; }
/// </summary>
/// <value> Lỗi khi lấy ra
/// </value>
