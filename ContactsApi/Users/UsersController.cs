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
        private SignInManager<AppUser> signInManager;
        private UserManager<AppUser> userManager;
        private IUserService userService;
        private IUserRegistrationService registrationService;

        public UsersController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IUserService userService,
            IUserRegistrationService registrationService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.registrationService = registrationService;
        }

        // POST - api/users/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    var formattedUser = userService.ConvertToDtoFromUser(user);
                    return Ok(formattedUser);
                }
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
            if (newUser == null)
            {
                return BadRequest(new { Message = "Not enough information" });
            }

            var result = await registrationService.Register(newUser);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Account created" });
            }

            return BadRequest(result.Errors);
        }

        // DeleteAccount
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]UserRegistrationDto userToDelete)
        {
            if (userToDelete == null)
            {
                return BadRequest(new { Message = "Not enough information" });
            }

            var user = await userManager.FindByEmailAsync(userToDelete.Email);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "Account Deleted" });
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    return BadRequest(new { Errors = errors });
                }
            }

            return BadRequest(new { Message = "Unable to delete account" });
        }
    }
}
