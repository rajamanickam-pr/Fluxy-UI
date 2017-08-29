using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    public class VideoAttributesController : BaseController
    {
        public VideoAttributesController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
        }

        // GET: Admin/VideoAttributes
        public ActionResult Index()
        {
            return View();
        }
    }
}