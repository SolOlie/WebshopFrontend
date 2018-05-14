using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebshopFrontend.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [DisplayName("Produkt navn")]
        public string ProductName { get; set; }

        [DisplayName("Pris")]
        public string Price { get; set; }
        public string Information { get; set; }

        [DisplayName("Fabrikant")]
        public string Manufacture { get; set; }

        public string CategoryId { get; set; }

        [DisplayName("Kategorier")]
        public List<Category> ProductCategories { get; set; }
    }
}