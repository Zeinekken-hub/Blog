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
            app.CreatePerOwinContext(() => (IUserService)new UserService(new EFUnitOfWork()));
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}