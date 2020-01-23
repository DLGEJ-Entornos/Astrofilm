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
    public class FUNCIONESController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: FUNCIONES
        public ActionResult Index()
        {
            var fUNCIONES = db.FUNCIONES.Include(f => f.PELICULAS).Include(f => f.SALAS);
            return View(fUNCIONES.ToList());
        }

        // GET: FUNCIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Create
        public ActionResult Create()
        {
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo");
            ViewBag.IDSalaFK = new SelectList(db.SALAS, "IDSala", "Ciudad");
            return View();
        }

        // POST: FUNCIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFuncion,Fecha,Disponibles,PrecioBruto,IDPeliFK,IDSalaFK")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                db.FUNCIONES.Add(fUNCIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", fUNCIONES.IDPeliFK);
            ViewBag.IDSalaFK = new SelectList(db.SALAS, "IDSala", "Ciudad", fUNCIONES.IDSalaFK);
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", fUNCIONES.IDPeliFK);
            ViewBag.IDSalaFK = new SelectList(db.SALAS, "IDSala", "Ciudad", fUNCIONES.IDSalaFK);
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFuncion,Fecha,Disponibles,PrecioBruto,IDPeliFK,IDSalaFK")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUNCIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", fUNCIONES.IDPeliFK);
            ViewBag.IDSalaFK = new SelectList(db.SALAS, "IDSala", "Ciudad", fUNCIONES.IDSalaFK);
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FUNCIONES fUNCIONES = db.FUNCIONES.Find(id);
            db.FUNCIONES.Remove(fUNCIONES);
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
