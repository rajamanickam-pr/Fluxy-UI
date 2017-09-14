namespace Fluxy.Data.Migrations
{
    using Fluxy.Core.Models.Categories;
    using Fluxy.Core.Models.Localization;
    using Fluxy.Core.Models.Video;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fluxy.Data.FluxyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Fluxy.Data.FluxyContext context)
        {
            IList<Category> defaultCategory = new List<Category>
            {
                new Category { Name = "Autos and Vehicles", Description = "Category for Auto and Vehicles videos" },
                new Category { Name = "Film & Animation", Description = "Category for Film & Animation videos" },
                new Category { Name = "Music", Description = "Category for Music videos" },
                new Category { Name = "Sports", Description = "Category for Sports videos" },
                new Category { Name = "Pets & Animals", Description = "Category for Pets & Animals videos" },
                new Category { Name = "Travel & Events", Description = "Category for Travel & Events videos" },
                new Category { Name = "Gaming", Description = "Category for Gaming videos" },
                new Category { Name = "People & Blogs", Description = "Category for People & Blogs videos" },
                new Category { Name = "Entertainment", Description = "Category for Entertainment videos" },
                new Category { Name = "News & Politics", Description = "Category for News & Politics videos" },
                new Category { Name = "Education", Description = "Category for Education videos" },
                new Category { Name = "Science & Technology", Description = "Category for Science & Technology videos" },
                new Category { Name = "Health", Description = "Category for Movies videos"},
                new Category { Name = "Devotional", Description = "Category for Devotional videos" },
                new Category { Name = "Documentary", Description = "Category for Devotional videos" }
            };

            foreach (Category std in defaultCategory)
                context.Set<Category>().Add(std);


            IList<Language> defaultLanguage = new List<Language>
            {
                new Language {Name="French",Rtl=false,DefaultCurrency="EUR",LanguageCulture="fr-BE" },
                new Language {Name="English(United Kingdom)",Rtl=false,DefaultCurrency="EUR",LanguageCulture="en-GB" },
                new Language {Name="Hindi",Rtl=false,DefaultCurrency="INR",LanguageCulture="hi-IN"},
                new Language {Name="Telugu",Rtl=false,DefaultCurrency="INR",LanguageCulture="te-IN" },
                new Language {Name="Tamil",Rtl=false,DefaultCurrency="INR",LanguageCulture="ta-IN" },
                new Language {Name="Malayalam",Rtl=false,DefaultCurrency="INR",LanguageCulture="ma-IN" },
                new Language {Name="Kannada",Rtl=false,DefaultCurrency="INR",LanguageCulture="ka-IN" }
            };
            foreach (Language lang in defaultLanguage)
                context.Set<Language>().Add(lang);

            IList<VideoSettings> defaultVideoSettings = new List<VideoSettings>
            {
                new VideoSettings {Name="Half Setting",FrameFilters="?modestbranding=1&rel=0&showinfo=0&fs=0",FrameHeight=380,FrameWidth=720},
            };
            foreach (VideoSettings settings in defaultVideoSettings)
                context.Set<VideoSettings>().Add(settings);

            context.SaveChanges();
        }
    }
}
