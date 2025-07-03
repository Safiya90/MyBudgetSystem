using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.DTOs;
using MyBudgetAPI.Models;

namespace MyBudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

       
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if the email is already used
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
                return BadRequest("Email is already in use.");

            // Create user manually
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Assign default role
             //in case we want to add user role
            //await _userManager.AddToRoleAsync(user, "User");

            return Ok("User registered successfully.");
        }



        //for login 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized("Invalid login attempt");

            // if user account is locked 
            if (await _userManager.IsLockedOutAsync(user))
                return Unauthorized("Your account is locked. Please try again later.");

            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true  // system will let you try few times then it will lock 
            );  // it will create cookie 

            if (!result.Succeeded)
                return Unauthorized("Invalid login attempt");

            return Ok("User logged in successfully");
        }



        //logout 

        [HttpPost("logout")]
        [Authorize]  // you should be login to do  logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();  // delete the cookies and stop the session after logout 

            return Ok("Logged out successfully");
        }




    }

}

