using Fluxy.Data.ExtentedDTO;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Fluxy.Repositories.Mail
{
    public class NewsletterRepository : GenericRepository<NewsletterExtend>, INewsletterRepository
    {
        public NewsletterRepository(DbContext context) : base(context)
        {
        }
    }
}
