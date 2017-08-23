using System.Data.Entity.Migrations;

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
