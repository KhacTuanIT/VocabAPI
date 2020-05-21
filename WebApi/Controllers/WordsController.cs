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
    public class WordsController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/Words
        public IQueryable<Word> GetWords()
        {
            return db.Words;
        }

        // GET: api/Words/5
        [ResponseType(typeof(Word))]
        public IHttpActionResult GetWord(string id)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return NotFound();
            }

            return Ok(word);
        }

        // PUT: api/Words/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWord(string id, Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != word.Id)
            {
                return BadRequest();
            }

            db.Entry(word).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        [ResponseType(typeof(Word))]
        public IHttpActionResult PostWord(Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Words.Add(word);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WordExists(word.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [ResponseType(typeof(Word))]
        public IHttpActionResult DeleteWord(string id)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return NotFound();
            }

            db.Words.Remove(word);
            db.SaveChanges();

            return Ok(word);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordExists(string id)
        {
            return db.Words.Count(e => e.Id == id) > 0;
        }
    }
}