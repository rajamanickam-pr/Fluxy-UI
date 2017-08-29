using Fluxy.Core.Models.Common;
using Fluxy.Repositories.Common;
using System.Data.Entity;

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
