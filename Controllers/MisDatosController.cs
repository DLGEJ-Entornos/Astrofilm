using Astrofilm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astrofilm.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatosController : Controller
    {
        AstrofilmEntities db = new AstrofilmEntities();
        // GET: MisDatos
        public ActionResult Index()
        {
            return View();
        }
        // GET: MisDatos/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: MisDatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
         "Id,Nombre,Apellidos,FecNac,TipoUser")] USUARIOS usuario)
        {
            // Para asignar el Nombre del usuario identificado al campo Email de  Usuario
            usuario.Email = User.Identity.GetUserName();
            //usuario.Premium = false;
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(usuario);
                db.SaveChanges();
                // Redirige a la acción Index del controlador Home
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
        // GET: MisDatos/Edit
        public ActionResult Edit()
        {
            // Se seleccionan los datos del empleado correspondiente al usuario actual
            string wUsuario = User.Identity.GetUserName();
            var usuario = db.USUARIOS.Where(e => e.Email == wUsuario).FirstOrDefault();
            if (usuario == null)
            {
                // Si no existe el empleado, redirige a la acción Index del controlador Home
                return RedirectToAction("Index", "Home");
            }
            // Si existe el empleado correspondiente se va a View
            return View(usuario);
        }
        // POST: MisDatos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        //"Id,Nombre,Apellidos,FecNac,TipoUser"
        public ActionResult Edit([Bind(Include =
         "Id,Nombre,Email,Apellidos,TipoUser,Premium,FecNac")] USUARIOS usuario)
        {
            usuario.Email = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
    }
}