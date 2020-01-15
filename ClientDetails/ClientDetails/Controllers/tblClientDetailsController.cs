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
using ClientDetails.Models;

namespace ClientDetails.Controllers
{
    public class tblClientDetailsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/tblClientDetails
        public IQueryable<tblClientDetail> GettblClientDetails()
        {
            return db.tblClientDetails;
        }

        // GET: api/tblClientDetails/5
        [ResponseType(typeof(tblClientDetail))]
        public IHttpActionResult GettblClientDetail(long id)
        {
            tblClientDetail tblClientDetail = db.tblClientDetails.Find(id);
            if (tblClientDetail == null)
            {
                return NotFound();
            }

            return Ok(tblClientDetail);
        }

        // PUT: api/tblClientDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblClientDetail(long id, tblClientDetail tblClientDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != tblClientDetail.ClientDetailsID)
            {
                return BadRequest();
            }

            db.Entry(tblClientDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblClientDetailExists(id))
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

        // POST: api/tblClientDetails
        [ResponseType(typeof(tblClientDetail))]
        public IHttpActionResult PosttblClientDetail(tblClientDetail tblClientDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.tblClientDetails.Add(tblClientDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblClientDetail.ClientDetailsID }, tblClientDetail);
        }

        // DELETE: api/tblClientDetails/5
        [ResponseType(typeof(tblClientDetail))]
        public IHttpActionResult Delete(long id)
        {
            tblClientDetail tblClientDetail = db.tblClientDetails.Find(id);
            if (tblClientDetail == null)
            {
                return NotFound();
            }

            db.tblClientDetails.Remove(tblClientDetail);
            db.SaveChanges();

            return Ok(tblClientDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblClientDetailExists(long id)
        {
            return db.tblClientDetails.Count(e => e.ClientDetailsID == id) > 0;
        }
    }
}