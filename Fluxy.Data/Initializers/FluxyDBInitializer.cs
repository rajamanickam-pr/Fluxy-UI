using System.Data.Entity;

namespace Fluxy.Data.Initializers
{
    public class FluxyDBInitializer : DropCreateDatabaseIfModelChanges<FluxyContext>
    {
        protected override void Seed(FluxyContext context)
        {
            base.Seed(context);
        }
    }
}
