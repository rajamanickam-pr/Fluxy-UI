using Fluxy.Core.Models.Mail;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Mail
{
    public class ContactUsRepository : GenericRepository<ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
