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
using WebAppLargeData.Data;
using WebAppLargeData.POCO;

namespace WebAppLargeData.Controllers
{
    public class CustomLargeDataEntitiesController : ApiController
    {
        private LargeDataContext db = new LargeDataContext();

        // GET: api/CustomLargeDataEntities
        public IQueryable<CustomLargeDataEntity> GetCustomLargeDataEntities()
        {
            return db.CustomLargeDataEntities;
        }

        // GET: api/CustomLargeDataEntities/5
        [ResponseType(typeof(CustomLargeDataEntity))]
        public async Task<IHttpActionResult> GetCustomLargeDataEntity(int id)
        {
            CustomLargeDataEntity customLargeDataEntity = await db.CustomLargeDataEntities.FindAsync(id);
            if (customLargeDataEntity == null)
            {
                return NotFound();
            }

            return Ok(customLargeDataEntity);
        }

        // PUT: api/CustomLargeDataEntities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomLargeDataEntity(int id, CustomLargeDataEntity customLargeDataEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customLargeDataEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(customLargeDataEntity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomLargeDataEntityExists(id))
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

        // POST: api/CustomLargeDataEntities
        [ResponseType(typeof(CustomLargeDataEntity))]
        public async Task<IHttpActionResult> PostCustomLargeDataEntity(CustomLargeDataEntity customLargeDataEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomLargeDataEntities.Add(customLargeDataEntity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customLargeDataEntity.Id }, customLargeDataEntity);
        }

        // DELETE: api/CustomLargeDataEntities/5
        [ResponseType(typeof(CustomLargeDataEntity))]
        public async Task<IHttpActionResult> DeleteCustomLargeDataEntity(int id)
        {
            CustomLargeDataEntity customLargeDataEntity = await db.CustomLargeDataEntities.FindAsync(id);
            if (customLargeDataEntity == null)
            {
                return NotFound();
            }

            db.CustomLargeDataEntities.Remove(customLargeDataEntity);
            await db.SaveChangesAsync();

            return Ok(customLargeDataEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomLargeDataEntityExists(int id)
        {
            return db.CustomLargeDataEntities.Count(e => e.Id == id) > 0;
        }
    }
}