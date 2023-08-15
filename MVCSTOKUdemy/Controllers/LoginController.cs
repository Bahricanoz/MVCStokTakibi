using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCSTOKUdemy.Models.Entity;
//using System.Web.Security;


namespace MVCSTOKUdemy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbMvcStokEntities db = new DbMvcStokEntities();
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Tbl_Admin p)
        {
            var bilgiler = db.Tbl_Admin.FirstOrDefault(x => x.Kullanciadı == p.Kullanciadı && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanciadı, false);
                Session["Kullanciadı"] = bilgiler.Kullanciadı.ToString();
                return RedirectToAction("Index", "Marka");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Giris", "Login");
        }
    }
}