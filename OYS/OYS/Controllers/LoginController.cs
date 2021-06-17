using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using OYS.Models.veritabani;
using System.Web.Security;

namespace OYS.Controllers
{
    public class LoginController : Controller
    {
        oysEntities2 db = new oysEntities2();
        
        public ActionResult Login()
        {
            var user = Session["User"] as UYELER;
            user = null;

            return View();
        }
        [HttpPost]
        public ActionResult Login(UYELER uModel)
        {
            var user = db.UYELER.FirstOrDefault(u => u.uyeKullaniciAdi == uModel.uyeKullaniciAdi && u.uyeSifre == uModel.uyeSifre);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.uyeKullaniciAdi, false);
                Session["User"] = user;
                return RedirectToAction("Index", "Home", user.uyeKullaniciAdi);
            }
            else
            {
                ViewBag.ResultMessage = "Girdiğiniz şifre veya kullanıcı adı hatalı";
                ViewBag.ResultMessageCss = "alert alert-danger";
                return View();
            }

        }
        [HttpGet]
        public ActionResult kayitekle()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult kayitekle(UYELER p)
        {
            if (p != null)
            {
                db.UYELER.Add(p);
                db.SaveChanges();
                return RedirectToAction("kayitekle");
            }
            else
                return View("kayitekle");

        }
    }
}