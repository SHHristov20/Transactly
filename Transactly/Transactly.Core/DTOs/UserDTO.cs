using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactly.Core.DTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UpdateUserDTO
    {
        public Guid Token { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserTag { get; set; } = null!;
    }
}
