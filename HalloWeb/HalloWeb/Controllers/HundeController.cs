using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class HundeController : Controller
    {
        private HalloWebContext db = new HalloWebContext();

        // GET: Hunde
        public ActionResult Index()
        {
            return View(db.Hunds.ToList());
        }

        // GET: Hunde/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hund hund = db.Hunds.Find(id);
            if (hund == null)
            {
                return HttpNotFound();
            }
            return View(hund);
        }

        // GET: Hunde/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hunde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AnzahlFlöhe,Rasse,Nasenlänge")] Hund hund)
        {
            if (ModelState.IsValid)
            {
                db.Hunds.Add(hund);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hund);
        }

        // GET: Hunde/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hund hund = db.Hunds.Find(id);
            if (hund == null)
            {
                return HttpNotFound();
            }
            return View(hund);
        }

        // POST: Hunde/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AnzahlFlöhe,Rasse,Nasenlänge")] Hund hund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hund);
        }

        // GET: Hunde/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hund hund = db.Hunds.Find(id);
            if (hund == null)
            {
                return HttpNotFound();
            }
            return View(hund);
        }

        // POST: Hunde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hund hund = db.Hunds.Find(id);
            db.Hunds.Remove(hund);
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
