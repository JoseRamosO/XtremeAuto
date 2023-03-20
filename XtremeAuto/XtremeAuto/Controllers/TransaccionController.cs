using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XtremeAuto.Models;

namespace XtremeAuto.App_Start
{
    public class TransaccionController : Controller
    {
        private ProyectoEntities3 db = new ProyectoEntities3();

        // GET: Transaccion
        public ActionResult Index()
        {
            var transaccion = db.Transaccion.Include(t => t.Tarjeta).Include(t => t.Venta);
            return View(transaccion.ToList());
        }

        // GET: Transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccion/Create
        public ActionResult Create()
        {
            ViewBag.IDTarjeta = new SelectList(db.Tarjeta, "IDTarjeta", "NumeroTarjeta");
            ViewBag.IDVenta = new SelectList(db.Venta, "IDVenta", "IDCliente");
            return View();
        }

        // POST: Transaccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTransaccion,Fecha,IDTarjeta,IDVenta")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTarjeta = new SelectList(db.Tarjeta, "IDTarjeta", "NumeroTarjeta", transaccion.IDTarjeta);
            ViewBag.IDVenta = new SelectList(db.Venta, "IDVenta", "IDCliente", transaccion.IDVenta);
            return View(transaccion);
        }

        // GET: Transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTarjeta = new SelectList(db.Tarjeta, "IDTarjeta", "NumeroTarjeta", transaccion.IDTarjeta);
            ViewBag.IDVenta = new SelectList(db.Venta, "IDVenta", "IDCliente", transaccion.IDVenta);
            return View(transaccion);
        }

        // POST: Transaccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTransaccion,Fecha,IDTarjeta,IDVenta")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTarjeta = new SelectList(db.Tarjeta, "IDTarjeta", "NumeroTarjeta", transaccion.IDTarjeta);
            ViewBag.IDVenta = new SelectList(db.Venta, "IDVenta", "IDCliente", transaccion.IDVenta);
            return View(transaccion);
        }

        // GET: Transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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
