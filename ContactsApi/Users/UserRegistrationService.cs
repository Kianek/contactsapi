using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ContactsApi.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private UserManager<AppUser> userManager;

        public UserRegistrationService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // Attempt to create a new user, and return the result.
        public async Task<IdentityResult> Register(UserRegistrationDto user)
        {
            // TODO: Add logger.
            var newUser = new AppUser { UserName = user.UserName, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email};
            var result = await userManager.CreateAsync(newUser, user.Password);
            return result;
        }

        public async Task<IdentityResult> Delete(UserRegistrationDto user)
        {
            // Find the user to delete.
            var userToDelete = await userManager.FindByEmailAsync(user.Email);

            // Attempt to remove the user's account from the DB.
            var result = await userManager.DeleteAsync(userToDelete);

            return result;
        }
    }
}
