using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ContactsApi.Users
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private IUserService userService;
        private IUserRegistrationService registrationService;

        public UsersController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserService userService,
            IUserRegistrationService registrationService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.registrationService = registrationService;
        }

        // Login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLoginDto loginDto)
        {
            // TODO: convert the user to a UserDto
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

            if (result.Succeeded)
            {
                var formattedUser = userService.ConvertToDtoFromUser(user);
                return Ok(formattedUser);
            }
            return BadRequest(new { Message = "Invalid email or password" });
        }

        // Logout
        [HttpGet]
        public async void Logout() => await signInManager.SignOutAsync();

        // Register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationDto newUser)
        {
            //var user = new User { UserName = registration.Username, Email = registration.Email };
            //var result = await userManager.CreateAsync(user, registration.Password);
            var result = await registrationService.Register(newUser);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Account created" });
            }

            return BadRequest(result.Errors);
        }

        // DeleteAccount
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]UserRegistrationDto userToDelete)
        {
            var user = await userManager.FindByEmailAsync(userToDelete.Email);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                return Ok("Account Deleted");
            }

            return BadRequest("Unable to delete account");
        }
    }
}
