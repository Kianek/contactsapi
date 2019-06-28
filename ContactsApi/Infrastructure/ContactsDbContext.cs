using ContactsApi.Addresses;
using ContactsApi.Contacts;
using ContactsApi.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Infrastructure
{
  public class ContactsDbContext : IdentityDbContext<AppUser>
  {
    DbSet<Address> Addresses { get; set; }
    DbSet<Contact> Contacts { get; set; }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);


      // Configure User
      modelBuilder.Entity<AppUser>(entity =>
      {
        entity.HasMany(user => user.Contacts)
              .WithOne(contact => contact.User);
      });

      // Configure Contacts
      modelBuilder.Entity<Contact>(entity =>
      {
        entity
              .HasMany(contact => contact.Addresses)
              .WithOne(address => address.Contact);
      });
    }
  }
}
