using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Menu
{
    public class MenuAttributeViewModel
    {
        [Key]
        public string Id { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
    }
}