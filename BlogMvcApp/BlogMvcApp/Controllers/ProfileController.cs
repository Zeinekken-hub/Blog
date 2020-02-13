using BlogMvcApp.BLL.Interfaces;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ProfileController : Controller
    {
        private IArticleService ArticleService { get; }
        public ProfileController(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(bool isStable, bool isAlone)
        {
            var articles = ArticleService.GetArticlesByGenreMood(isStable || isAlone);

            return View(articles);
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}