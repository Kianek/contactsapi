﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ContactsApi.Contacts;

namespace ContactsApi.Users
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation Properties
        public ICollection<Contact> Contacts { get; set; }
    }
}
