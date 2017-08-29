using Autofac;
using AutoMapper;
using Fluxy.Core.Models.Logging;
using Fluxy.Core.Models.Menu;
using Fluxy.ViewModels.Logging;
using Fluxy.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        }
    }
}