using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fertilizer.Models
{
    public class SortViewModel
    {
        public SortState NameFertilizerSort { get; private set; }
        public SortState FactorySort { get; private set; }
        public SortState PriceSort { get; private set; }
        public SortState CustomerSort { get; private set; }
        public SortState AddressSort { get; private set; }
        public SortState DirectorSort { get; private set; }
        public SortState TelephoneSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            NameFertilizerSort = sortOrder == SortState.NameFertilizerAsc ? SortState.NameFertilizerDesc : SortState.NameFertilizerAsc;
            FactorySort = sortOrder == SortState.FactoryAsc ? SortState.FactoryDesc : SortState.FactoryAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            CustomerSort = sortOrder == SortState.NameCustomerAsc ? SortState.NameCustomerDesc : SortState.NameCustomerAsc;
            AddressSort = sortOrder == SortState.AddressAsc ? SortState.AddressDesc : SortState.AddressAsc;
            DirectorSort = sortOrder == SortState.DirectorAsc ? SortState.DirectorDesc : SortState.DirectorAsc;
            TelephoneSort = sortOrder == SortState.TelephoneAsc ? SortState.TelephoneDesc : SortState.TelephoneAsc;
            Current = sortOrder;
        }
    }
}
