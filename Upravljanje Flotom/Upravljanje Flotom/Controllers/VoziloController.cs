using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upravljanje_Flotom.DAL;
using Upravljanje_Flotom.Models;
using Upravljanje_Flotom.Utils;

namespace Upravljanje_Flotom.Controllers
{
    public class VoziloController : Controller
    {
        // GET: Vozilo
        IRepo repo = RepoFactory.GetRepo();
        DisconnectedRepo dRepo = new DisconnectedRepo();
        public ActionResult AllAuti()
        {
            ViewBag.tip = repo.getAllTipVozila();
            ViewBag.marka = dRepo.getAllMarkaVozila();//repo.getAllMarkaVozila();
            return View(repo.getAllVozila());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.tip = repo.getAllTipVozila();
            ViewBag.marka = repo.getAllMarkaVozila();
            ViewBag.godine = repo.getGodine();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vozilo v)
        {
            //repo.insertVozilo(v);
            dRepo.insertVozilo(v);
            return RedirectToAction("AllAuti");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.tip = repo.getAllTipVozila();
            ViewBag.marka = repo.getAllMarkaVozila();
            ViewBag.godine = repo.getGodine();
            return View(repo.getVozilo(id));
        }
        [HttpPost]
        public ActionResult Edit(Vozilo v)
        {
            repo.updateVozilo(v);
            return RedirectToAction("AllAuti");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            repo.deleteVozilo(id);
            return RedirectToAction("AllAuti");
        }
        
        public ActionResult GenerateReport(int id)
        {
            VoziloReport r = new VoziloReport();
            r.generateReport(id);
            return RedirectToAction("AllAuti");
        }


    }
}