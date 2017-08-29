using Fluxy.Core.Models.Menu;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Menu
{
    public class MenuAttributeService : EntityService<MenuAttribute>, IMenuAttributeService
    {
        public MenuAttributeService(IUnitOfWork unitOfWork, IGenericRepository<MenuAttribute> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
