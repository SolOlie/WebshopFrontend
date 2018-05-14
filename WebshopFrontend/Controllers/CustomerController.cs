using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopFrontend.Gateways;
using WebshopFrontend.Gateways.Interface;
using WebshopFrontend.Models;

namespace WebshopFrontend.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerGateway customerGateway = new CustomerGateway();
        // GET: Customer
        public ActionResult Index()
        {
            var model = customerGateway.ReadAll();
            if (model == null)
            {
                return null;
            }
            return View(model);
        }
        public ActionResult CustomerListPartial()
        {
            var model = customerGateway.ReadAll();
            if (model == null)
            {
                return null;
            }
            return PartialView("CustomerListPartial", model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(string username, string password, string email, string phonenumber, string streetname, string streetnumber, string city, string zipcode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(username))
                    {

                        customerGateway.Create(new Entities.Customer
                        {
                            Username = username,
                            Password = password,
                            Email = email,
                            Phonenumber = phonenumber,
                            Streetname = streetname,
                            Streetnumber = streetnumber,
                            Zipcode = zipcode,
                            City = city
                        });
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerGateway.Read(id);
            if (customer == null)
            {
                return HttpNotFound();
            }      
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string username, string password, string email, string phonenumber, string streetname, string streetnumber, string zipcode, string city)
        {

            try
            {
                var customer = new Customer
                {
                    Id = id,
                    Username = username,
                    Password = password,
                    Email = email,
                    Phonenumber = phonenumber,
                    Streetname = streetname,
                    Streetnumber = streetnumber,
                    Zipcode = zipcode,
                    City = city
                };

                customerGateway.Update(customer);

            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerGateway.Read(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customerDelete)
        {
            try
            {
                if(customerDelete == null)
                {
                    return null;
                }
                var customer = customerGateway.Read(id);
                if(customer != null)
                {
                    customerGateway.Delete(customer);
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
