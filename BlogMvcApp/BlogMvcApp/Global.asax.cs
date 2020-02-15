using BlogMvcApp.BLL.Infrastructure;
using BlogMvcApp.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogMvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var blogModule = new BlogModule();
            var serviceModule = new ServiceModule();
            var kernel = new StandardKernel(blogModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
