using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;

namespace MVCSTOKUdemy.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var urun = db.Tbl_Urun.ToList();
            return View(urun);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Urun.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Urun.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Urunekle()
        {
            List<SelectListItem> mrk = (from x in db.Tbl_Marka.Where(x => x.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Markaadi,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.mrk = mrk;
            List<SelectListItem> ktg = (from x in db.Tbl_Kategori.Where(x => x.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Kategoriad,
                                            Value= x.Id.ToString()
                                        }).ToList();
            ViewBag.ktg = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult Urunekle(Tbl_Urun p)
        {
            var marka = db.Tbl_Marka.Where(x => x.Id == p.Tbl_Marka.Id).FirstOrDefault();
            var ktg = db.Tbl_Kategori.Where(x => x.Id == p.Tbl_Kategori.Id).FirstOrDefault();
            p.Tbl_Marka = marka;
            p.Tbl_Kategori = ktg;
            db.Tbl_Urun.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            List<SelectListItem> mrk = (from x in db.Tbl_Marka.Where(x=>x.Durum== true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Markaadi,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.mrk = mrk;
            List<SelectListItem> ktg = (from x in db.Tbl_Kategori.Where(x => x.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Kategoriad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.ktg = ktg;
            var bul = db.Tbl_Urun.Find(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Urun p)
        {
            var urn = db.Tbl_Urun.Find(p.Id);
            urn.Urunad = p.Urunad;
            urn.Markaid = p.Markaid;
            urn.Katid = p.Katid;
            urn.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}