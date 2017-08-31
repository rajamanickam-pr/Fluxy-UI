using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Categories
{
    public class CategoryViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}