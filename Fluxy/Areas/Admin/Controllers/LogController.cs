using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;

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
            return View();
        }
    }
}