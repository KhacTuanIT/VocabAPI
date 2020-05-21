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
    public class WordMemorizesController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/WordMemorizes
        public IQueryable<WordMemorize> GetWordMemorizes()
        {
            return db.WordMemorizes;
        }

        // GET: api/WordMemorizes/5
        [ResponseType(typeof(WordMemorize))]
        public IHttpActionResult GetWordMemorize(int id)
        {
            WordMemorize wordMemorize = db.WordMemorizes.Find(id);
            if (wordMemorize == null)
            {
                return NotFound();
            }

            return Ok(wordMemorize);
        }

        // PUT: api/WordMemorizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWordMemorize(int id, WordMemorize wordMemorize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordMemorize.Id)
            {
                return BadRequest();
            }

            db.Entry(wordMemorize).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordMemorizeExists(id))
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

        // POST: api/WordMemorizes
        [ResponseType(typeof(WordMemorize))]
        public IHttpActionResult PostWordMemorize(WordMemorize wordMemorize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WordMemorizes.Add(wordMemorize);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wordMemorize.Id }, wordMemorize);
        }

        // DELETE: api/WordMemorizes/5
        [ResponseType(typeof(WordMemorize))]
        public IHttpActionResult DeleteWordMemorize(int id)
        {
            WordMemorize wordMemorize = db.WordMemorizes.Find(id);
            if (wordMemorize == null)
            {
                return NotFound();
            }

            db.WordMemorizes.Remove(wordMemorize);
            db.SaveChanges();

            return Ok(wordMemorize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordMemorizeExists(int id)
        {
            return db.WordMemorizes.Count(e => e.Id == id) > 0;
        }
    }
}