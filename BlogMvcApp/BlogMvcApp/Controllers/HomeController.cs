using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.Infrastructure.Mapper;
using System.Linq;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private const int TextAdLength = 100;
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


        [HttpPost]
        public ActionResult Vote(string mood)
        {
            return PartialView("ThankResult");
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}