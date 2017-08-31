using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Menu
{
    public class MenuAttributeViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string AttributeKey { get; set; }
        [Required]
        public string AttributeValue { get; set; }
    }
}