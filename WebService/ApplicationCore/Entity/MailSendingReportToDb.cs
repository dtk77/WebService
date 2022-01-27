namespace WebService.ApplicationCore.Entity
{
    public class MailSendingReportToDb
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
    }


}


