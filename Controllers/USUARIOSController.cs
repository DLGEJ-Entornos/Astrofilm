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
using Microsoft.AspNet.Identity.EntityFramework;

namespace Astrofilm.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class USUARIOSController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: USUARIOS
        public ActionResult Index()
        {
            var uSUARIOS = db.USUARIOS.Include(u => u.USUARIOS_AMIGOS);
            return View(uSUARIOS.ToList());
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            ViewBag.IDUsuario = new SelectList(db.USUARIOS_AMIGOS, "IDAmigoFK", "IDAmigoFK");
            return View();
        }

        // POST: USUARIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUsuario,Apellidos,Nombre,FecNac,TipoUser,Email,Premium")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUsuario = new SelectList(db.USUARIOS_AMIGOS, "IDAmigoFK", "IDAmigoFK", uSUARIOS.IDUsuario);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUsuario = new SelectList(db.USUARIOS_AMIGOS, "IDAmigoFK", "IDAmigoFK", uSUARIOS.IDUsuario);
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUsuario,Apellidos,Nombre,FecNac,TipoUser,Email,Premium")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUsuario = new SelectList(db.USUARIOS_AMIGOS, "IDAmigoFK", "IDAmigoFK", uSUARIOS.IDUsuario);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CrearAdministrador
        public ActionResult CrearAdministrador()
        {
            return View();
        }
        //
        // POST: /Usuarios/CrearAdministrador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearAdministrador(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                // Se crea el usuario
                var user = new ApplicationUser();
                user.UserName = model.Email; ;
                user.Email = model.Email;
                string userPWD = model.Password;
                var result = userManager.Create(user, userPWD);
                // Agregar el usuario al rol de Administrador
                if (result.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Administrador");
                    return RedirectToAction("Index");
                }
                // Gestión de errores:
                // Se agrega el mensaje del error producido al ValidationSummary de la Vista
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            // Se muestra la vista nuevamente, porque se ha producido un error
            return View(model);
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
