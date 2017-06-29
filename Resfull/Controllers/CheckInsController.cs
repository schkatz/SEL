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
using Resfull.Models;

namespace Resfull.Controllers
{
    public class CheckInsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/CheckIns
        public IQueryable<CheckIn> GetCheckIn()
        {
            return db.CheckIn;
        }

        // GET: api/CheckIns/5
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult GetCheckIn(int id)
        {
            CheckIn checkIn = db.CheckIn.Find(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return Ok(checkIn);
        }

        // PUT: api/CheckIns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheckIn(int id, CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkIn.CheckIn_ID)
            {
                return BadRequest();
            }

            db.Entry(checkIn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
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

        // POST: api/CheckIns
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult PostCheckIn(CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CheckIn.Add(checkIn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = checkIn.CheckIn_ID }, checkIn);
        }

        // DELETE: api/CheckIns/5
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult DeleteCheckIn(int id)
        {
            CheckIn checkIn = db.CheckIn.Find(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            db.CheckIn.Remove(checkIn);
            db.SaveChanges();

            return Ok(checkIn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckInExists(int id)
        {
            return db.CheckIn.Count(e => e.CheckIn_ID == id) > 0;
        }
    }
}