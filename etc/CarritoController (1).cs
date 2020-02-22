using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaInstrumentos.Models;

namespace TiendaInstrumentos.Controllers
{
    public class CarritoController : Controller
    {
        TiendaInstrumentosEntities db = new TiendaInstrumentosEntities();
        // GET: Carrito
        public ActionResult Index()
        {
            if (Session["Pedido"] == null)
                return RedirectToAction("CarritoVacio");

            int idPedido = (int)Session["Pedido"];
            var lineas = db.LINEAS_PEDIDO.Where(a => a.IdPedido == idPedido);

            ViewBag.idPedido = idPedido;

            return View(lineas.ToList());
        }

        public ActionResult CarritoVacio()
        {

            return View();
        }

        public ActionResult ConfirmarCarrito(int id)
        {
            PRODUCTO producto = db.PRODUCTO.Find(id);

            return View(producto);

        }

        public ActionResult AgregarCarrito(int id)
        {
            if(Session["Pedido"] == null)
            {
                string usuario = User.Identity.GetUserName();
                CLIENTE cliente = db.CLIENTE.Where(e => e.CorCli == usuario).FirstOrDefault();

                PEDIDO pedido = new PEDIDO();

                pedido.IdCliente = cliente.Id;
                pedido.IdEstado = 1;
                pedido.FecPed = DateTime.Now;

                db.PEDIDO.Add(pedido);
                db.SaveChanges();

                Session["Pedido"] = pedido.Id;
            }

            LINEAS_PEDIDO linea = new LINEAS_PEDIDO();
            PRODUCTO producto = db.PRODUCTO.Find(id);

            linea.IdPedido = (int)Session["Pedido"];
            linea.IdProducto = producto.Id;
            linea.PrecioDet = producto.PrePro;
            linea.Cantidad = 1;

            db.LINEAS_PEDIDO.Add(linea);
            db.SaveChanges();

            return RedirectToAction("Index", "Escaparate");
        }

        // GET: Carrito/ConfirmarCompra/5
        public ActionResult ConfirmarCompra(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pedido = db.PEDIDO.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Carrito/ConfirmarCompra/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarCompra(int id)
        {
            PEDIDO pedido = db.PEDIDO.Find(id);
            pedido.IdEstado = 2;
            db.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            Session["Pedido"] = null;

            return RedirectToAction("Index", "Home");
        }


        // GET: Carrito/EliminarLinea/5
        public ActionResult EliminarLinea(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEAS_PEDIDO linea = db.LINEAS_PEDIDO.Find(id);
            if (linea == null)
            {
                return HttpNotFound();
            }
            return View(linea);
        }

        // POST: Carrito/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarLinea(int id)
        {
            LINEAS_PEDIDO linea = db.LINEAS_PEDIDO.Find(id);
            db.LINEAS_PEDIDO.Remove(linea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}