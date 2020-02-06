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
        private AstrofilmEntities db = new AstrofilmEntities();

        // GET: USUARIOS
        //[Authorize(Roles = "Administrador")] //Quiero que acceda cualquiera
        public ActionResult Index()
        {
            //var uSUARIOS = db.USUARIOS.Include(u => u.USUARIOS_AMIGOS);
            var ArchivoTablas = new ArchivoModels
            {
                Peliculas =db.PELICULAS.ToList(),
                Trabajadores = db.TRABAJADORES.ToList(),
                Generos = db.GENEROS.ToList(),
                Listas = db.LISTAS.ToList(),
            };
            return View(ArchivoTablas);
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