
using System.ComponentModel.DataAnnotations;
using WebService.Infrastructure.CustomAttributes;

namespace WebService.ApplicationCore.Entity
{
    public class RequestToSendMail 
    {
        public int Id { get; set; }

       [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [ListIsNotEmpty]
        public List<string> Recipients { get; set; }
    }
}


