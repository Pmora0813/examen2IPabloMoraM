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
    public class ticketsController : Controller
    {
        private CineContext db = new CineContext();

        // GET: tickets
        public ActionResult Index()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            //var ticket = db.ticket.Include(t => t.idTicket);
            return View(db.ticket.OrderBy(x => x.nombrePelicula).ToList());
            //return View(db.ticket.ToList());
        }

        

        // GET: tickets/Edit/5
        public ActionResult Editar(int? id)
        {


            if (id == null)
            {
                TempData["mensaje"] = "Especifique el ticket.";
                return RedirectToAction("Index");
            }
            ticket tickt = db.ticket.Find(id);
            if (tickt == null)
            {
                TempData["mensaje"] = "No éxiste el ticket.";
                return RedirectToAction("Index");
            }
            
            return View("Edit", tickt);


           
        }

        // POST: tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "Editado con éxito.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mensaje"] = "NO Editado.";
            }
            return View("Edit",ticket);
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
