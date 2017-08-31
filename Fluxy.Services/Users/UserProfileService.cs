using Fluxy.Data.ExtentedDTO;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Users
{
    public class UserProfileService : EntityService<UserProfileExtend>, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IGenericRepository<UserProfileExtend> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
