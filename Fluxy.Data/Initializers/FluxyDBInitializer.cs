using Fluxy.Core.Models.Categories;
using Fluxy.Core.Models.Localization;
using Fluxy.Core.Models.Video;
using System.Collections.Generic;
using System.Data.Entity;

namespace Fluxy.Data.Initializers
{
    public class FluxyDBInitializer : CreateDatabaseIfNotExists<FluxyContext>
    {
        protected override void Seed(FluxyContext context)
        {
            base.Seed(context);
        }
    }
}
