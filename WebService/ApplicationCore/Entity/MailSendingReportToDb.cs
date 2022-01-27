﻿namespace WebService.ApplicationCore.Entity
{
    /// <summary>
    /// This class generates a report on
    /// the result of sending emails.
    /// </summary>
    public class MailSendingReportToDb
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string? FailedMessage { get; set; } = null;
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }

       

        public MailSendingReportToDb() {}

        public MailSendingReportToDb(int id, DateTime date, string result, string? failedMessage, string subject, string body, string recipient)
        {
            Id = id;
            Date = date;
            Result = result;
            FailedMessage = failedMessage;
            Subject = subject;
            Body = body;
            Recipient = recipient;
        }
    }

}


