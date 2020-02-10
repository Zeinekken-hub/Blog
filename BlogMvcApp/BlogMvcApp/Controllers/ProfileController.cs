using BlogMvcApp.DLL.Interfaces;
using BlogMvcApp.DLL.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new EFUnitOfWork("BlogContext");

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(bool isStable, bool isAlone)
        {
            if (isStable || isAlone)
            {
                var articles = _unitOfWork.Articles.GetDbSet()
                    .Include(article => article.Genre)
                    .Where(article => article.Genre.Mood);
                return View(articles);
            }
            else
            {
                var articles = _unitOfWork.Articles.GetDbSet()
                    .Include(article => article.Genre)
                    .Where(article => !article.Genre.Mood);

                return View(articles);
            }
        }
    }
}