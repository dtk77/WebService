namespace WebService
{
    public class SendSettings
    {
        public string MailKitFromName { get; set; } = String.Empty;
        public string MailKitFromAddress { get; set; } = String.Empty;
        public string MailKitLocalDomain { get; set; } = String.Empty;
        public string MailKitUsername { get; set; } = String.Empty;
        public string MailKitPassword { get; set; } = String.Empty;
        public string MailKitSecureSocketOption { get; set; } = String.Empty;
        public string MailKitHost { get; set; } = String.Empty;
        public int MailKitPort { get; set; } = 465;
    }
}
