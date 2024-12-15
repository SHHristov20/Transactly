using System.ComponentModel.DataAnnotations;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class User : IBaseModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
    }
}
