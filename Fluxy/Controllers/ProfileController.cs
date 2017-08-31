using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Users;
using System.Linq;
using Fluxy.ViewModels.User;
using Fluxy.Data.ExtentedDTO;
using Fluxy.Core.Models.Users;
using Microsoft.AspNet.Identity;
using System.Web;
using System.IO;
using System.Net;

namespace Fluxy.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IMapper _mapper;

        public ProfileController(IUserProfileService userProfileService, IUserSettingsService userSettingsService, ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
            _userProfileService = userProfileService;
            _userSettingsService = userSettingsService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfileDetails = _userProfileService.GetAll().FirstOrDefault(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
        }

        public ActionResult Edit(string UserProfileId)
        {
            if (UserProfileId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userProfileDetails = _userProfileService.GetAll().FirstOrDefault(i => i.Id == UserProfileId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserMangementViewModel userMangementViewModel, HttpPostedFileBase fileBase)
        {
            if (userMangementViewModel.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
                _userProfileService.Update(userProfileDto);
            }
            else
            {
                _userProfileService.Create(userProfileDto);
            }
            return View(userMangementViewModel);
        }

        public ActionResult Privacy(string UserProfileId)
        {
            if (UserProfileId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userProfileDetails = _userSettingsService.GetAll().FirstOrDefault(i => i.UserProfile.Id == UserProfileId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
        }

        [HttpPost]
        public ActionResult Privacy(UserMangementViewModel userMangementViewModel)
        {
            var userSettingsDto = _mapper.Map<UserSettings>(userMangementViewModel);
            if (!string.IsNullOrEmpty(userSettingsDto.Id))
            {
                _userSettingsService.Update(userSettingsDto);
            }
            else
            {
                _userSettingsService.Create(userSettingsDto);
            }
            return View(userMangementViewModel);
        }

        public ActionResult UpsertUserValues(UserMangementViewModel userMangementViewModel)
        {
            if (ModelState.IsValid)
            {
                var userProfileDto = _mapper.Map<UserProfileExtend>(userMangementViewModel);
                userProfileDto.UserId = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(userProfileDto.Id))
                {
                    _userProfileService.Update(userProfileDto);
                }
                else
                {
                    _userProfileService.Create(userProfileDto);
                }
            }
            return View("Index");
        }

        public ActionResult UpsertUserSettings(UserMangementViewModel userMangementViewModel)
        {
            if (ModelState.IsValid)
            {
                var userSettingsDto = _mapper.Map<UserSettings>(userMangementViewModel);
                if (!string.IsNullOrEmpty(userSettingsDto.Id))
                {
                    _userSettingsService.Update(userSettingsDto);
                }
                else
                {
                    _userSettingsService.Create(userSettingsDto);
                }
            }
            return View("Index");
        }

        public ActionResult UpsertProfilePicture(UserMangementViewModel userMangementViewModel, HttpPostedFileBase fileBase)
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

            var userProfileDto = _mapper.Map<UserProfileExtend>(userMangementViewModel);
            userProfileDto.UserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userProfileDto.Id))
            {
                _userProfileService.Update(userProfileDto);
            }
            else
            {
                _userProfileService.Create(userProfileDto);
            }
            return View("Index");
        }
    }
}