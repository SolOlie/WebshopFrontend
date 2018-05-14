using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Kategorier")]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
