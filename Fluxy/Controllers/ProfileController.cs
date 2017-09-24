using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Users;
using Fluxy.ViewModels.User;
using Fluxy.Data.ExtentedDTO;
using Microsoft.AspNet.Identity;
using System.Web;
using System.IO;
using System.Net;
using Fluxy.Services.Video;
using System.Collections.Generic;
using Fluxy.ViewModels.Video;
using System;
using PagedList;
using System.Linq;
using System.Threading.Tasks;
using Fluxy.Services.Mail;
using Fluxy.Services.Categories;
using Fluxy.ViewModels.Categories;
using Fluxy.ViewModels.Mail;
using Fluxy.Services.Localization;
using Fluxy.ViewModels.Localization;
using Fluxy.Core.Constants;
using Fluxy.Core.Constants.Profile;

namespace Fluxy.Controllers
{
    [Authorize]
    [RoutePrefix("profile")]
    public class ProfileController : BaseController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly INewsletterService _newsletterService;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly IVideoSettingsService _videoSettingsService;
        private readonly IMapper _mapper;
        public ProfileController(IUserProfileService userProfileService, IVideoAttributesService videoAttributesService,
            IUserSettingsService userSettingsService, ILogService logService, IMapper mapper,
            INewsletterService newsletterService, ICategoryService categoryService,
            ILanguageService languageService, IVideoSettingsService videoSettingsService)
            : base(logService, mapper)
        {
            _userProfileService = userProfileService;
            _userSettingsService = userSettingsService;
            _videoAttributesService = videoAttributesService;
            _newsletterService = newsletterService;
            _categoryService = categoryService;
            _mapper = mapper;
            _languageService = languageService;
            _videoSettingsService = videoSettingsService;
        }

