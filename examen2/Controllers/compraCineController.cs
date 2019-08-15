using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examen2.Models;

namespace examen2.Controllers
{
    public class compraCineController : Controller
    {
        private CineContext db = new CineContext();

        // GET: compraCine
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            var compraCine = db.compraCine.Include(c => c.ticket);
            return View(compraCine.ToList());
        }

        // GET: compraCine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compraCine compraCine = db.compraCine.Find(id);
            if (compraCine == null)
            {
                return HttpNotFound();
            }
            return View(compraCine);
        }

        // GET: compraCine/Create
        public ActionResult Create()
        {
            ViewBag.tickets = new SelectList(db.ticket, "idTicket", "nombrePelicula");
            return View();
        }

        // POST: compraCine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compraCine compraCine)
        {
            double subtotal = 0;
            decimal cargoServicio = 0;
            decimal descuento = 0;
            decimal total = 0;
            double total2 = 0;
            decimal ticke_Ninos_Precio = 0;
            decimal ticke_Recular_Precio = 0;
            int total_Tickes = 0;


            if (compraCine != null)
            {
                var ticket = db.ticket.Find(compraCine.idTicket);
                /*Valor de los tickets*/
                ticke_Ninos_Precio = compraCine.cantidadNinos * ticket.precioNino;
                ticke_Recular_Precio = compraCine.cantidadNinos * ticket.precioRegular;

                /*Valor del Subtotal*/
                subtotal = Convert.ToInt32( ticke_Ninos_Precio + ticke_Recular_Precio);
                total = Convert.ToDecimal(subtotal);
                /*Cantidad total de tickes*/
                total_Tickes = compraCine.cantidadNinos + compraCine.cantidadRegular;

                /*Validar si hay descuento*/
                if (total_Tickes >= ticket.cantidaTicketsdDescuento)
                {
                    descuento =Convert.ToDecimal( subtotal * 0.2);
                }
                
                total = total - descuento ;

                total2 = Convert.ToDouble( total);
                cargoServicio = Convert.ToDecimal(total2 * 0.13);
                total = total + cargoServicio;

            }



            if (ModelState.IsValid)
            {
                db.compraCine.Add(compraCine);

                compraCine.descuento = descuento;
                compraCine.total = total;
                compraCine.cargoServicio = cargoServicio;
                db.SaveChanges();
                TempData["mensaje"] = "Guardado con Exito.";
                return RedirectToAction("Index");
            }
            else
            {

                TempData["mensaje"] = "No se guardo.";
            }

            ViewBag.idTicket = new SelectList(db.ticket, "idTicket", "nombrePelicula", compraCine.idTicket);
            return View(compraCine);
        }

        public ActionResult buscarticket(int? idTicket)
        {
            ViewBag.peliculas = new SelectList(db.ticket, "idTicket", "nombrePelicula");
            if (idTicket != null)
            {
                var lista = db.compraCine.Where(x => x.idTicket == idTicket).ToList();

                return PartialView("_Listatickets", lista);
            }
            return View();
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
