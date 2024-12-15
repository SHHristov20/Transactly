using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(1)]
        public string CurrencySymbol { get; set; } = null!;
        
        public ICollection<Account> Accounts { get; set; } = null!;
    }
}
