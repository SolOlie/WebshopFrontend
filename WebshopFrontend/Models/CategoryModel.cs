using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebshopFrontend.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [DisplayName("Kategorier")]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}