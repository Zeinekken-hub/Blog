using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.Infrastructure.Mapper;
using System.Linq;
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


        [HttpPost]
        public ActionResult Vote(string mood)
        {
            return PartialView("ThankResult");
        }

        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArticleSearch(string name)
        {
            var allbooks = ArticleService.GetArticles()
                .ToList()
                .ToArticleVm()
                .Where(a => a.Title.Contains(name))
                .ToList();
            if (allbooks.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allbooks);
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}