using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Dictionary<string, string> ArticlesByGender = new Dictionary<string, string>
        {
            {"Sea", "female"},
            {"Depression", "female"},
            {"Auto", "male"},
            {"Angry", "male"},
            {"State", "custom"},
            {"Respect", "custom"}
        };

        private readonly List<string> BadArticles = new List<string>
        {
            "Depression", "Angry", "Respect"
        };

        public ActionResult Index()
        {
            ViewBag.Article = "";
            return View();
        }

        [HttpGet]
        public ActionResult Result()
        {
            ViewBag.FirstName = "Anonymous";
            ViewBag.LastName = "";
            return View();
        }

        [HttpPost]
        public ActionResult Result(string firstName,
                                    string lastName,
                                    string gender,
                                    bool? isAlone,
                                    bool? isStable,
                                    string language)
        {
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Language = language;

            var articlesByGender = GetArticlesByGender(gender);
            var article = GetArticlesByPsycho(articlesByGender, isAlone, isStable);
            if (article.Count == 0) return View();

            ViewBag.Article = article[0];

            return View();
        }

        private List<string> GetArticlesByGender(string gender)
        {
            var result = new List<string>();

            foreach (KeyValuePair<string, string> keyValuePair in ArticlesByGender)
            {
                if (keyValuePair.Value == gender)
                {
                    result.Add(keyValuePair.Key);
                }
            }

            return result;
        }

        private List<string> GetArticlesByPsycho(List<string> articles,
                                                       bool? isAlone,
                                                       bool? isStable)
        {
            if (isAlone == null || isStable == null)
            {
                return articles.Except(BadArticles).ToList();
            }
            else
            {
                return articles.Intersect(BadArticles).ToList();
            }
        }
    }
}