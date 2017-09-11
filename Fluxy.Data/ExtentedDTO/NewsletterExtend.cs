using Fluxy.Core.Models.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.ExtentedDTO
{
    public class NewsletterExtend:Newsletter
    {
        public string UserId { get; set; }
        [ForeignKey("UserId"), Column(Order = 2)]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
