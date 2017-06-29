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
    public class PlayerTeamsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/PlayerTeams
        public IQueryable<PlayerTeams> GetPlayerTeams()
        {
            return db.PlayerTeams;
        }

        // GET: api/PlayerTeams/5
        [ResponseType(typeof(PlayerTeams))]
        public IHttpActionResult GetPlayerTeams(int id)
        {
            PlayerTeams playerTeams = db.PlayerTeams.Find(id);
            if (playerTeams == null)
            {
                return NotFound();
            }

            return Ok(playerTeams);
        }

        // PUT: api/PlayerTeams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerTeams(int id, PlayerTeams playerTeams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerTeams.PlayerTeamsUser_ID)
            {
                return BadRequest();
            }

            db.Entry(playerTeams).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerTeamsExists(id))
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

        // POST: api/PlayerTeams
        [ResponseType(typeof(PlayerTeams))]
        public IHttpActionResult PostPlayerTeams(PlayerTeams playerTeams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlayerTeams.Add(playerTeams);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerTeamsExists(playerTeams.PlayerTeamsUser_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = playerTeams.PlayerTeamsUser_ID }, playerTeams);
        }

        // DELETE: api/PlayerTeams/5
        [ResponseType(typeof(PlayerTeams))]
        public IHttpActionResult DeletePlayerTeams(int id)
        {
            PlayerTeams playerTeams = db.PlayerTeams.Find(id);
            if (playerTeams == null)
            {
                return NotFound();
            }

            db.PlayerTeams.Remove(playerTeams);
            db.SaveChanges();

            return Ok(playerTeams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerTeamsExists(int id)
        {
            return db.PlayerTeams.Count(e => e.PlayerTeamsUser_ID == id) > 0;
        }
    }
}