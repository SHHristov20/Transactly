using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactly.Core.DTOs
{
    public class CreateAccountDTO
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
    }

    public class DepositFundsDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public string CardNumber { get; set; } = null!;
        public string ExpiryDate { get; set; } = null!;
        public string CVV { get; set; } = null!;
    }
}
