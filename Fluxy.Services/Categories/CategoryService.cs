using Fluxy.Core.Models.Categories;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Categories
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
