using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upravljanje_Flotom;
using Upravljanje_Flotom.DAL;

namespace Upravljanje_Flotom.Controllers
{
    public class ServisController : Controller
    {
        private PPPKFleetManagementEntities db = new PPPKFleetManagementEntities();
        IRepo repo = RepoFactory.GetRepo();

        // GET: Servis
        public ActionResult Index()
        {
            return View(db.Servis.ToList());
        }

        // GET: Servis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // GET: Servis/Create
        public ActionResult Create()
        {
            ViewBag.vozila = repo.getAllVozila();
            return View();
        }

        // POST: Servis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDServis,Naziv,Detalji,Cijena,VoziloID")] Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Servis.Add(servi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servi);
        }

        // GET: Servis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // POST: Servis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDServis,Naziv,Detalji,Cijena,VoziloID")] Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servi);
        }

        // GET: Servis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // POST: Servis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servi servi = db.Servis.Find(id);
            db.Servis.Remove(servi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ServisiZaAuto(int id)
        {
            //Sloziti da mi ta metoda vraca servise
            //return View(db.GET_SERVISI_FOR_VOZILO(id));
            List<Servi> servisi = new List<Servi>();
            foreach (GET_SERVISI_FOR_VOZILO_Result item in db.GET_SERVISI_FOR_VOZILO(id))
            {
                int idServis = item.IDServis;
                string naziv = item.Naziv;
                string detalji = item.Detalji;
                double cijena=double.Parse(item.Cijena.ToString());
                int idvozilo = int.Parse(item.VoziloID.ToString());

                Servi s = new Servi();
                s.IDServis = idServis;
                s.Naziv = naziv;
                s.Detalji = detalji;
                s.Cijena = cijena;
                s.VoziloID = idvozilo;

                servisi.Add(s);
            }
            return View(servisi);
        }
    }
}
