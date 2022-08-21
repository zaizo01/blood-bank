using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Entities
{
    public class Donor
    {
        public Guid Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BloodType { get; set; }
    }
}
