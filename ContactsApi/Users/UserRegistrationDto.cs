using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Users
{
    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRegistrationDto(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
