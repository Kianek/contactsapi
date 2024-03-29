﻿using ContactsApi.Addresses;
using ContactsApi.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Users
{
  public class UserDto
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }

    public UserDto(AppUser user)
    {
      Id = user.Id;
      FirstName = user.FirstName;
      LastName = user.LastName;
      Contacts = user.Contacts;
    }

    public UserDto(string id, string firstName, string lastName, IEnumerable<Contact> contacts)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Contacts = contacts;
    }

    public UserDto() { }
  }
}
