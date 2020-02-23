using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astrofilm.Models;
using Microsoft.AspNet.Identity;

namespace Astrofilm.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class LISTASController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: LISTAS
        public ActionResult Index()
        {
            var lISTAS = db.LISTAS.Include(l => l.COLABORADORES_LISTAS).Include(l => l.USUARIOS);

            if (User.IsInRole("Usuario"))
            {
                var emailUsuario = User.Identity.GetUserName();
                ViewBag.emailUser = emailUsuario;
            }

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
            if (User.IsInRole("Usuario"))
            {
                var emailUsuario = User.Identity.GetUserName();
                ViewBag.PropietarioFK = new SelectList(db.USUARIOS.Where(u => u.Email == emailUsuario), "IdUsuario", "Nombre");
            }
            else
            {
                ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "FullName");
            }
            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK");
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
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "FullName", lISTAS.PropietarioFK);
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


            if (User.IsInRole("Usuario"))
            {
                var emailUsuario = User.Identity.GetUserName();
                ViewBag.PropietarioFK = new SelectList(db.USUARIOS.Where(u => u.Email == emailUsuario), "IdUsuario", "Nombre",lISTAS.PropietarioFK);
            }
            else
            {
                ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "FullName", lISTAS.PropietarioFK);
            }

            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK", lISTAS.IDLista);
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "FullName", lISTAS.PropietarioFK);
            ViewBag.PelisTitulo = new MultiSelectList(db.PELICULAS, "IDPelicula", "Titulo", lISTAS.PELICULAS);
            //new MultiSelectList(db.PELICULAS, "Titulo", "TitUlo", lISTAS.PELICULAS),
            return View(lISTAS);
        }

        // POST: LISTAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLista,Titulo,Publica,NElementos,PropietarioFK")] LISTAS lISTAS)
        {
            var peliculas = HttpContext.Request.Form["PelisTitulo"];
            if (ModelState.IsValid)
            {
                db.Entry(lISTAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLista = new SelectList(db.COLABORADORES_LISTAS, "IDListaFK", "IDListaFK", lISTAS.IDLista);
            ViewBag.PropietarioFK = new SelectList(db.USUARIOS, "IDUsuario", "FullName", lISTAS.PropietarioFK);
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
