using System.Data.Entity;
using Fluxy.Core.Models.Banners;
using Fluxy.Repositories.Common;

namespace Fluxy.Repositories.Banners
{
    public class BannerDetailsRepository:GenericRepository<BannerDetails>, IBannerDetailsRepository
    {
        public BannerDetailsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
