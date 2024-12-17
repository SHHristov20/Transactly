using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class CardService(IBaseRepository repository, CardRepository cardRepository) : BaseService(repository), ICardService
    {
        private readonly CardRepository _cardRepository = cardRepository;

        public async Task<Card?> GetCardByNumber(string cardNumber)
        {
            return await _cardRepository.GetCardByNumber(cardNumber);
        }

        public async Task<bool> Payment(Card card, Account toAccount, decimal amount)
        {
            return await _cardRepository.Payment(card, toAccount, amount);
        }

        public async Task<bool> Payment(Card card, Account toAccount, decimal amount, decimal convertedAmount)
        {
            return await _cardRepository.Payment(card, toAccount, amount, convertedAmount);
        }

        public async Task<Card?> GetCardByAccountId(int accountId)
        {
            return await _cardRepository.GetCardByAccountId(accountId);
        }
    }
}