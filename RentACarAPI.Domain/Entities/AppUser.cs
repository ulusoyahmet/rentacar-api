﻿namespace RentACarAPI.Domain.Entities
{
    public class AppUser
    {
        public int AppUserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public int AppRoleID { get; set; }
        public AppRole? AppRole { get; set; }
    }
}
