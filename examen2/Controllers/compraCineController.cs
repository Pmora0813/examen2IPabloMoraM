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
            ViewBag.idTicket = new SelectList(db.ticket, "idTicket", "nombrePelicula");
            return View();
        }

        // POST: compraCine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompra,fecha,idTicket,cantidadNinos,cantidadRegular,descuento,cargoServicio,total")] compraCine compraCine)
        {
            if (ModelState.IsValid)
            {
                db.compraCine.Add(compraCine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTicket = new SelectList(db.ticket, "idTicket", "nombrePelicula", compraCine.idTicket);
            return View(compraCine);
        }

        // GET: compraCine/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.idTicket = new SelectList(db.ticket, "idTicket", "nombrePelicula", compraCine.idTicket);
            return View(compraCine);
        }

        // POST: compraCine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompra,fecha,idTicket,cantidadNinos,cantidadRegular,descuento,cargoServicio,total")] compraCine compraCine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraCine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTicket = new SelectList(db.ticket, "idTicket", "nombrePelicula", compraCine.idTicket);
            return View(compraCine);
        }

        // GET: compraCine/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: compraCine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compraCine compraCine = db.compraCine.Find(id);
            db.compraCine.Remove(compraCine);
            db.SaveChanges();
            return RedirectToAction("Index");
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
