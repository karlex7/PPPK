using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upravljanje_Flotom.DAL;
using Upravljanje_Flotom.Models;

namespace Upravljanje_Flotom.Controllers
{
    public class VozacController : Controller
    {
        // GET: Vozac
        IRepo repo = RepoFactory.GetRepo();
        DisconnectedRepo dRepo = new DisconnectedRepo();
        public ActionResult AllVozaci()
        {
            //return View(repo.getAllVozaci());
            return View(dRepo.getVozacsXml());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vozac v)
        {
            repo.insertVozac(v);
            return RedirectToAction("AllVozaci");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.getVozac(id));
        }
        [HttpPost]
        public ActionResult Edit(Vozac v)
        {
            repo.updateVozac(v);
            return RedirectToAction("AllVozaci");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            repo.deleteVozac(id);
            return RedirectToAction("AllVozaci");
        }
        public ActionResult saveXML()
        {
            dRepo.writeVozacsXml();
            return RedirectToAction("AllVozaci");
        }

        
    }
}