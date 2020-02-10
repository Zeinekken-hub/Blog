using BlogMvcApp.DLL.Interfaces;
using BlogMvcApp.DLL.Repositories;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new EFUnitOfWork("BlogContext");

        public ActionResult Index()
        {
            return View(_unitOfWork.Articles.GetAll());
        }

        public ActionResult DropDownList()
        {
            return PartialView(_unitOfWork.Genres.GetAll());
        }
    }
}