using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Produkt navn")]
        public string ProductName { get; set; }

        [DisplayName("Pris")]
        public string Price { get; set; }
        public string Information { get; set; }

        [DisplayName("Fabrikant")]
        public string Manufacture { get; set; }

        public int CategoryId { get; set; }
        
        public string Category { get; set; }

    }
}
