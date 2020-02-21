using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.Infrastructure.Mapper;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace BlogMvcApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const int TextAdLength = 200;
        private const int PageSize = 4;
        private IArticleService ArticleService { get; }

        public HomeController(IArticleService articleService)
        {
            ArticleService = articleService;
        }
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var articles = ArticleService.GetArticles().ToList().OrderByDescending(x => x.Date);

            return View(articles.ToArticleAdVm(TextAdLength).ToPagedList(page, PageSize));
        }
        [AllowAnonymous]
        public ActionResult Tags()
        {
            return PartialView(ArticleService.GetArticleTags().ToTagVm());
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult Vote(string mood)
        {
            if (mood != "") return PartialView("ThankResult");

            ModelState.AddModelError("", "Choose option!");////
            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}