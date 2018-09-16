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

            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            // See below for more configuration examples
            //container.Register<IMatrix, Matrix>();
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
            var registrations =
                from type in typeof(Game).Assembly.GetExportedTypes()
                where type.Namespace.StartsWith("ConwaysGameOfLife.Models")
                where type.GetInterfaces().Any()
                select new {Service = type.GetInterfaces().FirstOrDefault(), Implementation = type};

            foreach (var reg in registrations)
                container.Register(reg.Service, reg.Implementation);
            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}