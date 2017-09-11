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
using Fluxy.Core.Helpers;
using Fluxy.Services.Mail;
using Fluxy.Services.Categories;
using Fluxy.ViewModels.Categories;
using Fluxy.ViewModels.Mail;

namespace Fluxy.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly INewsletterService _newsletterService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProfileController(IUserProfileService userProfileService, IVideoAttributesService videoAttributesService,
            IUserSettingsService userSettingsService, ILogService logService, IMapper mapper,
            INewsletterService newsletterService, ICategoryService categoryService)
            : base(logService, mapper)
        {
            _userProfileService = userProfileService;
            _userSettingsService = userSettingsService;
            _videoAttributesService = videoAttributesService;
            _newsletterService = newsletterService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index(string message)
        {
            var userId = User.Identity.GetUserId();
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            if (userProfile != null)
                userProfile.TotalVideo = _videoAttributesService.GetList(i => i.UserId == userId).Count();
            if (!string.IsNullOrEmpty(message))
                Warning(message);
            return View(userProfile);
        }

        public ActionResult ProfileVideos(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var userId = User.Identity.GetUserId();
            var userPostedVideo = _videoAttributesService.GetList(i => i.UserId == userId).OrderByDescending(i => i.CreatedDate);
            var userPostedVideoVM = _mapper.Map<List<VideoAttributesViewModel>>(userPostedVideo).ToPagedList(pageIndex, pageSize);
            return PartialView("_ProfileVideo", userPostedVideoVM);
        }

        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            UserProfileExtend profile;
            var userProfileDto = _mapper.Map<UserProfileExtend>(userMangementViewModel);
            userProfileDto.UserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userProfileDto.Id))
            {
                var oldPicture = _userProfileService.GetSingle(i => i.Id == userProfileDto.Id).DisplayPicture;
                if (oldPicture.Length > 0 && userProfileDto.DisplayPicture.Length <= 0)
                {
                    userProfileDto.DisplayPicture = oldPicture;
                }
                profile = _userProfileService.Update(userProfileDto);
            }
            else
            {
                profile = _userProfileService.Create(userProfileDto);
            }
            var userProfile = _mapper.Map<UserMangementViewModel>(profile);
            return RedirectToAction("Index", routeValues: new { message = Messages.ProfileEditConfirmation });
        }

        public ActionResult Privacy()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var profile = _userSettingsService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(profile);
            return View(userProfile);
        }

        [HttpPost]
        public ActionResult Privacy(UserMangementViewModel userMangementViewModel)
        {
            var userSettingsDto = _mapper.Map<UserSettingsExtend>(userMangementViewModel);
            userSettingsDto.UserId = User.Identity.GetUserId();
            var profileSettings = !string.IsNullOrEmpty(userSettingsDto.Id)
                ? _userSettingsService.Update(userSettingsDto)
                : _userSettingsService.Create(userSettingsDto);
            var userMangementVm = _mapper.Map<UserMangementViewModel>(profileSettings);
            return RedirectToAction("Index", routeValues: new { message = Messages.ProfileEditConfirmation });
        }

        public ActionResult Newsletter(string message)
        {
            var userId = User.Identity.GetUserId();
            var newsletter = _newsletterService.GetSingle(i => i.UserId == userId);
            var newsletterVM = _mapper.Map<NewsletterViewModel>(newsletter);

            var categories = _categoryService.GetAll();
            var categoriesVM = _mapper.Map<List<CategoryViewModel>>(categories);

            if (newsletterVM == null)
            {
                newsletterVM = new NewsletterViewModel
                {
                    Categories = categoriesVM
                };
            }
            else
            {
                newsletterVM.Categories = categoriesVM;
            }

            if (!string.IsNullOrEmpty(message))
                Warning(message);
            return View(newsletterVM);
        }

        [HttpPost]
        public ActionResult Newsletter(string[] selectedCategories)
        {
            if (selectedCategories == null || selectedCategories.Count() <= 0)
                return RedirectToAction("Newsletter", routeValues: new { message = Messages.NewsletterSubscription });
            var categories = string.Join(",", selectedCategories);
            var newletterVM = new NewsletterViewModel
            {
                Active = true,
                Subscription = categories,
                UserId = User.Identity.GetUserId()
            };
            var newsletter = _mapper.Map<NewsletterExtend>(newletterVM);

            var userId = User.Identity.GetUserId();
            var newsletterValue = _newsletterService.GetSingle(i => i.UserId == userId);
            if(newsletterValue!=null)
            {
                newsletterValue.Subscription = newletterVM.Subscription;
                newsletterValue.Active = newletterVM.Active;
                _newsletterService.Update(newsletterValue);
            }
            else
            {
                _newsletterService.Create(newsletter);
            }
            return RedirectToAction("Index", routeValues: new { message = Messages.NewsletterSubscriptionConfirmation });
        }
    }
}