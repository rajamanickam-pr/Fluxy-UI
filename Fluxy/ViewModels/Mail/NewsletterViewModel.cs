using Fluxy.ViewModels.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
        public string[] SubscriptionArray
        {
            get
            {
                if (!string.IsNullOrEmpty(Subscription))
                {
                    return this.Subscription.Split(',').ToArray();
                }
                return null;
            }
        }
    }
}