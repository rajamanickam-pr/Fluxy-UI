using Fluxy.Core.Models.Menu;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Menu
{
    public class SubMenuRepository : GenericRepository<SubMenu>, ISubMenuRepository
    {
        public SubMenuRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
