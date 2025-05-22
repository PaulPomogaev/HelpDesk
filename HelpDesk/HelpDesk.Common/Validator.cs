using System;
using System.Net.Mail;

namespace HelpDesk.Common
{
    public static class Validator
    {
        public static bool IsPasswordValid (string password)
        {
            if (password.Length < 6)
            {
                return false;
            }
            return true;
        }

        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool DoPasswordsMatch(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        public static bool IsLoginValid(string login)
        {
            return !string.IsNullOrWhiteSpace(login) && login.Length >= 3;
        }

        public static bool AreAllFieldsFilled(params string[] fields)
        {
            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsLoginUnique(IProvider provider, string login)
        {
            var users = provider.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
