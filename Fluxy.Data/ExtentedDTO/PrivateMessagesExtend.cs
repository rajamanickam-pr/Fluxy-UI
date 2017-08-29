using Fluxy.Core.Models.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.ExtentedDTO
{
    public class PrivateMessagesExtend:PrivateMessage
    {
        public string FromUserId { get; set; }
        [ForeignKey("FromUserId"), Column(Order = 1)]
        public virtual ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }
        [ForeignKey("ToUserId"), Column(Order = 2)]
        public virtual ApplicationUser ToUser { get; set; }
    }
}
