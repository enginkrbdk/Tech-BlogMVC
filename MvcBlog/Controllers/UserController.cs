using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class UserController : Controller
    {
        BlogContext db = new BlogContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(HttpPostedFileBase imageinput, string fullname, string username, string email, string password)
        {

            if (ModelState.IsValid)
            {
                User u = new User();


                var yol = Server.MapPath("/Content/images/user/");  //fotografı kaydedicek olduğu yeri bulucak olduğu yer
                var dosyaad = imageinput.FileName; //aşka bir isim vermek istersen uzantısıyla yazman gerek

                imageinput.SaveAs(yol + dosyaad); //araya / koymadım uploads sonunda olduğundan dolayı 

                u.FullName = fullname;
                u.UserName = username;
                u.Password = password;
                u.PhotoUrl = dosyaad;
                u.Mail = email;

                db.Users.Add(u);
                db.SaveChanges();
                Session["userId"] = u.Id;
                Session["uname"] = u.UserName;

            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (login != null)
            {

                Session["userId"] = user.Id;
                Session["uname"] = user.UserName;
                return RedirectToAction("Index", "Home");


            }
            else
            {
                ViewBag.Error = "Username or Passoword is invalid!!";
                return View();
            }

        }
        public ActionResult LogOut()
        {
            Session["userId"] = null;
            Session.Abandon();


            return RedirectToAction("Index", "Home");



        }

    }
}