using Fluxy.Core.Models.Logging;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;

namespace Fluxy.Controllers
{
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
        public ActionResult Index(string exceptionId)
        {
            var log = _logService.GetSingle(i => i.Id == exceptionId);
            var logViewModel = _mapper.Map<LogViewModel>(log);
            return View(logViewModel);
        }
    }
}