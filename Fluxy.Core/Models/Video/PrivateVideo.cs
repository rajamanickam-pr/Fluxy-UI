using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Video
{
    public class PrivateVideo : AuditableEntity<long>
    {
        public string Message { get; set; }
        public string VideoAttributeId { get; set; }
        [ForeignKey("VideoAttributeId")]
        public virtual VideoAttributes VideoAttributes { get; set; }
    }
}
