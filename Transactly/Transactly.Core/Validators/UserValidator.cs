using System.Text.RegularExpressions;

namespace Transactly.Core.Validators
{
    public static class UserValidator
    {
        public static bool ValidateName(string name)
        {
            string pattern = @"^[a-zA-Z-' ]+$";

            Regex regex = new(pattern);

            return regex.IsMatch(name);
        }

        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new(pattern);

            return regex.IsMatch(email);
        }

        public static bool ValidatePassword(string password)
        {
            string pattern = @"^.{8,}$";

            Regex regex = new(pattern);

            return regex.IsMatch(password);
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+[0-9]{1,3})?[0-9]{9,12}$";
            Regex regex = new(pattern);
            return regex.IsMatch(phoneNumber);
        }
        public static bool PasswordsMatch(string password, string repeatPassword)
        {
            return password == repeatPassword;
        }

        public static string GenerateUserTag(string firstName)
        {
            string firstFourLetters = firstName.Length >= 4 ? firstName.Substring(0, 4) : firstName.PadRight(4, 'x');
            Random random = new();
            int randomNumbers = random.Next(1000, 10000);
            return firstFourLetters.ToLower() + randomNumbers.ToString();
        }
    }
}
