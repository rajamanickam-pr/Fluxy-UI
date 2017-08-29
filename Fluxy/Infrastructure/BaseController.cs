using AutoMapper;
using Fluxy.Core.Models.Logging;
using Fluxy.Core.Mvc.Controllers;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Infrastructure
{
    public class BaseController : BaseAlertController
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public BaseController(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var log = new LogViewModel
            {
                FullMessage = filterContext.Exception.Message,
                ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString(),
                Method = filterContext.Exception.TargetSite.Name,
                ExceptionStackTrace = filterContext.Exception.StackTrace,
                LogLevelId = (int)LogLevel.Error,
                LogTime = DateTime.UtcNow,
                ApplicationObject = filterContext.Exception.Source,
                HelpLink = filterContext.Exception.HelpLink,
                InnerException = filterContext.Exception.InnerException?.Message
            };
            var logDto = _mapper.Map<Log>(log);
            _logService.Create(logDto);
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        }
    }
}