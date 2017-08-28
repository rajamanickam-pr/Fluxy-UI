using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Menu
{
    public class MenuAttributeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
    }
}