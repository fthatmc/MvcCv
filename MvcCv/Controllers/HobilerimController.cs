using MvcCv.Models.Entitiy;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        HobiRepository repo = new HobiRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim t)
        {
            var hobi = repo.Find(x=>x.ID == 1);
            hobi.Aciklama1 = t.Aciklama1;
            repo.Update(hobi);
            return RedirectToAction("Index");
        }
    }
}