using Astrofilm.Models;
using Astrofilm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astrofilm.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly AstrofilmEntities1 db = new AstrofilmEntities1();

        // GET: Archivo
        public ActionResult Index()
        {
            var tablas = new ArchivoViewModel
            {
                PELICULAS = db.PELICULAS.ToList(),
                LISTAS = db.LISTAS.ToList(),
                GENEROS = db.GENEROS.ToList(),
                TRABAJADORES = db.TRABAJADORES.ToList()
            };
            return View();
        }
    }
}