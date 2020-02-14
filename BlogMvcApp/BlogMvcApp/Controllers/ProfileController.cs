using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ProfileController : Controller
    {
        private IArticleService ArticleService { get; }
        private IProfileService ProfileService { get; }
        public ProfileController(IArticleService articleService,
            IProfileService profileService)
        {
            ProfileService = profileService;
            ArticleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(Questionnaire questionnaire)
        {
            ProfileService.SendProfile(questionnaire);

            var articles = ArticleService.GetArticlesByGenreMood(questionnaire);


            return View(articles);
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}