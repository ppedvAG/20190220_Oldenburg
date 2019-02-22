using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class HundeApiController : ApiController
    {
        private HalloWebContext db = new HalloWebContext();

        // GET: api/HundeApi
        public IQueryable<Hund> GetHunds()
        {
            return db.Hunds;
        }

        // GET: api/HundeApi/5
        [ResponseType(typeof(Hund))]
        public IHttpActionResult GetHund(int id)
        {
            Hund hund = db.Hunds.Find(id);
            if (hund == null)
            {
                return NotFound();
            }

            return Ok(hund);
        }

        // PUT: api/HundeApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHund(int id, Hund hund)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hund.Id)
            {
                return BadRequest();
            }

            db.Entry(hund).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HundExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HundeApi
        [ResponseType(typeof(Hund))]
        public IHttpActionResult PostHund(Hund hund)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hunds.Add(hund);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hund.Id }, hund);
        }

        // DELETE: api/HundeApi/5
        [ResponseType(typeof(Hund))]
        public IHttpActionResult DeleteHund(int id)
        {
            Hund hund = db.Hunds.Find(id);
            if (hund == null)
            {
                return NotFound();
            }

            db.Hunds.Remove(hund);
            db.SaveChanges();

            return Ok(hund);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HundExists(int id)
        {
            return db.Hunds.Count(e => e.Id == id) > 0;
        }
    }
}