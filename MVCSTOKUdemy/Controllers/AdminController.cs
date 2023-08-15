using MVCSTOKUdemy.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCSTOKUdemy.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var admin = db.Tbl_Admin.ToList();
            return View(admin);
        }
        public ActionResult Adminsil(int id)
        {
            var bul = db.Tbl_Admin.Find(id);
            db.Tbl_Admin.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Adminekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminekle(Tbl_Admin p)
        {
            db.Tbl_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
    }
}