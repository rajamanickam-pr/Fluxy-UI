using Fluxy.Core.Models.Localization;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Localization
{
    public class LanguageService : EntityService<Language>, ILanguageService
    {
        public LanguageService(IUnitOfWork unitOfWork, IGenericRepository<Language> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
