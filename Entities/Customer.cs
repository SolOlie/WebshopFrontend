using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Phonenumber { get; set; }
        public String Streetname { get; set; }
        public String Streetnumber { get; set; }
        public String Zipcode { get; set; }
        public String City { get; set; }
        public List<Order> Orders { get; set; }
        public int OrderId { get; set; }
    }
}
