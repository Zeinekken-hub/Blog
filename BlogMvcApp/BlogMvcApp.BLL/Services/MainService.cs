using BlogMvcApp.DLL.Interfaces;

namespace BlogMvcApp.BLL.Services
{
    public abstract class MainService
    {
        protected IUnitOfWork Database { get; }

        public MainService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
    }
}
