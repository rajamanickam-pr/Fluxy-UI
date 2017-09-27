using System.Web.Mvc;
using AutoMapper;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;
using System;

namespace Fluxy.Controllers
{
    [RoutePrefix("errorhandler")]
    public class ErrorHandlerController : BaseController
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ErrorHandlerController(ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        // GET: ErrorHandler
        [Route("{exceptionId}")]
        public ActionResult Index(string exceptionId)
        {
            if (string.IsNullOrEmpty(exceptionId))
                throw new ArgumentNullException("exceptionId is null or empty");
            var log = _logService.GetSingle(i => i.Id == exceptionId);
            var logViewModel = _mapper.Map<LogViewModel>(log);
            return View(logViewModel);
        }
    }
}