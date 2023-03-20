using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XtremeAuto.Models;

namespace XtremeAuto.Controllers
{
    public class TarjetaController : Controller
    {
        private ProyectoEntities3 db = new ProyectoEntities3();

        // GET: Tarjeta
        public ActionResult Index()
        {
            var tarjeta = db.Tarjeta.Include(t => t.AspNetUsers);
            return View(tarjeta.ToList());
        }

        // GET: Tarjeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: Tarjeta/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre");
            return View();
        }

        // POST: Tarjeta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTarjeta,CVV,NumeroTarjeta,Nombre,FechaVencimiento,IDCliente")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Tarjeta.Add(tarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", tarjeta.IDCliente);
            return View(tarjeta);
        }

        // GET: Tarjeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", tarjeta.IDCliente);
            return View(tarjeta);
        }

        // POST: Tarjeta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTarjeta,CVV,NumeroTarjeta,Nombre,FechaVencimiento,IDCliente")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", tarjeta.IDCliente);
            return View(tarjeta);
        }

        // GET: Tarjeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: Tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            db.Tarjeta.Remove(tarjeta);
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
