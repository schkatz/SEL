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
    public class TeamStatsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/TeamStats
        public IQueryable<TeamStats> GetTeamStats()
        {
            return db.TeamStats;
        }

        // GET: api/TeamStats/5
        [ResponseType(typeof(TeamStats))]
        public IHttpActionResult GetTeamStats(int id)
        {
            TeamStats teamStats = db.TeamStats.Find(id);
            if (teamStats == null)
            {
                return NotFound();
            }

            return Ok(teamStats);
        }

        // PUT: api/TeamStats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeamStats(int id, TeamStats teamStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamStats.TeamStats_ID)
            {
                return BadRequest();
            }

            db.Entry(teamStats).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamStatsExists(id))
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

        // POST: api/TeamStats
        [ResponseType(typeof(TeamStats))]
        public IHttpActionResult PostTeamStats(TeamStats teamStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamStats.Add(teamStats);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeamStatsExists(teamStats.TeamStats_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teamStats.TeamStats_ID }, teamStats);
        }

        // DELETE: api/TeamStats/5
        [ResponseType(typeof(TeamStats))]
        public IHttpActionResult DeleteTeamStats(int id)
        {
            TeamStats teamStats = db.TeamStats.Find(id);
            if (teamStats == null)
            {
                return NotFound();
            }

            db.TeamStats.Remove(teamStats);
            db.SaveChanges();

            return Ok(teamStats);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamStatsExists(int id)
        {
            return db.TeamStats.Count(e => e.TeamStats_ID == id) > 0;
        }
    }
}