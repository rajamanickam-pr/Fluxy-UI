using Fluxy.Core.Models.Common;
using Fluxy.Repositories.Common;
using System.Data.Entity;

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
