using Fluxy.Core.Models.Menu;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Menu
{
    public class MainMenuRepository : GenericRepository<MainMenu>, IMainMenuRepository
    {
        public MainMenuRepository(DbContext context)
            : base(context)
        {
        }
    }
}
