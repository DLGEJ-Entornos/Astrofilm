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
    public class TRABAJADORESController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: TRABAJADORES
        public ActionResult Index()
        {
            return View(db.TRABAJADORES.ToList());
        }

        // GET: TRABAJADORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADORES tRABAJADORES = db.TRABAJADORES.Find(id);
            if (tRABAJADORES == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADORES);
        }

        // GET: TRABAJADORES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRABAJADORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTrabajador,Tipo,Apellido,Nombre,FecNac,Pais")] TRABAJADORES tRABAJADORES)
        {
            if (ModelState.IsValid)
            {
                db.TRABAJADORES.Add(tRABAJADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRABAJADORES);
        }

        // GET: TRABAJADORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADORES tRABAJADORES = db.TRABAJADORES.Find(id);
            if (tRABAJADORES == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADORES);
        }

        // POST: TRABAJADORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTrabajador,Tipo,Apellido,Nombre,FecNac,Pais")] TRABAJADORES tRABAJADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRABAJADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRABAJADORES);
        }

        // GET: TRABAJADORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRABAJADORES tRABAJADORES = db.TRABAJADORES.Find(id);
            if (tRABAJADORES == null)
            {
                return HttpNotFound();
            }
            return View(tRABAJADORES);
        }

        // POST: TRABAJADORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRABAJADORES tRABAJADORES = db.TRABAJADORES.Find(id);
            db.TRABAJADORES.Remove(tRABAJADORES);
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
