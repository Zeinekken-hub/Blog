using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using BlogMvcApp.DLL.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new EFUnitOfWork("BlogContext");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id = 1)
        {
            var article = unitOfWork.Articles.Get(id);
            if (article == null) return HttpNotFound();

            return View(article);
        }

        [HttpPost]
        public ActionResult SendFeedback(Feedback feedback)
        {
            unitOfWork.Feedbacks.Create(feedback);
            unitOfWork.Save();

            return Redirect($"/Article/Display/{feedback.Id}");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = new SelectList(unitOfWork.Genres.GetAll(), "Id", "Name");
            ViewBag.Genres = genres;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            unitOfWork.Articles.Create(article);
            unitOfWork.Save();

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Genre(string genreName)
        {
            var genre = unitOfWork.Genres
                .GetAll()
                .FirstOrDefault(g => g.Name == genreName);

            if (genre == null || genre.Articles.Count == 0)
                return HttpNotFound();

            var articles = genre.Articles;

            return View(articles);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();
            var article = unitOfWork.Articles.Get((int)id);
            if (article == null) return HttpNotFound();

            return View(article);
        }

        [HttpPost]
        public ActionResult Delete(Article article)
        {
            unitOfWork.Articles.Delete(article.Id);
            unitOfWork.Save();

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var article = unitOfWork.Articles.Get((int)id);
            if (article == null) return HttpNotFound();

            var genres = new SelectList(unitOfWork.Genres.GetAll(), "Id", "Name", article.GenreId);
            ViewBag.Genres = genres;

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            unitOfWork.Articles.Update(article);
            unitOfWork.Save();

            return Redirect($"/Article/Display/{article.Id}");
        }
    }
}