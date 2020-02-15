using System.Linq;
using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.Infrastructure.Mapper;
using Ninject.Infrastructure.Language;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private const int TextAdLength = 500;
        private IArticleService ArticleService { get; }
        private IGenreService GenreService { get; }

        public HomeController(IArticleService articleService, IGenreService genreService)
        {
            ArticleService = articleService;
            GenreService = genreService;
        }

        public ActionResult Index()
        {
            var articles = ArticleService.GetArticles().ToList();

            return View(articles.ToArticleAdVm(500));
        }

        public ActionResult DropDownList()
        {
            return PartialView(GenreService.GetGenres());
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}