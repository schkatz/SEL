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
    public class TeamsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/Teams
        public IQueryable<Teams> GetTeams()
        {
            return db.Teams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Teams))]
        public IHttpActionResult GetTeams(int id)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeams(int id, Teams teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teams.Team_ID)
            {
                return BadRequest();
            }

            db.Entry(teams).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamsExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Teams))]
        public IHttpActionResult PostTeams(Teams teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(teams);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeamsExists(teams.Team_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teams.Team_ID }, teams);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Teams))]
        public IHttpActionResult DeleteTeams(int id)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }

            db.Teams.Remove(teams);
            db.SaveChanges();

            return Ok(teams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamsExists(int id)
        {
            return db.Teams.Count(e => e.Team_ID == id) > 0;
        }
    }
}