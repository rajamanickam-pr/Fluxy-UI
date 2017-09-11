using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.ViewModels.Mail
{
    public class NewsletterViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Subscription { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Data.ApplicationUser ApplicationUser { get; set; }
        public bool Active { get; set; }
    }
}