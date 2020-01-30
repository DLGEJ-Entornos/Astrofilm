using Astrofilm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
         "Id,Nombre,Apellidos,FecNac,TipoUser,Premium")] USUARIOS usuario)
        {
            // Para asignar el Nombre del usuario identificado al campo Email de Empleado
            usuario.Email = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(usuario);
                db.SaveChanges();
                // Redirige a la acción Index del controlador Home
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

    }
}