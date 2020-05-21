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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LevelsController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/Levels
        public IQueryable<Level> GetLevels()
        {
            return db.Levels;
        }

        // GET: api/Levels/5
        [ResponseType(typeof(Level))]
        public IHttpActionResult GetLevel(string id)
        {
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return NotFound();
            }

            return Ok(level);
        }

        // PUT: api/Levels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLevel(string id, Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != level.Id)
            {
                return BadRequest();
            }

            db.Entry(level).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        [ResponseType(typeof(Level))]
        public IHttpActionResult PostLevel(Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Levels.Add(level);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LevelExists(level.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = level.Id }, level);
        }

        // DELETE: api/Levels/5
        [ResponseType(typeof(Level))]
        public IHttpActionResult DeleteLevel(string id)
        {
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return NotFound();
            }

            db.Levels.Remove(level);
            db.SaveChanges();

            return Ok(level);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LevelExists(string id)
        {
            return db.Levels.Count(e => e.Id == id) > 0;
        }
    }
}