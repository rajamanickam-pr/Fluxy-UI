using System.Data.Entity;

namespace Fluxy.Data.Initializers
{
    public class FluxyDbInitializer : CreateDatabaseIfNotExists<FluxyContext>
    {
        protected override void Seed(FluxyContext context)
        {
            base.Seed(context);
        }
    }
}
