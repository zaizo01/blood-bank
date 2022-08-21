using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Entities
{
    public class BloodDonations
    {
        public Guid Id { get; set; }
        public string PatientFullName { get; set; }
        public int QuantityOfBlood { get; set; }
        public string BloodType { get; set; }
        public string Description { get; set; }
    }
}
