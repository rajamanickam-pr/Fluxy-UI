﻿using Autofac;
using AutoMapper;
using Fluxy.Core.Models.Banners;
using Fluxy.Core.Models.Categories;
using Fluxy.Core.Models.Localization;
using Fluxy.Core.Models.Logging;
using Fluxy.Core.Models.Mail;
using Fluxy.Core.Models.Menu;
using Fluxy.Core.Models.Video;
using Fluxy.Data.ExtentedDTO;
using Fluxy.ViewModels.Banners;
using Fluxy.ViewModels.Categories;
using Fluxy.ViewModels.Localization;
using Fluxy.ViewModels.Logging;
using Fluxy.ViewModels.Mail;
using Fluxy.ViewModels.Menu;
using Fluxy.ViewModels.User;
using Fluxy.ViewModels.Video;

namespace Fluxy.Modules
{
    public class AutomapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                CreateMapping(cfg);
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
              .As<IMapper>()
              .InstancePerLifetimeScope();
        }

        private void CreateMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MainMenuViewModel, MainMenu>().ReverseMap();
            cfg.CreateMap<SubMenuViewModel, SubMenu>().ReverseMap();
            cfg.CreateMap<MenuAttributeViewModel, MenuAttribute>().ReverseMap();
            cfg.CreateMap<LogViewModel, Log>().ReverseMap();
            cfg.CreateMap<LanguageViewModel, Language>().ReverseMap();
            cfg.CreateMap<CategoryViewModel, Category>().ReverseMap();
            cfg.CreateMap<VideoSettingsViewModel, VideoSettings>().ReverseMap();
            cfg.CreateMap<VideoAttributesViewModel, VideoAttributesExtend>().ReverseMap();
            cfg.CreateMap<UserMangementViewModel, UserProfileExtend>().ReverseMap();
            cfg.CreateMap<UserMangementViewModel, UserSettingsExtend>().ReverseMap();
            cfg.CreateMap<BannerDetailsViewModel, BannerDetails>().ReverseMap();
            cfg.CreateMap<NewsletterViewModel, NewsletterExtend>().ReverseMap();
            cfg.CreateMap<ContactUsViewModel, ContactUs>().ReverseMap();
        }
    }
}