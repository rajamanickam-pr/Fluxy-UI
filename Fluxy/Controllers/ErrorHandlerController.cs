using Fluxy.Core.Models.Logging;
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