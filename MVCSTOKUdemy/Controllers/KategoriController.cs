using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;
namespace MVCSTOKUdemy.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var ktg = db.Tbl_Kategori.ToList();
            return View(ktg);
        }
        public ActionResult AktifYap(int id)
        {
            var ktg = db.Tbl_Kategori.Find(id);
            ktg.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var ktg = db.Tbl_Kategori.Find(id);
            ktg.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KatEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Katekle(Tbl_Kategori p)
        {
            db.Tbl_Kategori.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var bul = db.Tbl_Kategori.Find(id);
            return View("KategoriGuncelle",bul);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Tbl_Kategori p)
        {
            var ktg = db.Tbl_Kategori.Find(p.Id);
            ktg.Kategoriad = p.Kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index" , "Kategori");
        }
    }
}