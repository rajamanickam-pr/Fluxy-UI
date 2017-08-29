using Fluxy.Core.Mvc.Controllers;
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
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : BaseController
    {
        public AdminHomeController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
        }

        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}