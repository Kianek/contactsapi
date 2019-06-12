using ContactsApi.Addresses;
using ContactsApi.Contacts;
using ContactsApi.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Infrastructure
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext() { }

        DbSet<Address> Addresses { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<User> Users { get; set; }
    }
}
