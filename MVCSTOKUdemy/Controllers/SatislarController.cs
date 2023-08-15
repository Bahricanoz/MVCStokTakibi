using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKUdemy.Models.Entity;

namespace MVCSTOKUdemy.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satis = db.tbl_satis.ToList();
            return View(satis);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.tbl_satis.Find(id);
            bul.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.tbl_satis.Find(id);
            bul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  ActionResult Ekle()
        {
            List<SelectListItem> urn= (from x in db.Tbl_Urun.Where(x =>x.Durum == true).ToList()
                                      select new SelectListItem
                                      {
                                          Text = x.Urunad + " " + x.Tbl_Marka.Markaadi,
                                          Value = x.Id.ToString()
                                      }).ToList();
            ViewBag.urn = urn;
            List<SelectListItem> per = (from x in db.Tbl_Personel.Where(x => x.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Personelad + " " + x.Personelsoyad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.per = per;
            List<SelectListItem> mus = (from x in db.Tbl_Müsteri.Where(x => x.Durum == true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Musad + " "+ x.Mussoyad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.mus = mus;
            return View();
        }
        public ActionResult Ekle(tbl_satis p)
        {
            //p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_satis.Add(p);
            p.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}