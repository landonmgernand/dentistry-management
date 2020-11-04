using System.Text.RegularExpressions;

namespace DentistryManagement.Server.Helpers
{
    public class PasswordChecker
    {
        public static bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input) || !hasUpperChar.IsMatch(input) || !hasNumber.IsMatch(input) || !hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower, one upper case letter, one numeric value and one special case character";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
