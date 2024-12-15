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

        [HttpPost(Name = "Create")]

        public async Task<IActionResult> Create([FromBody] CreateUserDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "User data is required!", errorCode = 400 });
            }
            if(UserValidator.ValidateName(entity.FirstName) == false)
            {
                return BadRequest(new { message = "Invalid first name!", errorCode = 400 });
            }
            if (UserValidator.ValidateName(entity.LastName) == false)
            {
                return BadRequest(new { message = "Invalid last name!", errorCode = 400 });
            }
            if (UserValidator.ValidateEmail(entity.Email) == false)
            {
                return BadRequest(new { message = "Invalid email!", errorCode = 400 });
            }
            if (UserValidator.ValidatePhoneNumber(entity.PhoneNumber) == false)
            {
                return BadRequest(new { message = "Invalid phone number!", errorCode = 400 });
            }
            if (UserValidator.ValidatePassword(entity.Password) == false)
            {
                return BadRequest(new { message = "Password must contain atleast 8 characters!", errorCode = 400 });
            }
            if (await _userService.GetUserByEmail(entity.Email) != null)
            {
                return BadRequest(new { message = "Email already exists!", errorCode = 400 });
            }
            if (await _userService.GetUserByPhoneNumber(entity.PhoneNumber) != null)
            {
                return BadRequest(new { message = "Phone number already exists!", errorCode = 400 });
            }
            User user = new()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                UserTag = UserValidator.GenerateUserTag(entity.FirstName),
                PasswordHash = PasswordValidator.HashPassword(entity.Password)
            };
            bool result = await _userService.Create<User>(user);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
