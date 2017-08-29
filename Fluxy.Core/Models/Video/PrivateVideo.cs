using Fluxy.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Core.Models.Video
{
    public class PrivateVideo : AuditableEntity<string>
    {
        public string Message { get; set; }
        public string VideoAttributeId { get; set; }
        [ForeignKey("VideoAttributeId")]
        public virtual VideoAttributes VideoAttributes { get; set; }
    }
}
