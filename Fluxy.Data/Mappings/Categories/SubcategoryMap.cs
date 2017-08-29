﻿using Fluxy.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Mappings.Categories
{
    public class SubcategoryMap:FluxyEntityTypeConfiguration<SubCategory>
    {
        public SubcategoryMap()
        {
            this.ToTable("Subcategory");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(100);
            this.Property(sm => sm.Description).HasMaxLength(200);
        }
    }
}