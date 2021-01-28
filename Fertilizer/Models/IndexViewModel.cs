using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fertilizer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<MinFertilizer> Fertilizers { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
