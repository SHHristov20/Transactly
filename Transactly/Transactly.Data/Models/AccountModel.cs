using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class Account : IBaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string AccountNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; } = 0;

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        public ICollection<Transaction> IncomingTransactions { get; set; } = null!;
        public ICollection<Transaction> OutgoingTransactions { get; set; } = null!;
        public ICollection<Card> Cards { get; set; } = null!;

    }
}
