using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class EgitimController : Controller
    {
        EğitimRepository repo = new EğitimRepository();
        // GET: Egitim
        
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEğitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Add(t);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TblEğitimlerim egitim = repo.Find(x => x.ID == id);
            repo.Delete(egitim);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEğitimlerim e)
        {
            var egitim = repo.Find(x => x.ID == e.ID);
            egitim.Baslik = e.Baslik;
            egitim.AltBaslik1 = e.AltBaslik1;
            egitim.AltBaslik2 = e.AltBaslik2;
            egitim.Tarih = e.Tarih;
            repo.Update(egitim);
            return RedirectToAction("Index");
        }

    }
}