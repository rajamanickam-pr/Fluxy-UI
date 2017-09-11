using Fluxy.Data.ExtentedDTO;
using Fluxy.Repositories.Common;
using Fluxy.Services.Common;

namespace Fluxy.Services.Mail
{
    public class NewsletterService : EntityService<NewsletterExtend>, INewsletterService
    {
        public NewsletterService(IUnitOfWork unitOfWork, IGenericRepository<NewsletterExtend> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
