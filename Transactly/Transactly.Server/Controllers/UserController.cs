using Microsoft.AspNetCore.Mvc;
using Transactly.Core.Interfaces;
using Transactly.Core.DTOs;
using Transactly.Data.Models;
using Transactly.Core.Validators;
using Transactly.Core.Services;

namespace Transactly.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost(Name = "CreateUser")]

        public async Task<IActionResult> Create([FromBody] CreateUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "User data is required!", errorCode = 400 });
            }
            if(UserValidator.ValidateName(model.FirstName) == false)
            {
                return BadRequest(new { message = "Invalid first name!", errorCode = 400 });
            }
            if (UserValidator.ValidateName(model.LastName) == false)
            {
                return BadRequest(new { message = "Invalid last name!", errorCode = 400 });
            }
            if (UserValidator.ValidateEmail(model.Email) == false)
            {
                return BadRequest(new { message = "Invalid email!", errorCode = 400 });
            }
            if (UserValidator.ValidatePhoneNumber(model.PhoneNumber) == false)
            {
                return BadRequest(new { message = "Invalid phone number!", errorCode = 400 });
            }
            if (UserValidator.ValidatePassword(model.Password) == false)
            {
                return BadRequest(new { message = "Password must contain atleast 8 characters!", errorCode = 400 });
            }
            if (await _userService.GetUserByEmail(model.Email) != null)
            {
                return BadRequest(new { message = "Email already exists!", errorCode = 400 });
            }
            if (await _userService.GetUserByPhoneNumber(model.PhoneNumber) != null)
            {
                return BadRequest(new { message = "Phone number already exists!", errorCode = 400 });
            }
            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserTag = UserValidator.GenerateUserTag(model.FirstName),
                PasswordHash = PasswordValidator.HashPassword(model.Password),
            };
            bool result = await _userService.Create<User>(user);
            if (result)
            {
                return Ok();
            }
            return BadRequest(new { message = "Failed to create user!", errorCode = 500 });
        }
    }
}
