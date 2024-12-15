using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Models
{
    public class Currency : IBaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CurrencyName { get; set; } = null!;

        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; } = null!;

        [StringLength(3)]
        public string CurrencySymbol { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ExchangeRate> ExchangeRates { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ExchangeRate> ExchangeCurrencyRates { get; set; } = null!;
    }
}
