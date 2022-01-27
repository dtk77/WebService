namespace WebService.ApplicationCore.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> Send(string toName, string toEmailAddress, string subject, string bodyHtml, string bodyText, int retryCount = 2);
    }
}
