namespace WebService.ApplicationCore.Interfaces
{
    public interface IEmailSender
    {
        Task<Tuple<string, string>> Send(string toName, string toEmailAddress, string subject, string bodyHtml, string bodyText, int retryCount = 2);
    }
}
