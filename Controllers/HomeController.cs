using Astrofilm.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astrofilm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DefaultConnection db = new DefaultConnection();
            AstrofilmEntities db = new AstrofilmEntities();

            // Si existe el empleado correspondiente al usuario actual
            // se va a View, en caso contrario se va a crear el empleado.
            string usuario = User.Identity.GetUserName();
            var empleado = db.USUARIOS.Where(e => e.Email == usuario).FirstOrDefault();
            if (User.Identity.IsAuthenticated &&
            User.IsInRole("Usuario") &&
            empleado == null)
            {
                return RedirectToAction("Create", "MisDatos");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}