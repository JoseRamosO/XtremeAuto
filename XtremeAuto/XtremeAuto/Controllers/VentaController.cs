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
    public class VentaController : Controller
    {
        private ProyectoEntities3 db = new ProyectoEntities3();

        // GET: Venta
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.AspNetUsers).Include(v => v.AspNetUsers1).Include(v => v.Carro);
            return View(venta.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre");
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre");
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo");
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDVenta,Financiamiento,Intereses,Total,Meses,Fecha,Aprobacion,IDCliente,IDCarro,IDEmpleado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", venta.IDCarro);
            return View(venta);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", venta.IDCarro);
            return View(venta);
        }

        // POST: Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVenta,Financiamiento,Intereses,Total,Meses,Fecha,Aprobacion,IDCliente,IDCarro,IDEmpleado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", venta.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", venta.IDCarro);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
