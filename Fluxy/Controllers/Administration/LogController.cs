using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;
using Fluxy.Core.Constants.Log;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            var exceptionsDto =await _logService.GetAllAsync();
            var exceptions = _mapper.Map<List<LogViewModel>>(exceptionsDto);
            return View(LogControllerAction.Index, exceptions);
        }

        [HttpGet]
        [Route("Details", Name = LogControllerRoutes.GetDetails)]
        public async Task<ActionResult> Details(string id)
        {
            var logDto = await _logService.GetSingleAsync(i => i.Id == id);
            var log = _mapper.Map<LogViewModel>(logDto);
            return View(log);
        }

        [HttpGet]
        [Route("Delete", Name = LogControllerRoutes.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var logDto =await _logService.GetSingleAsync(i => i.Id == id);
                if (logDto != null)
                {
                    await _logService.DeleteAsync(logDto);
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