using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using Fluxy.Data.ExtentedDTO;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Threading.Tasks;
using Fluxy.Services.Localization;
using Fluxy.Services.Categories;
using Fluxy.Core.Constants.VideoManagement;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("videomanagement")]
    public class VideoManagementController : BaseController
    {
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly IVideoSettingsService _videoSettingsService;

        public VideoManagementController(ILogService logService,
            IVideoAttributesService videoAttributesService, IMapper mapper,
            ICategoryService categoryService, ILanguageService languageService,
            IVideoSettingsService videoSettingsService)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
            _categoryService = categoryService;
            _languageService = languageService;
            _videoSettingsService = videoSettingsService;
        }

        // GET: VideoAttributesViewModels
        [HttpGet]
        [Route("", Name = VideoManagementControllerRoutes.GetIndex)]
        public async Task<ActionResult> Index()
        {
            var videosDTO = await _videoAttributesService.GetAllAsync();
            var videos = _mapper.Map<List<VideoAttributesViewModel>>(videosDTO);
            return View(VideoManagementControllerActions.Index, videos);
        }

        // GET: VideoAttributesViewModels/Create
        [HttpGet]
        [Route("Create", Name = VideoManagementControllerRoutes.GetCreate)]
        public async Task<ActionResult> Create()
        {
            ViewBag.VideoSettingsId = new SelectList(await _videoSettingsService.GetAllAsync(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            ViewBag.LanguageId = new SelectList(await _languageService.GetAllAsync(), "Id", "Name");
            return View(VideoManagementControllerActions.Create);
        }

        // POST: VideoAttributesViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create", Name = VideoManagementControllerRoutes.PostCreate)]
        public async Task<ActionResult> Create(VideoAttributesViewModel videoAttributesViewModel)
        {
            if (ModelState.IsValid)
            {
                var duplicationCheck =await _videoAttributesService.GetSingleAsync(i => i.Url.ToLower().Contains(videoAttributesViewModel.VideoId.ToLower()));
                if (duplicationCheck == null)
                {
                    var videoAttributes = _mapper.Map<VideoAttributesExtend>(videoAttributesViewModel);
                    videoAttributes.UserId = User.Identity.GetUserId();
                    videoAttributes.Thumbunail = GetYouTubeThumbnail(videoAttributesViewModel.VideoId);
                    await _videoAttributesService.CreateAsync(videoAttributes);
                    return RedirectToAction(VideoManagementControllerActions.Index);
                }
                else
                {
                    ViewBag.VideoSettingsId = new SelectList(await _videoSettingsService.GetAllAsync(), "Id", "Name");
                    ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
                    ViewBag.LanguageId = new SelectList(await _languageService.GetAllAsync(), "Id", "Name");
                    Danger("Video already there in our database");
                    return View(VideoManagementControllerActions.Create, videoAttributesViewModel);
                }
            }

            ViewBag.VideoSettingsId = new SelectList(await _videoSettingsService.GetAllAsync(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            ViewBag.LanguageId = new SelectList(await _languageService.GetAllAsync(), "Id", "Name");
            return View(VideoManagementControllerActions.Create,videoAttributesViewModel);
        }

        public byte[] GetYouTubeThumbnail(string videoId)
        {
            if (!string.IsNullOrWhiteSpace(videoId))
            {
                var url = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
                WebClient wc = new WebClient();
                byte[] originalData = wc.DownloadData(url);
                return originalData;
            }
            return null;
        }

        //// GET: VideoAttributesViewModels/Edit/5
        [HttpGet]
        [Route("Edit", Name = VideoManagementControllerRoutes.GetEdit)]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var videoSettingsDto = await _videoAttributesService.GetSingleAsync(i => i.Id == id);
            var videoAttributesViewModel = _mapper.Map<VideoAttributesViewModel>(videoSettingsDto);
            if (videoAttributesViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoSettingsId = new SelectList(await _videoSettingsService.GetAllAsync(), "Id", "Name", selectedValue: videoAttributesViewModel.VideoSettingsId);
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name",selectedValue: videoAttributesViewModel.CategoryId);
            ViewBag.LanguageId = new SelectList(await _languageService.GetAllAsync(), "Id", "Name", selectedValue: videoAttributesViewModel.LanguageId);
            return View(VideoManagementControllerActions.Edit,videoAttributesViewModel);
        }

        // POST: VideoAttributesViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit", Name = VideoManagementControllerRoutes.PostEdit)]
        public async Task<ActionResult> Edit(VideoAttributesViewModel videoAttributesViewModel)
        {
            if (ModelState.IsValid)
            {
                var videoAttributes = _mapper.Map<VideoAttributesExtend>(videoAttributesViewModel);
                videoAttributes.UserId = User.Identity.GetUserId();
                videoAttributes.Thumbunail = GetYouTubeThumbnail(videoAttributesViewModel.VideoId);
                await _videoAttributesService.UpdateAsync(videoAttributes);
                return RedirectToAction(VideoManagementControllerActions.Index);
            }
            ViewBag.VideoSettingsId = new SelectList(await _videoSettingsService.GetAllAsync(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            ViewBag.LanguageId = new SelectList(await _languageService.GetAllAsync(), "Id", "Name");
            return View(VideoManagementControllerActions.Edit,videoAttributesViewModel);
        }

        // GET: VideoAttributesViewModels/Delete/5
        [HttpGet]
        [Route("Delete", Name = VideoManagementControllerRoutes.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var videoSettingsDto = await _videoAttributesService.GetSingleAsync(i => i.Id == id);
            var videoAttributesViewModel = _mapper.Map<VideoAttributesViewModel>(videoSettingsDto);
            if (videoAttributesViewModel == null)
            {
                return HttpNotFound();
            }
            await _videoAttributesService.DeleteAsync(videoSettingsDto);
            return RedirectToAction(VideoManagementControllerActions.Index);
        }
    }
}
