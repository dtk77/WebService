using System.ComponentModel.DataAnnotations;
using WebService.Infrastructure.CustomAttributes;

namespace WebService.ApplicationCore.Entity
{
    /// <summary>
    /// This class is used for binding and valid the request body (JSON)
    /// </summary>
    public class RequestToSendMail : MailForTask
    {
        [ListIsNotEmpty]
        public List<string> Recipients { get; set; }
    }
}


