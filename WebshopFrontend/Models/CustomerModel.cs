using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopFrontend.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Streetname { get; set; }
        public string Streetnumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public List<Order> Orders { get; set; }
        public List<Customer> customers { get; set; }
    }
}