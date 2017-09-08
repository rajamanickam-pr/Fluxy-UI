using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Mail
{
    public class ContactUsViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}