using ContactsApi.Addresses;
using ContactsApi.Contacts;
using ContactsApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApi.Tests.Infrastructure
{
    public static class SeedData
    {
        public static void InitializeDb(ContactsDbContext db)
        {
            db.AddRange(SeedContacts());
            db.AddRange(SeedAddresses());
            db.SaveChanges();
        }

        public static List<Address> SeedAddresses()
        {
            return new List<Address>
            {
                new Address { Id = 1, Line1 = "123 Street St", Line2 = "Suite 123", City = "Townsville", StateOrProvince = "Nowhere", PostalCode = "12345"},
                new Address { Id = 2, Line1 = "321 Boulevard Ave", Line2 = "Suite 555", City = "Village City", StateOrProvince = "Somewhere", PostalCode = "12345"},
                new Address { Id = 3, Line1 = "4444 House Pl. ", Line2 = "", City = "City Town", StateOrProvince = "New Nowhere", PostalCode = "12345"},
                new Address { Id = 4, Line1 = "777 Angel Complex", Line2 = "Apt 123", City = "Metropolis", StateOrProvince = "Atlantis", PostalCode = "12345"},
            };
        }

        public static List<Contact> SeedContacts()
        {
            return new List<Contact>
            {
                new Contact {Id = 1, FirstName = "Bob", LastName = "Loblaw", Email = "bob@gmail.com", CellPhone = "555-555-5555"},
                new Contact {Id = 2, FirstName = "Joe", LastName = "Blow", Email = "joeblows@gmail.com", CellPhone = "555-555-5555"},
                new Contact {Id = 3, FirstName = "Turd", LastName = "Ferguson", Email = "turd@gmail.com", CellPhone = "555-555-5555"},
                new Contact {Id = 4, FirstName = "Leeroy", LastName = "Jenkins", Email = "ljenkins@gmail.com", CellPhone = "555-555-5555"}
            };
        }
    }
}
