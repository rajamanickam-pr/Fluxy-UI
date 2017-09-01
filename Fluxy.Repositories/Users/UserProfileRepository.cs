using Fluxy.Repositories.Common;
using System.Data.Entity;
using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Repositories.Users
{
    public class UserProfileRepository : GenericRepository<UserProfileExtend>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context)
            : base(context)
        {
        }
    }
}
