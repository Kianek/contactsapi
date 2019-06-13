using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Users
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRegistrationDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
