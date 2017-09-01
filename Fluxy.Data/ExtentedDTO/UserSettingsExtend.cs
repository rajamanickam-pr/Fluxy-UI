using Fluxy.Core.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Data.ExtentedDTO
{
    public class UserSettingsExtend : UserSettings
    {
        public string UserId { get; set; }
        [ForeignKey("UserId"), Column(Order = 2)]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
