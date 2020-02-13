using BlogMvcApp.DLL.Interfaces;
using BlogMvcApp.DLL.Repositories;
using Ninject.Modules;

namespace BlogMvcApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
