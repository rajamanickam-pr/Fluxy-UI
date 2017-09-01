using Fluxy.Services.Common;
using Fluxy.Repositories.Common;
using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Services.Users
{
    public class UserSettingsService : EntityService<UserSettingsExtend>, IUserSettingsService
    {
        public UserSettingsService(IUnitOfWork unitOfWork, IGenericRepository<UserSettingsExtend> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
