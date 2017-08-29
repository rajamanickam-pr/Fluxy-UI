using Fluxy.Core.Models.Logging;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Logging
{
    public class LogService : EntityService<Log>, ILogService
    {
        public LogService(IUnitOfWork unitOfWork, IGenericRepository<Log> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
