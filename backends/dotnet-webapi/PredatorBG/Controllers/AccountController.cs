using System;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using WebAPI.PredatorBG.Dto;
using WebAPI.PredatorBG.Models;

namespace WebAPI.PredatorBG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //api/Account/Register
        [HttpPost]
        [Route("Register")]
        public async Task<Object> Register(RegisterDto register)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = register.UserName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, register.Password);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/Account/Login
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            var user = await _userManager.FindByNameAsync(login.UserName);

            if (result.Succeeded)
            {
                await _userManager.UpdateAsync(user);
                return Ok();
            }

            return Unauthorized("Login failed!");
        }

        [HttpPost]
        [Route("Logout")]
        //POST : /api/Account/Logout
        public async Task<IActionResult> Logout([FromBody] JsonElement body)
        {
            string data = JsonSerializer.Serialize(body);
            string name = JObject.Parse(data)["UserName"].ToString();
            var user = await _userManager.FindByNameAsync(name);
            await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();
            return Ok();
        }

    }
}
