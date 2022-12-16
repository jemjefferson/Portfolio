using System.ComponentModel.DataAnnotations;

namespace JordanJeffersonPortfolio.Models
{
    public class Email
    {
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
