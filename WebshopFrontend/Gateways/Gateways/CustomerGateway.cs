using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using WebshopFrontend.Gateways.Interface;
using WebshopFrontend.Gateways.Other;

namespace WebshopFrontend.Gateways
{
    public class CustomerGateway : ICustomerGateway
    {
        public Customer Create(Customer t)
        {
            var Customer = WebApiService.instance.PostAsync<Customer>("/api/Customer/PostCustomer", t, HttpContext.Current.User.Identity.Name).Result;
            return Customer;
        }

        public bool Delete(Customer t)
        {
            var Customer = WebApiService.instance.DeleteAsync<Customer>("/api/Customer/DeleteCustomer/" + t.Id, HttpContext.Current.User.Identity.Name).Result;
            return Customer;
        }

        public Customer GetDefaultCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer Read(int id)
        {
            var Customer = WebApiService.instance.GetAsync<Customer>("/api/Customer/GetCustomer/" + id, HttpContext.Current.User.Identity.Name).Result;
            return Customer;
        }

        public List<Customer> ReadAll()
        {
            var Customers = WebApiService.instance.GetAsync<List<Customer>>("/api/Customer/GetCustomers", HttpContext.Current.User.Identity.Name).Result?? new List<Customer>();
            return Customers;
        }

        public bool Update(Customer t)
        {
            var Customer = WebApiService.instance.PutAsync<Customer>("/api/Customer/PutCustomer/" + t.Id, t, HttpContext.Current.User.Identity.Name).Result;
            return Customer;
        }
    }
}