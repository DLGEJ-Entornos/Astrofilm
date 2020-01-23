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
    public class LISTASController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: LISTAS
        public ActionResult Index()
        {
            var lISTAS = db.LISTAS.Include(l => l.COLABORADORES_LISTAS).Include(l => l.USUARIOS);
            return View(lISTAS.ToList());
        }

        // GET: LISTAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTAS lISTAS = db.LISTAS.Find(id);
            if (lISTAS == null)
            {
                return HttpNotFound();
            }
            return View(lISTAS);
        }

        // GET: LISTAS/Create
        public ActionResult Create()
        {
            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK");
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos");
            return View();
        }

        // POST: LISTAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLista,Titulo,Publica,NElementos,PropietarioFK")] LISTAS lISTAS)
        {
            if (ModelState.IsValid)
            {
                db.LISTAS.Add(lISTAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK", lISTAS.IDLista);
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", lISTAS.PropietarioFK);
            return View(lISTAS);
        }

        // GET: LISTAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTAS lISTAS = db.LISTAS.Find(id);
            if (lISTAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK", lISTAS.IDLista);
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", lISTAS.PropietarioFK);
            return View(lISTAS);
        }

        // POST: LISTAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLista,Titulo,Publica,NElementos,PropietarioFK")] LISTAS lISTAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lISTAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK", lISTAS.IDLista);
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", lISTAS.PropietarioFK);
            return View(lISTAS);
        }

        // GET: LISTAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTAS lISTAS = db.LISTAS.Find(id);
            if (lISTAS == null)
            {
                return HttpNotFound();
            }
            return View(lISTAS);
        }

        // POST: LISTAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LISTAS lISTAS = db.LISTAS.Find(id);
            db.LISTAS.Remove(lISTAS);
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
