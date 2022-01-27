using System.ComponentModel.DataAnnotations;
using WebService.Infrastructure.CustomAttributes;

namespace WebService.ApplicationCore.Entity
{
    public class RequestToSendMail 
    {
        [Required]
        public int Id { get; set; }

       [Required]
        public string Subject { get; set; } = String.Empty;

        [Required]
        public string Body { get; set; } = String.Empty;

        [ListIsNotEmpty]
        public List<string> Recipients { get; set; }
    }
}


