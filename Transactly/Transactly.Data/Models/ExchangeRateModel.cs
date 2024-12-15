using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class ExchangeRate : IBaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        [Required]
        public int ExchangeCurrencyId { get; set; }
        public Currency ExchangeCurrency { get; set; } = null!;
    }
}
