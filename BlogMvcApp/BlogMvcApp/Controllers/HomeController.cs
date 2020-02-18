using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.Infrastructure.Mapper;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private const int TextAdLength = 200;
        private const int PageSize = 4;
        private IArticleService ArticleService { get; }

        public HomeController(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        public ActionResult Index(int page = 1)
        {
            var articles = ArticleService.GetArticles().ToList().OrderByDescending(x => x.Date);

            return View(articles.ToArticleAdVm(TextAdLength).ToPagedList(page, PageSize));
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