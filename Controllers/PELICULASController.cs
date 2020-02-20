using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astrofilm.Models;

namespace Astrofilm.Controllers
{
    public class PELICULASController : Controller
    {
        private AstrofilmEntities db = new AstrofilmEntities();
        
        // GET: PELICULAS
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var pELICULAS = db.PELICULAS.Include(l => l.IDPelicula);
            return View(pELICULAS.ToList());
        }

        // GET: VISTA DEL ARCHIVO DE PELICULAS
        public ActionResult ArchivoPelis(string queryBusqueda)
        {

            // Para buscar avisos por nombre de empleado en la lista de valores
            var peli = db.PELICULAS.Include(a=>a.FUNCIONES);
            if (!String.IsNullOrEmpty(queryBusqueda))
            {
                peli = peli.Where(s => s.Titulo.Contains(queryBusqueda));
            }

            return View(peli.ToList());

            //return View(db.PELICULAS.ToList());
        }

        // GET: PELICULAS/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULAS pELICULAS = db.PELICULAS.Find(id);
            if (pELICULAS == null)
            {
                return HttpNotFound();
            }
            return View(pELICULAS);
        }

        // GET: PELICULAS/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PELICULAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPelicula,Titulo,Año,PuntMedia,Imagen")] PELICULAS pELICULAS, HttpPostedFileBase Imagen)
        {
            if (ModelState.IsValid)
            {
                db.PELICULAS.Add(pELICULAS);
                db.SaveChanges();
                pELICULAS.Imagen = pELICULAS.IDPelicula + Path.GetExtension(Imagen.FileName);
                db.Entry(pELICULAS).State = EntityState.Modified;
                db.SaveChanges();
                Imagen.SaveAs(Server.MapPath("~/Content/Images/Peliculas/" + pELICULAS.Imagen));
                return RedirectToAction("Index");
            }
            return View(pELICULAS);
        }

        // GET: PELICULAS/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULAS pELICULAS = db.PELICULAS.Find(id);
            Session["nombreImagenAnterior"] = pELICULAS.Imagen;
            if (pELICULAS == null)
            {
                return HttpNotFound();
            }
            return View(pELICULAS);
        }

        // POST: PELICULAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPelicula,Titulo,Año,PuntMedia,Email,Premium,Imagen")] PELICULAS pELICULAS, HttpPostedFileBase Imagen)
        {
            if (ModelState.IsValid)
            {
                if(Imagen == null)
                {
                    // Cojo la imagen anterior
                    //PELICULAS peliAntes = db.PELICULAS.Find(pELICULAS.IDPelicula);
                    pELICULAS.Imagen = (string)Session["nombreImagenAnterior"];// "5.jpg";//peliAntes.Imagen;
                    Session["nombreImagenAnterior"] = null;
                }
                else
                {
                    pELICULAS.Imagen = pELICULAS.IDPelicula + Path.GetExtension(Imagen.FileName);
                    Imagen.SaveAs(Server.MapPath("~/Content/Images/Peliculas/" + pELICULAS.Imagen));
                }

                db.Entry(pELICULAS).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(pELICULAS);
        }

        // GET: PELICULAS/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULAS pELICULAS = db.PELICULAS.Find(id);
            if (pELICULAS == null)
            {
                return HttpNotFound();
            }
            return View(pELICULAS);
        }

        // POST: PELICULAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PELICULAS pELICULAS = db.PELICULAS.Find(id);

            if (pELICULAS == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (pELICULAS.Imagen != null)
                {// Hay una condición extra que comprueba. Ver apuntes.
                    DirectoryInfo Directorio = new
                        DirectoryInfo(Server.MapPath("~/Content/Images/Peliculas/"));
                    FileInfo[] Imagenes = Directorio.GetFiles(pELICULAS.Imagen);
                    if (Imagenes.Count() > 0)
                    {
                        Imagenes[0].Delete();
                    }
                }
                db.PELICULAS.Remove(pELICULAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public static void InnerJoinEx()
        // {
        //     var query = from peli in PELICULAS
        //                 join trabajador in peli.TRABAJADORES 
        // }
        // public class MyViewModel
        // {
        //     public List<PELICULASController> 
        // }
    }
}
