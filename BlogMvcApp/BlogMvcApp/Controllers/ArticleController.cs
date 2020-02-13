using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleSerivce ArticleSerivce { get; }
        private IGenreService GenreService { get; }
        private IFeedbackService FeedbackService { get; }

        public ArticleController(IArticleSerivce articleService,
                                 IFeedbackService feedbackService,
                                 IGenreService genreService)
        {
            ArticleSerivce = articleService;
            FeedbackService = feedbackService;
            GenreService = genreService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id = 1)
        {
            var article = ArticleSerivce.GetArticleById(id);
            if (article == null) return HttpNotFound();

            return View(article);
        }

        [HttpPost]
        public ActionResult SendFeedback(Feedback feedback)
        {
            FeedbackService.SendFeedback(feedback);

            return Redirect($"/Article/Display/{feedback.Id}");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = new SelectList(GenreService.GetGenres(), "Id", "Name");
            ViewBag.Genres = genres;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            ArticleSerivce.Create(article);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Genre(string genreName)
        {
            var genre = GenreService.GetGenreByName(genreName);

            if (genre == null) return HttpNotFound();

            var articles = genre.Articles;

            return View(articles);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var article = ArticleSerivce.GetArticleById((int)id);

            if (article == null) return HttpNotFound();

            return View(article);
        }

        [HttpPost]
        public ActionResult Delete(Article article)
        {
            ArticleSerivce.Delete(article);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var article = ArticleSerivce.GetArticleById((int)id);
            if (article == null) return HttpNotFound();

            var genres = new SelectList(GenreService.GetGenres(), "Id", "Name", article.GenreId);
            ViewBag.Genres = genres;

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            ArticleSerivce.EditArticle(article);

            return Redirect($"/Article/Display/{article.Id}");
        }
    }
}