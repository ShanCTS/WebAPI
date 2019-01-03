using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class POMASTERsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/POMASTERs
        public IQueryable<POMASTER> GetPOMASTERs()
        {
            return db.POMASTERs;
        }

        // GET: api/POMASTERs/5
        [ResponseType(typeof(POMASTER))]
        public async Task<IHttpActionResult> GetPOMASTER(string id)
        {
            POMASTER pOMASTER = await db.POMASTERs.FindAsync(id);
            if (pOMASTER == null)
            {
                return NotFound();
            }

            return Ok(pOMASTER);
        }

        // PUT: api/POMASTERs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPOMASTER(string id, POMASTER pOMASTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOMASTER.PONO)
            {
                return BadRequest();
            }

            db.Entry(pOMASTER).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POMASTERExists(id))
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

        // POST: api/POMASTERs
        [ResponseType(typeof(POMASTER))]
        public async Task<IHttpActionResult> PostPOMASTER(POMASTER pOMASTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POMASTERs.Add(pOMASTER);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (POMASTERExists(pOMASTER.PONO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pOMASTER.PONO }, pOMASTER);
        }

        // DELETE: api/POMASTERs/5
        [ResponseType(typeof(POMASTER))]
        public async Task<IHttpActionResult> DeletePOMASTER(string id)
        {
            POMASTER pOMASTER = await db.POMASTERs.FindAsync(id);
            if (pOMASTER == null)
            {
                return NotFound();
            }

            db.POMASTERs.Remove(pOMASTER);
            await db.SaveChangesAsync();

            return Ok(pOMASTER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POMASTERExists(string id)
        {
            return db.POMASTERs.Count(e => e.PONO == id) > 0;
        }
    }
}