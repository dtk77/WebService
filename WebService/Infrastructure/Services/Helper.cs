using System.Text.RegularExpressions;

namespace WebService.Infrastructure.Services
{
    internal static class Helper
    {
        internal static string CheckValidMailAdress(List<string> recipients)
        {
            string notValidEmails = String.Empty;

            foreach (var recipient in recipients)
            {
                if (!IsValidEmail(recipient))
                    notValidEmails += $"{recipient}; ";
            }

            return notValidEmails.TrimEnd();
        }

        internal static bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
