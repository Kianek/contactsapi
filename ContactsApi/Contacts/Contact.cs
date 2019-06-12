using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Users;

namespace ContactsApi.Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
