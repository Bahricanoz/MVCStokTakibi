using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;

namespace MVCSTOKUdemy.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var per = db.Tbl_Personel.ToList();
            return View(per);
        }
        public ActionResult Aktifyap(int id)
        {
            var akf = db.Tbl_Personel.Find(id);
            akf.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var psf = db.Tbl_Personel.Find(id);
            psf.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Perekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Perekle(Tbl_Personel p)
        {
            db.Tbl_Personel.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Perguncelle(int id)
        {
            var bul = db.Tbl_Personel.Find(id);
            return View("Perguncelle", bul);
        }
        [HttpPost]
        public ActionResult Perguncelle(Tbl_Personel p)
        {
            var per = db.Tbl_Personel.Find(p.Id);
            per.Personelad = p.Personelad;
            per.Personelsoyad = p.Personelsoyad;
            per.Departman = p.Departman;
            per.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}