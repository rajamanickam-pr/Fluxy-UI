using Fluxy.Core.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AttributeController : BaseController
    {
        // GET: Admin/Attribute
        public ActionResult Index()
        {
            return View();
        }
    }
}