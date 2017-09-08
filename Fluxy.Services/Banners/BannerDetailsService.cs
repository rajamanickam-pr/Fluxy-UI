using Fluxy.Core.Models.Banners;
using Fluxy.Repositories.Common;
using Fluxy.Services.Common;

namespace Fluxy.Services.Banners
{
    public class BannerDetailsService:EntityService<BannerDetails>, IBannerDetailsService
    {
        public BannerDetailsService(IUnitOfWork unitOfWork, IGenericRepository<BannerDetails> repository) 
            : base(unitOfWork, repository)
        {
        }
    }
}
