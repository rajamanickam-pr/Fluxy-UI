using Fluxy.Core.Models.Mail;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Data.ExtentedDTO
{
    public class NewsletterExtend:Newsletter
    {
        public string UserId { get; set; }
        [ForeignKey("UserId"), Column(Order = 2)]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
