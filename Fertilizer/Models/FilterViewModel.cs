using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fertilizer.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Customer> customers, int? customer, string name)
        {
            customers.Insert(0, new Customer { NameCustomer = "Все", Id = 0 });
            Customers = new SelectList(customers, "Id", "NameCustomer", customer);
            SelectedCustomer = customer;
            SelectedName = name;
        }
        public SelectList Customers { get; private set; }
        public int? SelectedCustomer { get; private set; }
        public string SelectedName { get; private set; }
    }
}
