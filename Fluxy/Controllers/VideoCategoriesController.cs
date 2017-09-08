using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using PagedList;
using Fluxy.ViewModels.Video;

namespace Fluxy.Controllers
{
    public class VideoCategoriesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;

        public VideoCategoriesController(ILogService logService, IMapper mapper,IVideoAttributesService videoAttributesService) 
            : base(logService, mapper)
        {
            _mapper = mapper;
            _videoAttributesService = videoAttributesService;
        }

        // GET: VideoCategories
        public ActionResult AutoVehicles(int? page)
        {
            int pageSize = 12;
            int pageIndex = 1;
            pageIndex = page.HasValue ? page.Value : 1;
            var autoVehicleList = _videoAttributesService.GetList(i => i.Category.Name == "Autos and Vehicles");
            var autoVehicleVM = _mapper.Map<List<VideoAttributesViewModel>>(autoVehicleList);
            var autoVehiclePagedList= autoVehicleVM.ToPagedList(pageIndex, pageSize);
            return View(autoVehiclePagedList);
        }

        public ActionResult TravelEvents()
        {
            var travelEventsList = _videoAttributesService.GetList(i => i.Category.Name == "Travel & Events");
            return View(travelEventsList);
        }

        public ActionResult PeopleBlogs()
        {
            var peopleBlogsList = _videoAttributesService.GetList(i => i.Category.Name == "People & Blogs");
            return View(peopleBlogsList);
        }

        public ActionResult PetsAnimals()
        {
            var petsAnimalsList = _videoAttributesService.GetList(i => i.Category.Name == "Pets & Animals");
            return View(petsAnimalsList);
        }
    }
}