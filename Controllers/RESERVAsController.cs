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
    public class RESERVAsController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: RESERVAs
        public ActionResult Index()
        {
            var rESERVA = db.RESERVA.Include(r => r.FUNCIONES).Include(r => r.USUARIOS);
            return View(rESERVA.ToList());
        }

        // GET: RESERVAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // GET: RESERVAs/Create
        public ActionResult Create()
        {
            ViewBag.IDFuncionFK = new SelectList(db.FUNCIONES, "IDFuncion", "IDFuncion");
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos");
            return View();
        }

        // POST: RESERVAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDReserva,FecReserva,NumButaca,IDUserFK,IDFuncionFK,PrecioNeto")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.RESERVA.Add(rESERVA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFuncionFK = new SelectList(db.FUNCIONES, "IDFuncion", "IDFuncion", rESERVA.IDFuncionFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", rESERVA.IDUserFK);
            return View(rESERVA);
        }

        // GET: RESERVAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFuncionFK = new SelectList(db.FUNCIONES, "IDFuncion", "IDFuncion", rESERVA.IDFuncionFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", rESERVA.IDUserFK);
            return View(rESERVA);
        }

        // POST: RESERVAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDReserva,FecReserva,NumButaca,IDUserFK,IDFuncionFK,PrecioNeto")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFuncionFK = new SelectList(db.FUNCIONES, "IDFuncion", "IDFuncion", rESERVA.IDFuncionFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", rESERVA.IDUserFK);
            return View(rESERVA);
        }

        // GET: RESERVAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.RESERVA.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // POST: RESERVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVA rESERVA = db.RESERVA.Find(id);
            db.RESERVA.Remove(rESERVA);
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
