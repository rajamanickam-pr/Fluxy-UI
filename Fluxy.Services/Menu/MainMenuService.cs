using Fluxy.Core.Models.Menu;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Menu
{
    public class MainMenuService : EntityService<MainMenu>, IMainMenuService
    {
        public MainMenuService(IUnitOfWork unitOfWork, IGenericRepository<MainMenu> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
