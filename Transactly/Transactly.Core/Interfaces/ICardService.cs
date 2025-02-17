﻿using Transactly.Data.Models;

namespace Transactly.Core.Interfaces
{
    public interface ICardService : IBaseService
    {
        Task<Card?> GetCardByNumber(string cardNumber);
        Task<bool> Payment(Card card, Account toAccount, decimal amount);
        Task<bool> Payment(Card card, Account toAccount, decimal amount, decimal convertedAmount);
        Task<Card?> GetCardByAccountId(int accountId);
    }
}
