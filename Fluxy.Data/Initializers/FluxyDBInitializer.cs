using Fluxy.Core.Models.Categories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Fluxy.Data.Initializers
{
    public class FluxyDBInitializer : DropCreateDatabaseIfModelChanges<FluxyContext>
    {
        protected override void Seed(FluxyContext context)
        {
            IList<Category> defaultCategory = new List<Category>
            {
                new Category { Name = "Autos and Vehicles", Description = "Category for Auto and Vehicles videos" },
                new Category { Name = "Film & Animation", Description = "Category for Film & Animation videos" },
                new Category { Name = "Music", Description = "Category for Music videos" },
                new Category { Name = "Sports", Description = "Category for Sports videos" },
                new Category { Name = "Pets & Animals", Description = "Category for Pets & Animals videos" },
                new Category { Name = "Short Movies", Description = "Category for Short Movies videos" },
                new Category { Name = "Travel & Events", Description = "Category for Travel & Events videos" },
                new Category { Name = "Gaming", Description = "Category for Gaming videos" },
                new Category { Name = "People & Blogs", Description = "Category for People & Blogs videos" },
                new Category { Name = "Comedy", Description = "Category for Comedy videos" },
                new Category { Name = "Entertainment", Description = "Category for Entertainment videos" },
                new Category { Name = "News & Politics", Description = "Category for News & Politics videos" },
                new Category { Name = "Education", Description = "Category for Education videos" },
                new Category { Name = "Science & Technology", Description = "Category for Science & Technology videos" },
                new Category { Name = "Movies", Description = "Category for Movies videos" },
                new Category { Name = "Devotional", Description = "Category for Devotional videos" }
            };

            foreach (Category std in defaultCategory)
                context.Set<Category>().Add(std);

            base.Seed(context);
        }
    }
}
