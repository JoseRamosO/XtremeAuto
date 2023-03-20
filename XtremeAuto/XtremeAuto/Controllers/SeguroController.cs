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
    public class SeguroController : Controller
    {
        private ProyectoEntities3 db = new ProyectoEntities3();

        // GET: Seguro
        public ActionResult Index()
        {
            return View(db.Seguro.ToList());
        }

        // GET: Seguro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguro seguro = db.Seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // GET: Seguro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSeguro,TipoSeguro,Plazo,Precio")] Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.Seguro.Add(seguro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seguro);
        }

        // GET: Seguro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguro seguro = db.Seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // POST: Seguro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSeguro,TipoSeguro,Plazo,Precio")] Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seguro);
        }

        // GET: Seguro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguro seguro = db.Seguro.Find(id);
            if (seguro == null)
            {
                return HttpNotFound();
            }
            return View(seguro);
        }

        // POST: Seguro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seguro seguro = db.Seguro.Find(id);
            db.Seguro.Remove(seguro);
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
