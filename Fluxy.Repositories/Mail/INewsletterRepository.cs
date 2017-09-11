using Fluxy.Data.ExtentedDTO;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Repositories.Mail
{
    public interface INewsletterRepository: IGenericRepository<NewsletterExtend>
    {
    }
}
