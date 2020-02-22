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
    public class RESERVAsController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: RESERVAs
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var rESERVA = db.RESERVA.Include(r => r.FUNCIONES).Include(r => r.USUARIOS);
            var rUsers = db.USUARIOS.Include(r => r.RESERVA);

            if (User.IsInRole("Usuario"))
            {
                var emailUsuario = User.Identity.GetUserName();
                ViewBag.emailUser = emailUsuario;
                //var userLog = rUsers.Where(r => r.Email == emailUsuario);
                //ViewBag.IDUsersFK = db.USUARIOS.Where(u => u.Email == emailUsuario);
                //rESERVA.Where(r => r.IDUserFK);
                return View(rESERVA.ToList());
            }
            else
            {
                ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos");
                return View(rESERVA.ToList());
            }
        }

        // GET: RESERVAs/Details/5
        //[Authorize(Roles = "Administrador")]
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
        //[Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            if (User.IsInRole("Usuario"))
            {
                var emailUsuario = User.Identity.GetUserName();
                ViewBag.IDUserFK = new SelectList(db.USUARIOS.Where(u => u.Email == emailUsuario), "IdUsuario", "Nombre");
            }
            else
            {
                ViewBag.IDUserFK = new SelectList(db.USUARIOS, "IDUsuario", "Apellidos");
            }
            ViewBag.IDFuncionFK = new SelectList(db.FUNCIONES, "IDFuncion", "IDFuncion");
            return View();
        }

        // POST: RESERVAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDReserva,FecReserva,NumButaca,IDUserFK,IDFuncionFK,PrecioNeto")] RESERVA rESERVA)
        {
            
            FUNCIONES func = db.FUNCIONES.Find(rESERVA.IDFuncionFK);

            func.Disponibles = (func.Disponibles - 1);
            db.Entry(func).State = EntityState.Modified;
            db.SaveChanges();
            
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
        //[Authorize(Roles = "Administrador")]
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
        //[Authorize(Roles = "Administrador")]
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
