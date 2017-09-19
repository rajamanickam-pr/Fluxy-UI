using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;
using Fluxy.Core.Constants.Log;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("log")]
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
        [HttpGet]
        [Route("", Name = LogControllerRoutes.GetIndex)]
        public ActionResult Index()
        {
            var exceptionsDto = _logService.GetAll();
            var exceptions = _mapper.Map<List<LogViewModel>>(exceptionsDto);
            return View(LogControllerAction.Index, exceptions);
        }

        [HttpGet]
        [Route("Details", Name = LogControllerRoutes.GetDetails)]
        public ActionResult Details(string id)
        {
            var logDto = _logService.GetSingle(i => i.Id == id);
            var log = _mapper.Map<LogViewModel>(logDto);
            return View(log);
        }

        [HttpGet]
        [Route("Delete", Name = LogControllerRoutes.GetDelete)]
        public ActionResult Delete(string id)
        {
            try
            {
                var logDto = _logService.GetSingle(i => i.Id == id);
                if (logDto != null)
                {
                    _logService.Delete(logDto);
                }
                return RedirectToAction(LogControllerAction.Index);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}