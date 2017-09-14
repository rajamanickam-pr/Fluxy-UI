﻿using Fluxy.Infrastructure;
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
        private readonly int _pageSize = 12;
        public VideoCategoriesController(ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _videoAttributesService = videoAttributesService;
        }

        #region General

        // GET: VideoCategories
        public ActionResult AutoVehicles(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var autoVehicleList = _videoAttributesService.GetList(i => i.Category.Name == "Autos and Vehicles");
            var autoVehicleVM = _mapper.Map<List<VideoAttributesViewModel>>(autoVehicleList);
            var autoVehiclePagedList = autoVehicleVM.ToPagedList(pageIndex, _pageSize);
            return View(autoVehiclePagedList);
        }

        public ActionResult TravelEvents(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var travelEventsList = _videoAttributesService.GetList(i => i.Category.Name == "Travel & Events");
            var travelEventsVM = _mapper.Map<List<VideoAttributesViewModel>>(travelEventsList).ToPagedList(pageIndex, _pageSize);
            return View(travelEventsVM);
        }

        public ActionResult PeopleBlogs(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var peopleBlogsList = _videoAttributesService.GetList(i => i.Category.Name == "People & Blogs");
            var peopleBlogsVM = _mapper.Map<List<VideoAttributesViewModel>>(peopleBlogsList).ToPagedList(pageIndex, _pageSize);
            return View(peopleBlogsVM);
        }

        public ActionResult PetsAnimals(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var petsAnimalsList = _videoAttributesService.GetList(i => i.Category.Name == "Pets & Animals");
            var petsAnimalsVM = _mapper.Map<List<VideoAttributesViewModel>>(petsAnimalsList).ToPagedList(pageIndex, _pageSize);
            return View(petsAnimalsVM);
        } 

        #endregion

        #region Infotainment

        public ActionResult ScienceTechnology(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var scienceTechList = _videoAttributesService.GetList(i => i.Category.Name == "Science & Technology");
            var scienceTechVM = _mapper.Map<List<VideoAttributesViewModel>>(scienceTechList).ToPagedList(pageIndex, _pageSize);
            return View(scienceTechVM);
        }

        public ActionResult NewsPolitics(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var newsPoliticsList = _videoAttributesService.GetList(i => i.Category.Name == "News & Politics");
            var newsPoliticsVM = _mapper.Map<List<VideoAttributesViewModel>>(newsPoliticsList).ToPagedList(pageIndex, _pageSize);
            return View(newsPoliticsVM);
        }

        public ActionResult Health(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var healthist = _videoAttributesService.GetList(i => i.Category.Name == "Health");
            var healthVM = _mapper.Map<List<VideoAttributesViewModel>>(healthist).ToPagedList(pageIndex, _pageSize);
            return View(healthVM);
        }

        public ActionResult Devotional(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var devotionalList = _videoAttributesService.GetList(i => i.Category.Name == "Devotional");
            var devotionalVM = _mapper.Map<List<VideoAttributesViewModel>>(devotionalList).ToPagedList(pageIndex, _pageSize);
            return View(devotionalVM);
        }

        public ActionResult Documentary(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var documentaryList = _videoAttributesService.GetList(i => i.Category.Name == "Documentary");
            var documentaryVM = _mapper.Map<List<VideoAttributesViewModel>>(documentaryList).ToPagedList(pageIndex, _pageSize);
            return View(documentaryVM);
        }

        public ActionResult Education(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var educationList = _videoAttributesService.GetList(i => i.Category.Name == "Education");
            var educationVM = _mapper.Map<List<VideoAttributesViewModel>>(educationList).ToPagedList(pageIndex, _pageSize);
            return View(educationVM);
        }

        #endregion

        #region Entertainment

        public ActionResult Music(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var musicList = _videoAttributesService.GetList(i => i.Category.Name == "Music");
            var musicVM = _mapper.Map<List<VideoAttributesViewModel>>(musicList).ToPagedList(pageIndex, _pageSize);
            return View(musicVM);
        }

        public ActionResult Gaming(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var gamingList = _videoAttributesService.GetList(i => i.Category.Name == "Gaming");
            var gamingVM = _mapper.Map<List<VideoAttributesViewModel>>(gamingList).ToPagedList(pageIndex, _pageSize);
            return View(gamingVM);
        }

        public ActionResult Sports(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var sportsList = _videoAttributesService.GetList(i => i.Category.Name == "Sports");
            var sportsVM = _mapper.Map<List<VideoAttributesViewModel>>(sportsList).ToPagedList(pageIndex, _pageSize);
            return View(sportsVM);
        }

        public ActionResult FilmAnimation(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var filmAnimationList = _videoAttributesService.GetList(i => i.Category.Name == "Film & Animation");
            var filmAnimationVM = _mapper.Map<List<VideoAttributesViewModel>>(filmAnimationList).ToPagedList(pageIndex, _pageSize);
            return View(filmAnimationVM);
        }

        public ActionResult Entertainment(int? page)
        {
            int pageIndex = 1;
            pageIndex = page ?? 1;
            var entertainmentList = _videoAttributesService.GetList(i => i.Category.Name == "Entertainment");
            var entertainmentVM = _mapper.Map<List<VideoAttributesViewModel>>(entertainmentList).ToPagedList(pageIndex, _pageSize);
            return View(entertainmentVM);
        }

        #endregion
    }
}