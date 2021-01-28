using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fertilizer.Models
{
    public enum SortState
    {
        NameFertilizerAsc,    // по имени по возрастанию
        NameFertilizerDesc,   // по имени по убыванию
        FactoryAsc, 
        FactoryDesc,    
        PriceAsc, 
        PriceDesc, 
        NameCustomerAsc,
        NameCustomerDesc,
        AddressAsc,
        AddressDesc,
        DirectorAsc,
        DirectorDesc,
        TelephoneAsc,
        TelephoneDesc
    }
}
