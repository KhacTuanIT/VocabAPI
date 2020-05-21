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
    public class MyPackagesController : ApiController
    {
        private VocabDbContext db = new VocabDbContext();

        // GET: api/MyPackages
        public IQueryable<MyPackage> GetMyPackages()
        {
            return db.MyPackages;
        }

        // GET: api/MyPackages/5
        [ResponseType(typeof(MyPackage))]
        public IHttpActionResult GetMyPackage(int id)
        {
            MyPackage myPackage = db.MyPackages.Find(id);
            if (myPackage == null)
            {
                return NotFound();
            }

            return Ok(myPackage);
        }

        // PUT: api/MyPackages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyPackage(int id, MyPackage myPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myPackage.Id)
            {
                return BadRequest();
            }

            db.Entry(myPackage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyPackageExists(id))
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

        // POST: api/MyPackages
        [ResponseType(typeof(MyPackage))]
        public IHttpActionResult PostMyPackage(MyPackage myPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyPackages.Add(myPackage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myPackage.Id }, myPackage);
        }

        // DELETE: api/MyPackages/5
        [ResponseType(typeof(MyPackage))]
        public IHttpActionResult DeleteMyPackage(int id)
        {
            MyPackage myPackage = db.MyPackages.Find(id);
            if (myPackage == null)
            {
                return NotFound();
            }

            db.MyPackages.Remove(myPackage);
            db.SaveChanges();

            return Ok(myPackage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyPackageExists(int id)
        {
            return db.MyPackages.Count(e => e.Id == id) > 0;
        }
    }
}