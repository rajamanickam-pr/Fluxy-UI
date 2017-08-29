using Fluxy.Core.Models.Common;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Categories
{
    public class SubCategoryServiceCategory : EntityService<SubCategory>, ISubCategoryService
    {
        public SubCategoryServiceCategory(IUnitOfWork unitOfWork, IGenericRepository<SubCategory> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
