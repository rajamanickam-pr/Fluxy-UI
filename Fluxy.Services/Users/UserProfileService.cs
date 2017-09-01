using Fluxy.Data.ExtentedDTO;
using Fluxy.Services.Common;
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
