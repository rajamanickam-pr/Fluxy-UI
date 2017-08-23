using Fluxy.Core.Models.Menu;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
