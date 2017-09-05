using Fluxy.Repositories.Common;
using System.Data.Entity;
using Fluxy.Core.Models.Categories;

namespace Fluxy.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
