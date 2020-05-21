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
    public class WordGroupsController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/WordGroups
        public IQueryable<WordGroup> GetWordGroups()
        {
            return db.WordGroups;
        }

        // GET: api/WordGroups/5
        [ResponseType(typeof(WordGroup))]
        public IHttpActionResult GetWordGroup(string id)
        {
            WordGroup wordGroup = db.WordGroups.Find(id);
            if (wordGroup == null)
            {
                return NotFound();
            }

            return Ok(wordGroup);
        }

        // PUT: api/WordGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWordGroup(string id, WordGroup wordGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordGroup.Id)
            {
                return BadRequest();
            }

            db.Entry(wordGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordGroupExists(id))
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

        // POST: api/WordGroups
        [ResponseType(typeof(WordGroup))]
        public IHttpActionResult PostWordGroup(WordGroup wordGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WordGroups.Add(wordGroup);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WordGroupExists(wordGroup.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wordGroup.Id }, wordGroup);
        }

        // DELETE: api/WordGroups/5
        [ResponseType(typeof(WordGroup))]
        public IHttpActionResult DeleteWordGroup(string id)
        {
            WordGroup wordGroup = db.WordGroups.Find(id);
            if (wordGroup == null)
            {
                return NotFound();
            }

            db.WordGroups.Remove(wordGroup);
            db.SaveChanges();

            return Ok(wordGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordGroupExists(string id)
        {
            return db.WordGroups.Count(e => e.Id == id) > 0;
        }
    }
}