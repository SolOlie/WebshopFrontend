using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebshopBackendAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerConnector cc = new CustomerConnector();
        // GET: api/Customer
        public List<Customer>  GetCustomers()
        {
            var model = cc.GetCustomers();
            return model;
        }

        // GET: api/Customer/5'
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = cc.GetOneCustomer(id);
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cc.CreateOneCustomer(customer);
            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);

        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != customer.Id)
            {
                return BadRequest();
            }
            cc.UpdateOneCustomer(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Customer/5
        public void DeleteCustomer(int id)
        {
            cc.DeleteOneCustomer(id);
        }
    }
}
