using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class TransactionType : IBaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = null!;
    }
}
