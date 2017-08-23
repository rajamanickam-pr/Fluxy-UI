using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
