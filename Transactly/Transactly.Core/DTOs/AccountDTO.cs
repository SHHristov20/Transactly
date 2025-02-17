﻿using System;
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

    public class CreateCardDTO
    {
        public Guid Token { get; set; }
        public int AccountId { get; set; }
    }

    public class TransferFundsDTO
    {
        public Guid Token { get; set; }
        public int FromAccountId { get; set; }
        public string? ToAccountNumber { get; set; } = null!;
        public string? ToEmail { get; set; } = null!;
        public string? ToPhoneNumber { get; set; } = null!;
        public string? ToUserTag { get; set; } = null!;
        public decimal Amount { get; set; }
        public string? Reason { get; set; } = "Transfer";
    }

    public class ExchangeCurrencyDTO
    {
        public Guid Token { get; set; }
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
