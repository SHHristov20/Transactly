using System.ComponentModel.DataAnnotations;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class Card : IBaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; } = null!;

        [Required]
        [StringLength(5)]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [StringLength(3)]
        public string CVV { get; set; } = null!;

        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
    }
}
