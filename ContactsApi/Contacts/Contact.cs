using ContactsApi.Addresses;
using ContactsApi.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }

        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
