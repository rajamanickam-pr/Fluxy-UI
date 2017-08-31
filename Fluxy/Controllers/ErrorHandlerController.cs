using Fluxy.Core.Models.Logging;
using Fluxy.ViewModels.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index(Log log)
        {
            return View();
        }
    }
}