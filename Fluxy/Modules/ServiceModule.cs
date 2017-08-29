using Autofac;
using System.Linq;
using System.Reflection;

namespace Fluxy.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Fluxy.Services"))
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces()
                 .AsSelf()
                 .InstancePerLifetimeScope();
        }
    }
}