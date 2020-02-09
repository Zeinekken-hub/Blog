using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Send(string nameAuthor, string text)
        {
            ViewBag.Name = nameAuthor;
            ViewBag.Text = text;
            ViewBag.Date = DateTime.Now;

            return View("Index");
        }
    }
}