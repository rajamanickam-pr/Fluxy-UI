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
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
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
                profile= _userProfileService.Update(userProfileDto);
            }
            else
            {
                profile= _userProfileService.Create(userProfileDto);
            }
            var userProfile = _mapper.Map<UserMangementViewModel>(profile);
            return View(userProfile);
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
            return View(userMangementVm);
        }
    }
}