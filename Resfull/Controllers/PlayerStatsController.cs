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
    public class PlayerStatsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/PlayerStats
        public IQueryable<PlayerStats> GetPlayerStats()
        {
            return db.PlayerStats;
        }

        // GET: api/PlayerStats/5
        [ResponseType(typeof(PlayerStats))]
        public IHttpActionResult GetPlayerStats(int id)
        {
            PlayerStats playerStats = db.PlayerStats.Find(id);
            if (playerStats == null)
            {
                return NotFound();
            }

            return Ok(playerStats);
        }

        // PUT: api/PlayerStats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerStats(int id, PlayerStats playerStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerStats.PlayerStat_ID)
            {
                return BadRequest();
            }

            db.Entry(playerStats).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStatsExists(id))
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

        // POST: api/PlayerStats
        [ResponseType(typeof(PlayerStats))]
        public IHttpActionResult PostPlayerStats(PlayerStats playerStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlayerStats.Add(playerStats);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerStatsExists(playerStats.PlayerStat_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = playerStats.PlayerStat_ID }, playerStats);
        }

        // DELETE: api/PlayerStats/5
        [ResponseType(typeof(PlayerStats))]
        public IHttpActionResult DeletePlayerStats(int id)
        {
            PlayerStats playerStats = db.PlayerStats.Find(id);
            if (playerStats == null)
            {
                return NotFound();
            }

            db.PlayerStats.Remove(playerStats);
            db.SaveChanges();

            return Ok(playerStats);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerStatsExists(int id)
        {
            return db.PlayerStats.Count(e => e.PlayerStat_ID == id) > 0;
        }
    }
}