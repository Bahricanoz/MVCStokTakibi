using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;

namespace MVCSTOKUdemy.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka
        
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var marka = db.Tbl_Marka.ToList();
            return View(marka);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Marka.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Marka.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Markaekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Markaekle(Tbl_Marka p)
        {
            db.Tbl_Marka.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MarkaGuncelle(int id)
        {
            var bul = db.Tbl_Marka.Find(id);
            return View("MarkaGuncelle", bul);
        }
        [HttpPost]
        public ActionResult MarkaGuncelle(Tbl_Marka p)
        {
            var bul = db.Tbl_Marka.Find(p.Id);
            bul.Markaadi = p.Markaadi;
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}