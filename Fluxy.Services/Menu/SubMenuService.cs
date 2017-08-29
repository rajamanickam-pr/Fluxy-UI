using Fluxy.Core.Models.Menu;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Menu
{
    public class SubMenuService : EntityService<SubMenu>, ISubMenuService
    {
        public SubMenuService(IUnitOfWork unitOfWork, IGenericRepository<SubMenu> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
