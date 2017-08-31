using Fluxy.Core.Models.Users;
using Fluxy.Data.ExtentedDTO;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Repositories.Users
{
    public interface IUserProfileRepository : IGenericRepository<UserProfileExtend>
    {
    }
}
