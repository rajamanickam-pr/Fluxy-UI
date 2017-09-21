using AutoMapper;
using Fluxy.Core.Constants.UserQueries;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.Services.Mail;
using Fluxy.ViewModels.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("userquries")]
    public class UserQueriesController : BaseController
    {
        private readonly ILogService _logService;
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public UserQueriesController(ILogService logService, IMapper mapper, IContactUsService contactUsService)
            : base(logService, mapper)
        {
            _logService = logService;
            _mapper = mapper;
            _contactUsService = contactUsService;
        }

        // GET: UserQueries
        [HttpGet]
        [Route("", Name = UserQueriesControllerRoute.GetIndex)]
        public async Task<ActionResult> Index()
        {
            var quries =await _contactUsService.GetAllAsync();
            var quriesVM = _mapper.Map<IEnumerable<ContactUsViewModel>>(quries.OrderByDescending(i=>i.CreatedDate));
            return View(UserQueriesControllerAction.Index, quriesVM);
        }

        [HttpGet]
        [Route("Details", Name = UserQueriesControllerRoute.GetDetails)]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quries = await _contactUsService.GetSingleAsync(i => i.Id == id);
            if (quries == null)
            {
                return HttpNotFound();
            }
            var quriesVM = _mapper.Map<ContactUsViewModel>(quries);
            return View(UserQueriesControllerAction.Details, quriesVM);
        }

        [HttpGet]
        [Route("Delete", Name = UserQueriesControllerRoute.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quriesDto = await _contactUsService.GetSingleAsync(i => i.Id == id);
            var quriesViewModel = _mapper.Map<ContactUsViewModel>(quriesDto);
            if (quriesViewModel == null)
            {
                return HttpNotFound();
            }
            await _contactUsService.DeleteAsync(quriesDto);
            return RedirectToAction(UserQueriesControllerAction.Index);
        }
    }
}