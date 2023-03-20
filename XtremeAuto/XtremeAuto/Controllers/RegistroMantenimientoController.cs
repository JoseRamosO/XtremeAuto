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
    public class RegistroMantenimientoController : Controller
    {
        private ProyectoEntities3 db = new ProyectoEntities3();

        // GET: RegistroMantenimiento
        public ActionResult Index()
        {
            var registroMantenimiento = db.RegistroMantenimiento.Include(r => r.AspNetUsers).Include(r => r.AspNetUsers1).Include(r => r.Carro);
            return View(registroMantenimiento.ToList());
        }

        // GET: RegistroMantenimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroMantenimiento registroMantenimiento = db.RegistroMantenimiento.Find(id);
            if (registroMantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(registroMantenimiento);
        }

        // GET: RegistroMantenimiento/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre");
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre");
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo");
            return View();
        }

        // POST: RegistroMantenimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRegistroMantenimiento,Descripcion,Costo,Fecha,IDCliente,IDCarro,IDEmpleado")] RegistroMantenimiento registroMantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.RegistroMantenimiento.Add(registroMantenimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", registroMantenimiento.IDCarro);
            return View(registroMantenimiento);
        }

        // GET: RegistroMantenimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroMantenimiento registroMantenimiento = db.RegistroMantenimiento.Find(id);
            if (registroMantenimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", registroMantenimiento.IDCarro);
            return View(registroMantenimiento);
        }

        // POST: RegistroMantenimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRegistroMantenimiento,Descripcion,Costo,Fecha,IDCliente,IDCarro,IDEmpleado")] RegistroMantenimiento registroMantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroMantenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDCliente);
            ViewBag.IDEmpleado = new SelectList(db.AspNetUsers, "Id", "Nombre", registroMantenimiento.IDEmpleado);
            ViewBag.IDCarro = new SelectList(db.Carro, "IDCarro", "Modelo", registroMantenimiento.IDCarro);
            return View(registroMantenimiento);
        }

        // GET: RegistroMantenimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroMantenimiento registroMantenimiento = db.RegistroMantenimiento.Find(id);
            if (registroMantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(registroMantenimiento);
        }

        // POST: RegistroMantenimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroMantenimiento registroMantenimiento = db.RegistroMantenimiento.Find(id);
            db.RegistroMantenimiento.Remove(registroMantenimiento);
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
