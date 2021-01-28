using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fertilizer.Models
{
    public class MinFertilizer
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public string NameFertilizer { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
