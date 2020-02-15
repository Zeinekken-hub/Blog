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

        public HomeController(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        public ActionResult Index()
        {
            var articles = ArticleService.GetArticles().ToList();

            return View(articles.ToArticleAdVm(TextAdLength));
        }

        public ActionResult Tags()
        {
            return PartialView(ArticleService.GetArticleTags().ToTagVm());
        }

        //public ActionResult Voting()
        //{
        //    return PartialView();
        //}

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}