using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fertilizer.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }
        public string Telephone { get; set; }
        public List<MinFertilizer> MinFertilizers { get; set; }
        public Customer()
        {
            MinFertilizers = new List<MinFertilizer>();
        }
    }
}
