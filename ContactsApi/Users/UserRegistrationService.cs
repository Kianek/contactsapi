using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ContactsApi.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private UserManager<User> userManager;

        public UserRegistrationService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        // Attempt to create a new user, and return the result.
        public async Task<IdentityResult> Register(UserRegistrationDto user)
        {
            // TODO: Add logger.
            var newUser = new User { Email = user.Email };
            var result = await userManager.CreateAsync(newUser, user.Password);
            return result;
        }

        // TODO: Remove a user.
    }
}
