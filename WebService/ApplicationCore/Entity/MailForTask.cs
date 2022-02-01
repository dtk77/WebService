using System.ComponentModel.DataAnnotations;

namespace WebService.ApplicationCore.Entity
{
    /// <summary>
    /// This abstract class base entity for other..
    /// </summary>
    public abstract class MailForTask
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } = String.Empty;

        [Required]
        public string Body { get; set; } = String.Empty;
    }
}
