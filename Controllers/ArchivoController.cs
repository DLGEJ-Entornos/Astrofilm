using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astrofilm.Models;
namespace Astrofilm.Controllers
{
    public class ArchivoController : Controller
    {
        private AstrofilmEntities astrofilmEntities = new AstrofilmEntities();

        ////////////////////////SUBSTITUYE POR ARCHIVO
        // GET: CRITICAS
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var cRITICAS = db.CRITICAS.Include(c => c.PELICULAS).Include(c => c.USUARIOS);
            return View(cRITICAS.ToList());
        }

        // GET: CRITICAS/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRITICAS cRITICAS = db.CRITICAS.Find(id);
            if (cRITICAS == null)
            {
                return HttpNotFound();
            }
            return View(cRITICAS);
        }

        // GET: CRITICAS/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo");
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos");
            return View();
        }

        // POST: CRITICAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCritica,Texto,IDUserFK,IDPeliFK")] CRITICAS cRITICAS)
        {
            if (ModelState.IsValid)
            {
                db.CRITICAS.Add(cRITICAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", cRITICAS.IDPeliFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", cRITICAS.IDUserFK);
            return View(cRITICAS);
        }

        // GET: CRITICAS/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRITICAS cRITICAS = db.CRITICAS.Find(id);
            if (cRITICAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", cRITICAS.IDPeliFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", cRITICAS.IDUserFK);
            return View(cRITICAS);
        }

        // POST: CRITICAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCritica,Texto,IDUserFK,IDPeliFK")] CRITICAS cRITICAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRITICAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPeliFK = new SelectList(db.PELICULAS, "IDPelicula", "Titulo", cRITICAS.IDPeliFK);
            ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos", cRITICAS.IDUserFK);
            return View(cRITICAS);
        }

        // GET: CRITICAS/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRITICAS cRITICAS = db.CRITICAS.Find(id);
            if (cRITICAS == null)
            {
                return HttpNotFound();
            }
            return View(cRITICAS);
        }

        // POST: CRITICAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRITICAS cRITICAS = db.CRITICAS.Find(id);
            db.CRITICAS.Remove(cRITICAS);
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