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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //base.OnConfiguring(optionsBuilder);
            builder.UseSqlite("Data Source=ContactsApi.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany<Contact>(user => user.Contacts)
                .WithOne(contact => contact.User);
            });

            // Configure Contacts
            modelBuilder.Entity<Contact>(entity =>
            {
                entity
                .HasMany<Address>(contact => contact.Addresses)
                .WithOne(address => address.Contact);
            });
        }
    }
}
