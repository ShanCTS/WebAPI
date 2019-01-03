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
    public class SUPPLIERsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/SUPPLIERs
        public IQueryable<SUPPLIER> GetSUPPLIERs()
        {
            return db.SUPPLIERs;
        }

        // GET: api/SUPPLIERs/5
        [ResponseType(typeof(SUPPLIER))]
        public async Task<IHttpActionResult> GetSUPPLIER(string id)
        {
            SUPPLIER sUPPLIER = await db.SUPPLIERs.FindAsync(id);
            if (sUPPLIER == null)
            {
                return NotFound();
            }

            return Ok(sUPPLIER);
        }

        // PUT: api/SUPPLIERs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSUPPLIER(string id, SUPPLIER sUPPLIER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sUPPLIER.SUPLNO)
            {
                return BadRequest();
            }

            db.Entry(sUPPLIER).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SUPPLIERExists(id))
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

        // POST: api/SUPPLIERs
        [ResponseType(typeof(SUPPLIER))]
        public async Task<IHttpActionResult> PostSUPPLIER(SUPPLIER sUPPLIER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SUPPLIERs.Add(sUPPLIER);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SUPPLIERExists(sUPPLIER.SUPLNO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sUPPLIER.SUPLNO }, sUPPLIER);
        }

        // DELETE: api/SUPPLIERs/5
        [ResponseType(typeof(SUPPLIER))]
        public async Task<IHttpActionResult> DeleteSUPPLIER(string id)
        {
            SUPPLIER sUPPLIER = await db.SUPPLIERs.FindAsync(id);
            if (sUPPLIER == null)
            {
                return NotFound();
            }

            db.SUPPLIERs.Remove(sUPPLIER);
            await db.SaveChangesAsync();

            return Ok(sUPPLIER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SUPPLIERExists(string id)
        {
            return db.SUPPLIERs.Count(e => e.SUPLNO == id) > 0;
        }
    }
}