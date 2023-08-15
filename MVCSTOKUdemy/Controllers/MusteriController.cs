using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;


namespace MVCSTOKUdemy.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var mst = db.Tbl_Müsteri.ToList();
            return View(mst);
        }
        public ActionResult Aktifyap(int id)
        {
            var mst = db.Tbl_Müsteri.Find(id);
            mst.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var mst = db.Tbl_Müsteri.Find(id);
            mst.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Musekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Musekle(Tbl_Müsteri p)
        {
            db.Tbl_Müsteri.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Musguncelle(int id)
        {
            var bul = db.Tbl_Müsteri.Find(id);
            return View("Musguncelle", bul);
        }
        [HttpPost]
        public ActionResult Musguncelle(Tbl_Müsteri p)
        {
            var bul = db.Tbl_Müsteri.Find(p.Id);
            bul.Musad = p.Musad;
            bul.Mussoyad = p.Mussoyad;
            bul.Sehir = p.Sehir;
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}