using Transactly.Data.Data.Contexts;
using Transactly.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Transactly.Data.Data.Repositories
{
    public class CardRepository(TransactlyDbContext dbContext) : BaseRepository(dbContext)
    {
        private readonly TransactlyDbContext _dbContext = dbContext;
        public async Task<Card?> GetCardByNumber(string cardNumber)
        {
            return await _dbContext.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
        }
        
        public async Task<bool> Payment(Card card, Account toAccount, decimal amount)
        {
            Transaction transaction = new()
            {
                Amount = amount,
                FromAccount = card.Account,
                ToAccount = toAccount,
                Date = DateTime.Now,
                TypeId = 5
            };
            if (card.Account.Balance < amount)
            {
                transaction.Status = false;
                await Create<Transaction>(transaction);
                return false;
            }
            card.Account.Balance -= amount;
            toAccount.Balance += amount;
            transaction.Status = true;
            await Update<Account>(card.Account);
            await Update<Account>(toAccount);
            await Create<Transaction>(transaction);
            return true;
        }

        public async Task<bool> Payment(Card card, Account toAccount, decimal amount, decimal convertedAmount)
        {
            Transaction transaction = new()
            {
                Amount = amount,
                FromAccount = card.Account,
                ToAccount = toAccount,
                Date = DateTime.Now,
                TypeId = 5
            };
            if (card.Account.Balance < amount)
            {
                transaction.Status = false;
                await Create<Transaction>(transaction);
                return false;
            }
            card.Account.Balance -= amount;
            toAccount.Balance += convertedAmount;
            transaction.Status = true;
            await Update<Account>(card.Account);
            await Update<Account>(toAccount);
            await Create<Transaction>(transaction);
            return true;
        }
    }
}
