﻿using System.Collections.Generic;
using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Categories
{
    public class Category : AuditableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
