using BlogMvcApp.DLL.Interfaces;
using BlogMvcApp.DLL.Repositories;
using Ninject.Modules;

namespace BlogMvcApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
