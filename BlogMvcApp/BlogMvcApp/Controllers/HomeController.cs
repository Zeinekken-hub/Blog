using BlogMvcApp.BLL.Interfaces;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService ArticleService { get; }
        private IGenreService GenreService { get; }

        public HomeController(IArticleService articleService, IGenreService genreService)
        {
            ArticleService = articleService;
            GenreService = genreService;
        }

        public ActionResult Index()
        {
            return View(ArticleService.GetArticles());
        }

        public ActionResult DropDownList()
        {
            return PartialView(GenreService.GetGenres());
        }
    }
}