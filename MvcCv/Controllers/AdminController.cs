using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class AdminController : Controller
    {
        AdminRepository repo = new AdminRepository();
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }


        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin a)
        {
            repo.Add(a);
            return RedirectToAction("Index");
        }


        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}