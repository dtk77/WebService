using System.ComponentModel.DataAnnotations;

namespace WebService.ApplicationCore.Entity
{
    public class Recipient
    {
        [RegularExpression(@"[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "The field one or more email adress")]
        public string Mail { get; set; } = String.Empty;
    }
}