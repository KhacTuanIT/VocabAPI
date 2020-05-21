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
    public class PackagesController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/Packages
        public IQueryable<Package> GetPackages()
        {
            return db.Packages;
        }

        // GET: api/Packages/5
        [ResponseType(typeof(Package))]
        public IHttpActionResult GetPackage(string id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // PUT: api/Packages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPackage(string id, Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }

            db.Entry(package).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        [ResponseType(typeof(Package))]
        public IHttpActionResult PostPackage(Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Packages.Add(package);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PackageExists(package.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [ResponseType(typeof(Package))]
        public IHttpActionResult DeletePackage(string id)
        {
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            db.Packages.Remove(package);
            db.SaveChanges();

            return Ok(package);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PackageExists(string id)
        {
            return db.Packages.Count(e => e.Id == id) > 0;
        }
    }
}