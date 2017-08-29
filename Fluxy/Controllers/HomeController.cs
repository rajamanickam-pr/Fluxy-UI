using Fluxy.Core.Mvc.Controllers;
using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

namespace Fluxy.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogService logService, IMapper mapper) 
            : base(logService, mapper)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}