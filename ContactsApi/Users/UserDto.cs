using ContactsApi.Addresses;
using ContactsApi.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }

        public UserDto(User user)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Contacts = user.Contacts;
        }

        public UserDto() { }
    }
}
