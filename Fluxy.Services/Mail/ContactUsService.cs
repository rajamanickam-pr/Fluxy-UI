using Fluxy.Core.Models.Mail;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Mail
{
    public class ContactUsService : EntityService<ContactUs>, IContactUsService
    {
        public ContactUsService(IUnitOfWork unitOfWork, IGenericRepository<ContactUs> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
