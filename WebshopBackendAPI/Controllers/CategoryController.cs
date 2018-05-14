using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebshopBackendAPI.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryConnector cc = new CategoryConnector();
        // GET: api/Category
        public List<Category> GetCategories()
        {
            return cc.ReadAll();
        }

        // GET: api/Category/5
        public IHttpActionResult GetCategory(int id)
        {
            Category category = cc.Read(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cc.Create(category);
            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        public IHttpActionResult Put(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != category.Id)
            {
                return BadRequest();
            }
            cc.Update(category);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
            cc.Delete(id);
        }
    }
}
