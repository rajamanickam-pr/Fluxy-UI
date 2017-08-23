using System.Data.Entity.ModelConfiguration;

namespace Fluxy.Data.Mappings
{
    public abstract class FluxyEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected FluxyEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
