using BlogMvcApp.Attributes;
using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.Infrastructure.Mapper;
using BlogMvcApp.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ArticleController : Controller
    {
        private const int PageSize = 4;
        private IArticleService ArticleService { get; }
        private IFeedbackService FeedbackService { get; }
        public ArticleController(IArticleService articleService,
                                 IFeedbackService feedbackService)
        {
            ArticleService = articleService;
            FeedbackService = feedbackService;
        }

        public ActionResult Display(int id = 1)
        {
            var article = ArticleService.GetArticleById(id);
            if (article == null) return HttpNotFound();

            return View(article.ToArticleVm());
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult SendFeedback(Feedback feedback)
        {
            FeedbackService.SendFeedback(feedback);

            return Redirect($"/Article/Display/{feedback.ArticleId}");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult Create()
        {
            var tags = new SelectList(ArticleService.GetArticleTags(), "Name", "Name");
            ViewBag.Tags = tags;

            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult Create(Article article, ICollection<string> tagNames)
        {
            if (ModelState.IsValid)
            {
                ICollection<Tag> tags = tagNames
                    .Select(tagName => ArticleService.GetTagByName(tagName)).ToList();

                article.Tags = tags;

                ArticleService.CreateArticle(article);
            }

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Tag(string tagName, int page = 1)
        {
            if (tagName == null) return HttpNotFound();
            var articles = ArticleService.GetArticlesByTagName(tagName).ToList();
            var tag = ArticleService.GetTagByName(tagName);

            var objToView = new ArticleTagViewModel
            {
                Tag = tag.ToTagVm(),
                Articles = articles.ToArticleAdVm(100).ToPagedList(page, PageSize),
                PageSize = PageSize
            };

            return View(objToView);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var article = ArticleService.GetArticleById((int)id);

            if (article == null) return HttpNotFound();

            return View(article);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult Delete(Article article)
        {
            ArticleService.DeleteArticle(article);

            return Redirect("/Home/Index");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var article = ArticleService.GetArticleById((int)id);
            if (article == null) return HttpNotFound();

            var tags = new SelectList(ArticleService.GetArticleTags(), "Name", "Name");
            ViewBag.Tags = tags;

            return View(article);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult Edit(Article article, ICollection<string> tagNames)
        {
            ArticleService.EditArticle(article, tagNames);

            return Redirect($"/Article/Display/{article.Id}");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult TagAdder(string tagName)
        {
            var tag = ArticleService.GetTagByName(tagName);

            return PartialView(tag.ToTagVm());
        }

        [Authorize(Roles = "user")]
        public ActionResult DeleteTag()
        {
            return new EmptyResult();
        }
    }
}