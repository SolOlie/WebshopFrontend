using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebshopBackendAPI.Controllers
{
    public class ProductController : ApiController
    {
        private ProductConnector pc = new ProductConnector();
        // GET: api/Product
        public List<Product> GetProducts()
        {
            var model = pc.ReadAll();
            return model;
        }

        // GET: api/Product/5
        public IHttpActionResult GetProduct(int id)
        {
            Product product = pc.Read(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pc.Create(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pc.Update(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        public HttpStatusCode DeleteProduct(int id)
        {
            pc.Delete(id);
            return HttpStatusCode.OK;
        }
    }
}
