using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Entities
{
    public class Request
    {
        public Guid Id { get; set; }
        public string BloodType { get; set; }
        public int Quantity { get; set; }
        public string Hospital { get; set; }
    }
}
