using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Users
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        public UsersController(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // Login
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]string email, [FromBody]string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Invalid email or password");
        }

        // Logout
        [HttpGet]
        public async void Logout() => await signInManager.SignOutAsync();

        // Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegistrationDto registration)
        {
            var user = new User { Email = registration.Email };
            var result = await userManager.CreateAsync(user, registration.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        // DeleteAccount
    }
}
