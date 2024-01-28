using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        HakkımdaRepository repo = new HakkımdaRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Ad=p.Ad;
            h.Soyad=p.Soyad;
            h.Adres=p.Adres;
            h.Mail=p.Mail;
            h.Telefon=p.Telefon;
            h.Açıklama = p.Açıklama;
            h.Resim=p.Resim;
            repo.Update(h);
            return RedirectToAction("Index");
        }
    }
}