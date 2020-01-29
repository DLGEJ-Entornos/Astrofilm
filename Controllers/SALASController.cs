using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astrofilm.Models;

namespace Astrofilm.Controllers
{
    public class SALASController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: SALAS
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.SALAS.ToList());
        }

        // GET: SALAS/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALAS sALAS = db.SALAS.Find(id);
            if (sALAS == null)
            {
                return HttpNotFound();
            }
            return View(sALAS);
        }

        // GET: SALAS/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSala,Aforo,Ciudad")] SALAS sALAS)
        {
            if (ModelState.IsValid)
            {
                db.SALAS.Add(sALAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALAS);
        }

        // GET: SALAS/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALAS sALAS = db.SALAS.Find(id);
            if (sALAS == null)
            {
                return HttpNotFound();
            }
            return View(sALAS);
        }

        // POST: SALAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSala,Aforo,Ciudad")] SALAS sALAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALAS);
        }

        // GET: SALAS/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALAS sALAS = db.SALAS.Find(id);
            if (sALAS == null)
            {
                return HttpNotFound();
            }
            return View(sALAS);
        }

        // POST: SALAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALAS sALAS = db.SALAS.Find(id);
            db.SALAS.Remove(sALAS);
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
    }
}
