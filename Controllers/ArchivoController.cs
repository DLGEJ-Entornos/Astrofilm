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
                IDPelicula = db.IDPelicula.toList(),
                Titulo = db.Titulo.toList(),
                IDTrabajador = db.IDTrabajador.toList(),
                Tipo = db.Tipo.toList(),
                IDGenero = db.IDGenero.toList(),
                Nombre = db.Nombre.toList(),
                IDLista = db.IDLista.toList(),
                Titutlo = db.Titutlo.toList()

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