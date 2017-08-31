using Fluxy.Core.Models.Users;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Users
{
    public class UserSettingsService : EntityService<UserSettings>, IUserSettingsService
    {
        public UserSettingsService(IUnitOfWork unitOfWork, IGenericRepository<UserSettings> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
