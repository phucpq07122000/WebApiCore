﻿namespace advanded_csharp_dto.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Email { get; set; } = string.Empty;
        public string User_Password { get; set; } = string.Empty;

    }
}
