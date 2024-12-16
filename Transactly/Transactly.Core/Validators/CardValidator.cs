using System;
using System.Globalization;

namespace Transactly.Core.Validators
{
    public static class CardValidator
    {
        public static bool IsValidCreditCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");
            if (!long.TryParse(cardNumber, out _) || cardNumber.Length < 13 || cardNumber.Length > 19)
            {
                return false;
            }

            int sum = 0;
            bool shouldDouble = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                if (shouldDouble)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                shouldDouble = !shouldDouble;
            }

            return sum % 10 == 0;
        }

        public static bool IsValidExpiryDate(string expiryDate)
        {
            DateTime expiry;
            if (!DateTime.TryParseExact(expiryDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiry))
            {
                return false;
            }

            DateTime currentDate = DateTime.Now;

            if (expiry.Month < currentDate.Month && expiry.Year <= currentDate.Year)
            {
                return false;
            }

            return true;
        }

        public static string GenerateValidCardNumber()
        {
            string cardNumber = GenerateRandomDigits(15);
            int checksum = CalculateLuhnChecksum(cardNumber);
            cardNumber += checksum.ToString();
            return cardNumber;
        }

        public static string GenerateRandomDigits(int length)
        {
            Random random = new();
            char[] digits = new char[length];

            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)('0' + random.Next(0, 10));
            }

            return new string(digits);
        }

        private static int CalculateLuhnChecksum(string number)
        {
            int sum = 0;
            bool shouldDouble = false;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());
                if (shouldDouble)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;
                }

                sum += digit;
                shouldDouble = !shouldDouble;
            }

            int checksum = (10 - (sum % 10)) % 10;
            return checksum;
        }
    }

}
