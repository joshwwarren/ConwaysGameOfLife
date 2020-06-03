using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ConwaysGameOfLife.ViewModels;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace ConwaysGameOfLife
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            var registrations =
                from type in typeof(Game).Assembly.GetExportedTypes()
                where type.Namespace.StartsWith("ConwaysGameOfLife.Models")
                where type.GetInterfaces().Any()
                select new {Service = type.GetInterfaces().FirstOrDefault(), Implementation = type};

            foreach (var reg in registrations)
                container.Register(reg.Service, reg.Implementation);

            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}