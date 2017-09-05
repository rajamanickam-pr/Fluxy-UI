using Fluxy.Core.Models.Categories;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Categories
{
    public class SubCategoryService : EntityService<SubCategory>, ISubCategoryService
    {
        public SubCategoryService(IUnitOfWork unitOfWork, IGenericRepository<SubCategory> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
