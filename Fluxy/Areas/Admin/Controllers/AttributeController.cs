using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AttributeController : BaseController
    {
        public AttributeController(ILogService logService, IMapper mapper) 
            : base(logService, mapper)
        {
        }

        // GET: Admin/Attribute
        public ActionResult Index()
        {
            return View();
        }
    }
}