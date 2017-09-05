using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
