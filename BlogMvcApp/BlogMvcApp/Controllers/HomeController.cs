using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlogMvcApp.BLL.Interfaces;
using System.Web.Mvc;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private const int TextAdLength = 500;
        private IArticleService ArticleService { get; }
        private IGenreService GenreService { get; }

        public HomeController(IArticleService articleService, IGenreService genreService)
        {
            ArticleService = articleService;
            GenreService = genreService;
        }

        public ActionResult Index()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Article, ArticleAdViewModel>()
                    .ForMember("Text", opt => opt.MapFrom(item => item.Text.Substring(0, TextAdLength)))
                    .ForMember("CommentCount", opt => opt.MapFrom(item => item.Feedbacks.Count));
            });

            var mapper = cfg.CreateMapper();
            var articles = ArticleService.GetArticles().ToList();
            var articlesAd = mapper.Map<IEnumerable<Article>, IEnumerable<ArticleAdViewModel>>(articles);

            return View(articlesAd);
        }

        public ActionResult DropDownList()
        {
            return PartialView(GenreService.GetGenres());
        }

        protected override void Dispose(bool disposing)
        {
            ArticleService.Dispose();
            base.Dispose(disposing);
        }
    }
}