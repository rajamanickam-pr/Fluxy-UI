using Fluxy.Core.Models.Logging;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
