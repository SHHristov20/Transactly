using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class Transaction : IBaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Reason { get; set; } = null!;

        [Required]
        public int FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; } = null!;

        [Required]
        public int ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; } = null!;

        [Required]
        public bool Status { get; set; }


        [Required]
        public int TypeId { get; set; }
        public virtual TransactionType Type { get; set; } = null!;
    }
}
