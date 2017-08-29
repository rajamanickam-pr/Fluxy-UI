using Fluxy.Core.Models.Logging;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Fluxy.Repositories.Logging
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
