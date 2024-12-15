using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
        public virtual User User { get; set; } = null!;

        [Required]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Transaction> IncomingTransactions { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Transaction> OutgoingTransactions { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Card> Cards { get; set; } = null!;

    }
}
