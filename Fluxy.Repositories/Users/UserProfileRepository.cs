using Fluxy.Core.Models.Users;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
