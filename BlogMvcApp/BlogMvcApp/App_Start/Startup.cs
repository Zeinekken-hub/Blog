using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.BLL.Services;
using BlogMvcApp.DLL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(BlogMvcApp.App_Start.Startup))]

namespace BlogMvcApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private static IUserService CreateUserService()
        {
            return new UserService(new EFUnitOfWork());
        }
    }
}