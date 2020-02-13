using BlogMvcApp.BLL.Interfaces;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ProfileController : Controller
    {
        private IArticleSerivce ArticleSerivce { get; }
        public ProfileController(IArticleSerivce articleService)
        {
            ArticleSerivce = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(bool isStable, bool isAlone)
        {
            var articles = ArticleSerivce.GetArticlesByGenreMood(isStable || isAlone);

            return View(articles);
        }

        protected override void Dispose(bool disposing)
        {
            ArticleSerivce.Dispose();
            base.Dispose(disposing);
        }
    }
}