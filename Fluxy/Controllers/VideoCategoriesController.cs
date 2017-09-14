using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using PagedList;
using Fluxy.ViewModels.Video;
using Fluxy.Core.Constants.VideoCategories;

namespace Fluxy.Controllers
{
    public class VideoCategoriesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly int _pageSize = 12;
        public VideoCategoriesController(ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _videoAttributesService = videoAttributesService;
        }

        #region General

        [HttpGet]
        [Route("AutoVehicles", Name = VideoCategoriesRoute.GetAutoVehicles)]
        public ActionResult AutoVehicles(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var autoVehicleList = _videoAttributesService.GetList(i => i.Category.Name == "Autos and Vehicles");
            var autoVehicleVM = _mapper.Map<List<VideoAttributesViewModel>>(autoVehicleList);
            var autoVehiclePagedList = autoVehicleVM.ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.AutoVehicles,autoVehiclePagedList);
        }

        [HttpGet]
        [Route("TravelEvents", Name = VideoCategoriesRoute.GetTravelEvents)]
        public ActionResult TravelEvents(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var travelEventsList = _videoAttributesService.GetList(i => i.Category.Name == "Travel & Events");
            var travelEventsVM = _mapper.Map<List<VideoAttributesViewModel>>(travelEventsList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.TravelEvents, travelEventsVM);

        }

        [HttpGet]
        [Route("PeopleBlogs", Name = VideoCategoriesRoute.GetPeopleBlogs)]
        public ActionResult PeopleBlogs(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var peopleBlogsList = _videoAttributesService.GetList(i => i.Category.Name == "People & Blogs");
            var peopleBlogsVM = _mapper.Map<List<VideoAttributesViewModel>>(peopleBlogsList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.PeopleBlogs, peopleBlogsVM);

        }

        [HttpGet]
        [Route("PetsAnimals", Name = VideoCategoriesRoute.GetPetsAnimals)]
        public ActionResult PetsAnimals(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var petsAnimalsList = _videoAttributesService.GetList(i => i.Category.Name == "Pets & Animals");
            var petsAnimalsVM = _mapper.Map<List<VideoAttributesViewModel>>(petsAnimalsList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.PetsAnimals, petsAnimalsVM);
        }

        #endregion

        #region Infotainment

        [HttpGet]
        [Route("ScienceTechnology", Name = VideoCategoriesRoute.GetScienceTechnology)]
        public ActionResult ScienceTechnology(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var scienceTechList = _videoAttributesService.GetList(i => i.Category.Name == "Science & Technology");
            var scienceTechVM = _mapper.Map<List<VideoAttributesViewModel>>(scienceTechList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.ScienceTechnology, scienceTechVM);

        }

        [HttpGet]
        [Route("NewsPolitics", Name = VideoCategoriesRoute.GetNewsPolitics)]
        public ActionResult NewsPolitics(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var newsPoliticsList = _videoAttributesService.GetList(i => i.Category.Name == "News & Politics");
            var newsPoliticsVM = _mapper.Map<List<VideoAttributesViewModel>>(newsPoliticsList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.NewsPolitics, newsPoliticsVM);
        }

        [HttpGet]
        [Route("Health", Name = VideoCategoriesRoute.GetHealth)]
        public ActionResult Health(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var healthist = _videoAttributesService.GetList(i => i.Category.Name == "Health");
            var healthVM = _mapper.Map<List<VideoAttributesViewModel>>(healthist).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Health, healthVM);
        }

        [HttpGet]
        [Route("Devotional", Name = VideoCategoriesRoute.GetDevotional)]
        public ActionResult Devotional(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var devotionalList = _videoAttributesService.GetList(i => i.Category.Name == "Devotional");
            var devotionalVM = _mapper.Map<List<VideoAttributesViewModel>>(devotionalList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Devotional, devotionalVM);
        }

        [HttpGet]
        [Route("Documentary", Name = VideoCategoriesRoute.GetDocumentary)]
        public ActionResult Documentary(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var documentaryList = _videoAttributesService.GetList(i => i.Category.Name == "Documentary");
            var documentaryVM = _mapper.Map<List<VideoAttributesViewModel>>(documentaryList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Documentary, documentaryVM);
        }

        [HttpGet]
        [Route("Education", Name = VideoCategoriesRoute.GetEducation)]
        public ActionResult Education(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var educationList = _videoAttributesService.GetList(i => i.Category.Name == "Education");
            var educationVM = _mapper.Map<List<VideoAttributesViewModel>>(educationList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Education, educationVM);
        }

        #endregion

        #region Entertainment

        [HttpGet]
        [Route("Music", Name = VideoCategoriesRoute.GetMusic)]
        public ActionResult Music(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var musicList = _videoAttributesService.GetList(i => i.Category.Name == "Music");
            var musicVM = _mapper.Map<List<VideoAttributesViewModel>>(musicList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Music, musicVM);
        }

        [HttpGet]
        [Route("Gaming", Name = VideoCategoriesRoute.GetGaming)]
        public ActionResult Gaming(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var gamingList = _videoAttributesService.GetList(i => i.Category.Name == "Gaming");
            var gamingVM = _mapper.Map<List<VideoAttributesViewModel>>(gamingList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Gaming, gamingVM);
        }

        [HttpGet]
        [Route("Sports", Name = VideoCategoriesRoute.GetSports)]
        public ActionResult Sports(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var sportsList = _videoAttributesService.GetList(i => i.Category.Name == "Sports");
            var sportsVM = _mapper.Map<List<VideoAttributesViewModel>>(sportsList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Sports, sportsVM);
        }

        [HttpGet]
        [Route("FilmAnimation", Name = VideoCategoriesRoute.GetFilmAnimation)]
        public ActionResult FilmAnimation(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var filmAnimationList = _videoAttributesService.GetList(i => i.Category.Name == "Film & Animation");
            var filmAnimationVM = _mapper.Map<List<VideoAttributesViewModel>>(filmAnimationList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.FilmAnimation, filmAnimationVM);
        }

        [HttpGet]
        [Route("Entertainment", Name = VideoCategoriesRoute.GetEntertainment)]
        public ActionResult Entertainment(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var entertainmentList = _videoAttributesService.GetList(i => i.Category.Name == "Entertainment");
            var entertainmentVM = _mapper.Map<List<VideoAttributesViewModel>>(entertainmentList).ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Entertainment, entertainmentVM);
        }

        #endregion
    }
}