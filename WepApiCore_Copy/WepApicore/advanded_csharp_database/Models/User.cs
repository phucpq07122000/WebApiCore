using advanded_csharp_database.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace advanded_csharp_database.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ERole Role { get; set; }
    }
}
