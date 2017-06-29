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
    public class GamesController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/Games
        public IQueryable<Games> GetGames()
        {
            return db.Games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Games))]
        public IHttpActionResult GetGames(int id)
        {
            Games games = db.Games.Find(id);
            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGames(int id, Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games.Game_ID)
            {
                return BadRequest();
            }

            db.Entry(games).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Games))]
        public IHttpActionResult PostGames(Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(games);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GamesExists(games.Game_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = games.Game_ID }, games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Games))]
        public IHttpActionResult DeleteGames(int id)
        {
            Games games = db.Games.Find(id);
            if (games == null)
            {
                return NotFound();
            }

            db.Games.Remove(games);
            db.SaveChanges();

            return Ok(games);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GamesExists(int id)
        {
            return db.Games.Count(e => e.Game_ID == id) > 0;
        }
    }
}