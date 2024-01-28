using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        SosyalMedyaRepository repo = new SosyalMedyaRepository();
        public ActionResult Index()
        {
            var SosyalMedya = repo.List();
            return View(SosyalMedya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x=>x.ID==id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.icon = p.icon;
            hesap.durum = true;
            repo.Update(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x=> x.ID == id);
            hesap.durum = false;
            repo.Update(hesap);
            return RedirectToAction("Index");
        }
    }
}