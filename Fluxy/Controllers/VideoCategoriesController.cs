using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using PagedList;
using Fluxy.ViewModels.Video;
using Fluxy.Core.Constants.VideoCategories;
using System.Threading.Tasks;
using System.Linq;
namespace Fluxy.Controllers
{
    [RoutePrefix("videos")]
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
        [Route("AutoVehicles/{page?}", Name = VideoCategoriesRoute.GetAutoVehicles)]
        public async Task<ActionResult> AutoVehicles(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var autoVehicleList = await _videoAttributesService.GetListAsync(i => i.Category.Name == "Autos and Vehicles");
            var autoVehicleVM = _mapper
                .Map<List<VideoAttributesViewModel>>(autoVehicleList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.AutoVehicles, autoVehicleVM);
        }

        [HttpGet]
        [Route("TravelEvents/{page?}", Name = VideoCategoriesRoute.GetTravelEvents)]
        public async Task<ActionResult> TravelEvents(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var travelEventsList = await _videoAttributesService.GetListAsync(i => i.Category.Name == "Travel & Events");
            var travelEventsVM = _mapper
                .Map<List<VideoAttributesViewModel>>(travelEventsList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);

            return View(VideoCategoriesAction.TravelEvents, travelEventsVM);
        }

        [HttpGet]
        [Route("PeopleBlogs/{page?}", Name = VideoCategoriesRoute.GetPeopleBlogs)]
        public async Task<ActionResult> PeopleBlogs(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var peopleBlogsList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "People & Blogs");
            var peopleBlogsVM = _mapper
                .Map<List<VideoAttributesViewModel>>(peopleBlogsList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);

            return View(VideoCategoriesAction.PeopleBlogs, peopleBlogsVM);
        }

        [HttpGet]
        [Route("PetsAnimals/{page?}", Name = VideoCategoriesRoute.GetPetsAnimals)]
        public async Task<ActionResult> PetsAnimals(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var petsAnimalsList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Pets & Animals");
            var petsAnimalsVM = _mapper
                .Map<List<VideoAttributesViewModel>>(petsAnimalsList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);

            return View(VideoCategoriesAction.PetsAnimals, petsAnimalsVM);
        }

        #endregion

        #region Infotainment

        [HttpGet]
        [Route("ScienceTechnology/{page?}", Name = VideoCategoriesRoute.GetScienceTechnology)]
        public async Task<ActionResult> ScienceTechnology(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var scienceTechList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Science & Technology");
            var scienceTechVM = _mapper
                .Map<List<VideoAttributesViewModel>>(scienceTechList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.ScienceTechnology, scienceTechVM);

        }

        [HttpGet]
        [Route("NewsPolitics/{page?}", Name = VideoCategoriesRoute.GetNewsPolitics)]
        public async Task<ActionResult> NewsPolitics(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var newsPoliticsList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "News & Politics");
            var newsPoliticsVM = _mapper
                .Map<List<VideoAttributesViewModel>>(newsPoliticsList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.NewsPolitics, newsPoliticsVM);
        }

        [HttpGet]
        [Route("Health/{page?}", Name = VideoCategoriesRoute.GetHealth)]
        public async Task<ActionResult> Health(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var healthist =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Health");
            var healthVM = _mapper
                .Map<List<VideoAttributesViewModel>>(healthist.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Health, healthVM);
        }

        [HttpGet]
        [Route("Devotional/{page?}", Name = VideoCategoriesRoute.GetDevotional)]
        public async Task<ActionResult> Devotional(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var devotionalList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Devotional");
            var devotionalVM = _mapper
                .Map<List<VideoAttributesViewModel>>(devotionalList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Devotional, devotionalVM);
        }

        [HttpGet]
        [Route("Documentary/{page?}", Name = VideoCategoriesRoute.GetDocumentary)]
        public async Task<ActionResult> Documentary(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var documentaryList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Documentary");
            var documentaryVM = _mapper
                .Map<List<VideoAttributesViewModel>>(documentaryList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Documentary, documentaryVM);
        }

        [HttpGet]
        [Route("Education/{page?}", Name = VideoCategoriesRoute.GetEducation)]
        public async Task<ActionResult> Education(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var educationList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Education");
            var educationVM = _mapper
                .Map<List<VideoAttributesViewModel>>(educationList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Education, educationVM);
        }

        #endregion

        #region Entertainment

        [HttpGet]
        [Route("Music/{page?}", Name = VideoCategoriesRoute.GetMusic)]
        public async Task<ActionResult> Music(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var musicList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Music");
            var musicVM = _mapper
                .Map<List<VideoAttributesViewModel>>(musicList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Music, musicVM);
        }

        [HttpGet]
        [Route("Gaming/{page?}", Name = VideoCategoriesRoute.GetGaming)]
        public async Task<ActionResult> Gaming(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var gamingList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Gaming");
            var gamingVM = _mapper
                .Map<List<VideoAttributesViewModel>>(gamingList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Gaming, gamingVM);
        }

        [HttpGet]
        [Route("Sports/{page?}", Name = VideoCategoriesRoute.GetSports)]
        public async Task<ActionResult> Sports(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var sportsList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Sports");
            var sportsVM = _mapper
                .Map<List<VideoAttributesViewModel>>(sportsList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Sports, sportsVM);
        }

        [HttpGet]
        [Route("FilmAnimation/{page?}", Name = VideoCategoriesRoute.GetFilmAnimation)]
        public async Task<ActionResult> FilmAnimation(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var filmAnimationList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Film & Animation");
            var filmAnimationVM = _mapper
                .Map<List<VideoAttributesViewModel>>(filmAnimationList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.FilmAnimation, filmAnimationVM);
        }

        [HttpGet]
        [Route("Entertainment/{page?}", Name = VideoCategoriesRoute.GetEntertainment)]
        public async Task<ActionResult> Entertainment(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var entertainmentList =await _videoAttributesService.GetListAsync(i => i.Category.Name == "Entertainment");
            var entertainmentVM = _mapper
                .Map<List<VideoAttributesViewModel>>(entertainmentList.OrderByDescending(i => i.CreatedDate))
                .ToPagedList(pageIndex, _pageSize);
            return View(VideoCategoriesAction.Entertainment, entertainmentVM);
        }

        #endregion
    }
}