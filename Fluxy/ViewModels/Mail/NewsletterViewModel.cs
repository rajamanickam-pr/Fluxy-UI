using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Mail
{
    public class NewsletterViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}