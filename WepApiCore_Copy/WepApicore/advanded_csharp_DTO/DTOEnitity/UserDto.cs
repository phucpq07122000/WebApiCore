namespace advanded_csharp_dto.DTOEnitity
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Password { get; set; } = string.Empty;
       //public bool IsActive { get; set; } = true;
    }
}
