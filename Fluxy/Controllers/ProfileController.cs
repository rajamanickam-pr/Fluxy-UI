using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

namespace Fluxy.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}