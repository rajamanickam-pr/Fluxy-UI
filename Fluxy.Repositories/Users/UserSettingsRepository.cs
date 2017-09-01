using Fluxy.Repositories.Common;
using System.Data.Entity;
using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Repositories.Users
{
    public class UserSettingsRepository : GenericRepository<UserSettingsExtend>, IUserSettingsRepository
    {
        public UserSettingsRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
