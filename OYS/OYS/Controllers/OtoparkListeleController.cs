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
    public class OtoparkListeleController : Controller

            
    {
        oysEntities2 db = new oysEntities2();

        
        public ActionResult OtoparkListele(string p)
        {
            var degerler =from d in db.OTOPARKLAR select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(OTOPARKLAR => OTOPARKLAR.otoparkAdi.Contains(p));
            }
            return View(degerler.ToList());
            
        }
        [HttpPost]
        public ActionResult OtoparkListele()
        {
            var oto = Session["oto"] as OTOPARKLAR;
            oto = null;
            return View();

        }

        [HttpGet]
        public ActionResult Rezervasyon()
        {
           
            return View();
            
        }
        [HttpPost]
        public ActionResult Rezervasyon( REZERVASYONLAR p)
        {

            var oto = Session["oto"] as OTOPARKLAR;
            if (oto == null)
            {
                return RedirectToAction("OtoparkListele", "OtoparkListele");
            }
            var otoparkID = oto.otoparkID;

            var user = Session["User"] as UYELER;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var uyeID = user.uyeID;
            

            db.REZERVASYONLAR.Add(p);
            db.SaveChanges();

            var rezervasyon = db.REZERVASYONLAR.Find(p.rezervasyonID);
            rezervasyon.otoparkID = otoparkID;
            rezervasyon.uyeID = uyeID;
            db.SaveChanges();

            return View("Odeme");
        }



        public ActionResult IdBul (int id)
        {
            var oto = db.OTOPARKLAR.FirstOrDefault(o=>o.otoparkID==id);
            Session["oto"] = oto;
            return RedirectToAction("Rezervasyon", "OtoparkListele", oto.otoparkID);

            //if(oto!=null) şeklinde kontrol edilirse daha iyi olurdu. Login sayfasındaki gibi.


            // var kisi = db.OTOPARKLAR.Find(id);   Sadece rezervasyon sayfasına geçişteid gönderen kod.
            // return View("Rezervasyon", kisi);    Nasıl kullanılacağını bulamadım pek işlevi olamadı.

        }

        public ActionResult Odeme()
        {
            return View();
        }
    }
}