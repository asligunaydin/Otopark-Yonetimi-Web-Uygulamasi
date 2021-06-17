using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using OYS.Models.veritabani;

namespace OYS.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        oysEntities2 db = new oysEntities2();
       
        public ActionResult gecmis()
        {
            var user = Session["User"] as UYELER;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            
            var listele = from d in db.GECMISLER select d;
            listele = listele.Where(u => u.uyeID == user.uyeID);
            return View(listele.ToList());
                      
        }
        [HttpGet]
        public ActionResult Guncelle()
        {
            var user = Session["User"] as UYELER;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var id = user.uyeID;
            var kisi = db.UYELER.Find(id);

            return View("Guncelle", kisi);
        }
        [HttpPost]
        public ActionResult Guncelle(UYELER uyeler)
        {
            var user = Session["User"] as UYELER;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            

            var kisi = db.UYELER.Find(user.uyeID);
            kisi.uyeAdi = uyeler.uyeAdi;
            kisi.uyeSoyadi = uyeler.uyeSoyadi;
            kisi.uyeEmail = uyeler.uyeEmail;
            kisi.uyeTelefon = uyeler.uyeTelefon;
            kisi.uyeKullaniciAdi = uyeler.uyeKullaniciAdi;
            kisi.uyeSifre = uyeler.uyeSifre;
            db.SaveChanges();
            return RedirectToAction("Guncelle");
           
        }




        /*  public ActionResult About()
          {
              ViewBag.Message = "Your application description page.";

              return View();
          }

          public ActionResult Contact()
          {
              ViewBag.Message = "Your contact page.";

              return View();
          } */
    }
}