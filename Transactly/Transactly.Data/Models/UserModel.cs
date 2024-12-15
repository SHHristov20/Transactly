using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
        public string UserTag { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        public Guid SessionToken { get; set; }
        public DateTime TokenExpiry { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; } = null!;
    }
}
