using Fluxy.Repositories.Common;
using System.Data.Entity;
using Fluxy.Core.Models.Categories;

namespace Fluxy.Repositories.Categories
{
    class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
