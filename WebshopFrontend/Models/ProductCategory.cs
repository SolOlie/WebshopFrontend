using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopFrontend.Gateways.Gateways;

namespace WebshopFrontend.Models
{
    public class ProductCategory
    {
        public Product product { get; set; }
        public Category category { get; set; }


    }
}