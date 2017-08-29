using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public SubCategoryController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
            _mapper = mapper;
        }

        // GET: Admin/Language
        public ActionResult Index()
        {
            return View();
        }
    }
}