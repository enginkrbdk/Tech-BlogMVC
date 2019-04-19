using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            var articles=  db.Articles.ToList();

            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _CategoryPartial()
        {
            var liste = db.Categories.ToList();

            return View(liste);
        }
        [HttpGet]
        public ActionResult ArticleInfo(int id)
        {
            var article = db.Articles.Where(x => x.Id == id).FirstOrDefault();


            ViewBag.Message = "Your contact page.";

            return View(article);
        }


        [HttpPost]
        public ActionResult ArticleInfo(int id,string text)
        {
            Comment cmd = new Comment();

            cmd.C_Content = text;
            cmd.Article = db.Articles.Find(id);
            cmd.User= db.Users.Find(Convert.ToInt32(Session["userId"]));
            db.Comments.Add(cmd);
            db.SaveChanges();
            db.Comments.OrderByDescending(x => x.Date);
            return RedirectToAction("ArticleInfo", "Home");
        }

        public ActionResult NewArticle()
        {



            return View();

        }

    }
}