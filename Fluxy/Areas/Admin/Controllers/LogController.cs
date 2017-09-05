using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    public class LogController : BaseController
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        public LogController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        // GET: Admin/Log
        public ActionResult Index()
        {
            var exceptionsDto=_logService.GetAll();
            var exceptions = _mapper.Map<List<LogViewModel>>(exceptionsDto);
            return View(exceptions);
        }

        public JsonResult GetbyID(string id)
        {
            var logDto = _logService.GetSingle(i => i.Id == id);
            var log = _mapper.Map<LogViewModel>(logDto);
            return Json(log, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var logDto = _logService.GetSingle(i => i.Id == id);
                if (logDto != null)
                {
                    _logService.Delete(logDto);
                    status = true;
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}