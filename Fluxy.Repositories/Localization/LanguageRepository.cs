using Fluxy.Core.Models.Localization;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Localization
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
