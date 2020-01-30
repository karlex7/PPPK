using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upravljanje_Flotom.DAL;
using Upravljanje_Flotom.Models;

namespace Upravljanje_Flotom.Controllers
{
    public class PutniNalogController : Controller
    {
        // GET: PutniNalog
        IRepo repo = RepoFactory.GetRepo();
        DisconnectedRepo dRepo = new DisconnectedRepo();
        public ActionResult AllPutniNalog(int?status)
        {
            ViewBag.vozac = repo.getAllVozaci();
            List<PutniNalog> putniNalozi = dRepo.loadPtuniNalogXML();//repo.getAllPutniNalog();//
            foreach (PutniNalog item in putniNalozi)
            {
                item.PostaviStanje();
            }
            if (status==null)
            {
                return View(putniNalozi);
            }

            Status s = new Status();
            s = Status.Buduci;

            switch (status)
            {
                case 1: 
                    s = Status.Zavrseni;
                    break;
                case 2:
                    s = Status.Otvoreni;
                    break;
                case 3:
                    s = Status.Buduci;
                    break;

                default:
                    break;
            }


            return View(putniNalozi.Where(p=>p.Stanje==s));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.vozac = repo.getAllVozaci();
            //Tu ubaciti slobodna vozila ili negdje drugde
            ViewBag.vozila = repo.getAllVozila();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PutniNalog p)
        {
            repo.insetPutniNalog(p);
            return RedirectToAction("AllPutniNalog");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.vozac = repo.getAllVozaci();
            ViewBag.vozila = repo.getAllVozila();
            return View(repo.GetPutniNalog(id));
        }
        [HttpPost]
        public ActionResult Edit(PutniNalog p)
        {
            repo.updatePutniNalog(p);
            return RedirectToAction("AllPutniNalog");
        }
        public ActionResult Delete(int id)
        {
            repo.deletePutniNalog(id);
            return RedirectToAction("AllPutniNalog");
        }
        //[HttpGet]
        public ActionResult ExportXML()
        {
            dRepo.exportPutniNalogXML();
            return RedirectToAction("AllPutniNalog");
        }
    }
}