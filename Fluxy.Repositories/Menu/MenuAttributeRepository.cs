using Fluxy.Core.Models.Menu;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Fluxy.Repositories.Menu
{
    public class MenuAttributeRepository : GenericRepository<MenuAttribute>, IMenuAttributeRepository
    {
        public MenuAttributeRepository(DbContext context)
            : base(context)
        {
        }
    }
}
