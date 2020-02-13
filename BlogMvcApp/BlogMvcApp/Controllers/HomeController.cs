using BlogMvcApp.BLL.Interfaces;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IArticleSerivce ArticleSerivce { get; }
        private IGenreService GenreService { get; }

        public HomeController(IArticleSerivce articleService, IGenreService genreService)
        {
            ArticleSerivce = articleService;
            GenreService = genreService;
        }

        public ActionResult Index()
        {
            return View(ArticleSerivce.GetArticles());
        }

        public ActionResult DropDownList()
        {
            return PartialView(GenreService.GetGenres());
        }
    }
}