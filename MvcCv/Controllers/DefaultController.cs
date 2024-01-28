using MvcCv.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcCv.Controllers
{
    [AllowAnonymous] //buraya da cv sitesini herkez görsün ulaşabilsin diye
    //Global.asax a yazılan GlobalFilters.Filters.Add(new AuthorizeAttribute()); bu kod
    //izinsiz erişimi engelliyor [AllowAnonymous] bunu yazınca izin veriyoruz erişime
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitim = db.TblEğitimlerim.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult Yetenek()
        {
            var yetenek = db.TblYeteneklerim.ToList();
            return PartialView(yetenek);
        }

        public PartialViewResult Hobi()
        {
            var hobi = db.TblHobilerim.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyal = db.TblSosyalMedya.Where(x=>x.durum==true).ToList();
            return PartialView(sosyal);
        }
        public PartialViewResult Sertifika()
        {
            var sertifika = db.TblSertifikalarım.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(TblIletisim t)
        {
           t.Tarih=DateTime.Parse( DateTime.Now.ToShortDateString());
           db.TblIletisim.Add(t);
           db.SaveChanges();
           return PartialView();
        }
    }
}