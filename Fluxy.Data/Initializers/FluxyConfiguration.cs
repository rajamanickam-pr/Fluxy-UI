using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Initializers
{
    internal sealed class Configuration : DbMigrationsConfiguration<FluxyContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(FluxyContext context)
        {
            base.Seed(context);
        }
    }
}