        private bool IsProfileOwner(string userId)
        {
            var currentUserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                return currentUserId == userId;
            }
            return true;
        }

        [HttpGet]
        [Route("", Name = ProfileControllerRoute.GetIndex)]
        public ActionResult Index(string message, string userId)
        {
            var currentUserId = User.Identity.GetUserId();
            var user = !string.IsNullOrEmpty(userId) ? userId : currentUserId;

            ViewBag.IsProfileOwner = IsProfileOwner(userId);
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == user);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            if (userProfile != null)
            {
                userProfile.TotalVideo = _videoAttributesService.GetList(i => i.UserId == user).Count();
            }

            if (!string.IsNullOrEmpty(message))
                Warning(message);

            return View(ProfileControllerAction.Index, userProfile);
        }

        [HttpGet]
        [Route("ProfileVideos", Name = ProfileControllerRoute.GetProfileVideos)]
        public ActionResult ProfileVideos(int? page, string userId)
        {
            const int pageSize = 5;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var userPostedVideo = _videoAttributesService.GetList(i => i.UserId == userId).OrderByDescending(i => i.CreatedDate);
            var userPostedVideoVm = _mapper.Map<List<VideoAttributesViewModel>>(userPostedVideo).ToPagedList(pageIndex, pageSize);
            ViewBag.IsProfileOwner = IsProfileOwner(userId);
            return PartialView("_ProfileVideo", userPostedVideoVm);
        }

        [HttpGet]
        [Route("Edit", Name = ProfileControllerRoute.GetEdit)]
        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(ProfileControllerAction.Edit, userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit", Name = ProfileControllerRoute.PostEdit)]
        public ActionResult Edit(UserMangementViewModel userMangementViewModel, HttpPostedFileBase fileBase)
        {
            if (fileBase != null)
            {
                if (fileBase.ContentLength > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fileBase.InputStream.CopyTo(ms);
                        byte[] fileArray = ms.GetBuffer();
                        userMangementViewModel.DisplayPicture = fileArray;
                    }
                }
            }
            var userProfileDto = _mapper.Map<UserProfileExtend>(userMangementViewModel);
            userProfileDto.UserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userProfileDto.Id))
            {
                var oldPicture = _userProfileService.GetSingle(i => i.Id == userProfileDto.Id).DisplayPicture;
                if (oldPicture.Length > 0 && userProfileDto.DisplayPicture.Length <= 0)
                {
                    userProfileDto.DisplayPicture = oldPicture;
                }
                _userProfileService.Update(userProfileDto);
            }
            else
            {
                _userProfileService.Create(userProfileDto);
            }
            return RedirectToAction(ProfileControllerAction.Index, routeValues: new { message = Messages.ProfileEditConfirmation });
        }

        [HttpGet]
        [Route("Privacy", Name = ProfileControllerRoute.GetPrivacy)]
        public ActionResult Privacy()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var profile = _userSettingsService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(profile);
            return View(ProfileControllerAction.Privacy, userProfile);
        }

        [HttpPost]
        [Route("Privacy", Name = ProfileControllerRoute.PostPrivacy)]
        public async Task<ActionResult> Privacy(UserMangementViewModel userMangementViewModel)
        {
            var userSettingsDto = _mapper.Map<UserSettingsExtend>(userMangementViewModel);
            userSettingsDto.UserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userSettingsDto.Id))
            {
              await  _userSettingsService.UpdateAsync(userSettingsDto);
            }
            else
            {
                await _userSettingsService.CreateAsync(userSettingsDto);
            }
            return RedirectToAction(ProfileControllerAction.Index, new { message = Messages.ProfileEditConfirmation });
        }

        [HttpGet]
        [Route("Newsletter", Name = ProfileControllerRoute.GetNewsletter)]
        public ActionResult Newsletter(string message)
        {
            var userId = User.Identity.GetUserId();
            var newsletter = _newsletterService.GetSingle(i => i.UserId == userId);
            var newsletterVm = _mapper.Map<NewsletterViewModel>(newsletter);

            var categories = _categoryService.GetAll();
            var categoriesVm = _mapper.Map<List<CategoryViewModel>>(categories);

            if (newsletterVm == null)
            {
                newsletterVm = new NewsletterViewModel
                {
                    Categories = categoriesVm
                };
            }
            else
            {
                newsletterVm.Categories = categoriesVm;
            }

            if (!string.IsNullOrEmpty(message))
                Warning(message);
            return View(ProfileControllerAction.Newsletter, newsletterVm);
        }

        [HttpPost]
        [Route("Newsletter", Name = ProfileControllerRoute.PostNewsletter)]
        public ActionResult Newsletter(string[] selectedCategories)
        {
            if (selectedCategories == null || !selectedCategories.Any())
                return RedirectToAction("Newsletter", routeValues: new { message = Messages.NewsletterSubscription });
            var categories = string.Join(",", selectedCategories);
            var newletterVm = new NewsletterViewModel
            {
                Active = true,
                Subscription = categories,
                UserId = User.Identity.GetUserId()
            };
            var newsletter = _mapper.Map<NewsletterExtend>(newletterVm);

            var userId = User.Identity.GetUserId();
            var newsletterValue = _newsletterService.GetSingle(i => i.UserId == userId);
            if (newsletterValue != null)
            {
                newsletterValue.Subscription = newletterVm.Subscription;
                newsletterValue.Active = newletterVm.Active;
                _newsletterService.Update(newsletterValue);
            }
            else
            {
                _newsletterService.Create(newsletter);
            }
            return RedirectToAction(ProfileControllerAction.Index, routeValues: new { message = Messages.NewsletterSubscriptionConfirmation });
        }

        [HttpGet]
        [Route("PostVideos", Name = ProfileControllerRoute.GetPostVideos)]
        public virtual ActionResult PostVideos()
        {
            var categories = _categoryService.GetAll().OrderBy(i => i.Name);
            var videoSettings = _videoSettingsService.GetAll().OrderBy(i => i.Name);
            var language = _languageService.GetAll().OrderBy(i=>i.Name);
            var videoAttribute = new VideoAttributesViewModel
            {
                Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories),
                VideoSettingses = _mapper.Map<IEnumerable<VideoSettingsViewModel>>(videoSettings),
                Languages = _mapper.Map<IEnumerable<LanguageViewModel>>(language)
            };
            return View(ProfileControllerAction.PostVideos, videoAttribute);
        }

        [HttpPost]
        [Route("PostVideos", Name = ProfileControllerRoute.PostPostVideos)]
        public virtual ActionResult PostVideos(VideoAttributesViewModel videoAttributesViewModel)
        {
            var duplicationCheck = _videoAttributesService.GetSingle(i => i.Url.ToLower().Contains(videoAttributesViewModel.VideoId.ToLower()));
            if (duplicationCheck == null)
            {
                var videoAttributes = _mapper.Map<VideoAttributesExtend>(videoAttributesViewModel);
                videoAttributes.UserId = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(videoAttributes.Id))
                {
                    videoAttributes.Thumbunail = GetYouTubeThumbnail(videoAttributesViewModel.VideoId);
                    _videoAttributesService.Update(videoAttributes);
                }
                else
                {
                    videoAttributes.Thumbunail = GetYouTubeThumbnail(videoAttributesViewModel.VideoId);
                    _videoAttributesService.Create(videoAttributes);
                }
                return RedirectToAction(ProfileControllerAction.Index);
            }
            else
            {
                return RedirectToAction(ProfileControllerAction.Index, routeValues: new { message = Messages.VideoDuplication, userId = string.Empty });
            }
        }

        [HttpGet]
        [Route("DeleteVideo", Name = ProfileControllerRoute.GetDeleteVideo)]
        public virtual ActionResult DeleteVideo(string videoId)
        {
            var video = _videoAttributesService.GetSingle(i => i.Id == videoId);
            if (video != null)
            {
                _videoAttributesService.Delete(video);
            }
            return RedirectToAction(ProfileControllerAction.Index, routeValues: new { message = Messages.VideoDeleteConfirmation, userId = string.Empty });
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
    }
}