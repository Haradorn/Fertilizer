using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fertilizer.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fertilizer.Controllers
{
    public class HomeController : Controller
    {
        MinFertilizerContext db;
        public HomeController(MinFertilizerContext context)
        {
            this.db = context;
            if (db.Customers.Count() == 0)
            {
                Customer customer1 = new Customer
                {
                    NameCustomer = "РосАгроТрейд",
                    Address = "г. Лиски, ул. Фурманова, д. 54А",
                    Director = "Мамонов В.И.",
                    Telephone = "+74739591845"
                };
                Customer customer2 = new Customer
                {
                    NameCustomer = "ООО РосХолдинг",
                    Address = "г. Павловск, пер. Грозного, д. 134",
                    Director = "Андреев К.А.",
                    Telephone = "+74739845698"
                };
                Customer customer3 = new Customer
                {
                    NameCustomer = "АО СеверДомТорг",
                    Address = "г. Бобров, ул. Лизюкова, д. 3",
                    Director = "Миколаенко Н.В.",
                    Telephone = "+74739695845"
                };
                Customer customer4 = new Customer
                {
                    NameCustomer = "ВнешПромИнвест",
                    Address = "г. Россошь, ул. Никитина, д. 14",
                    Director = "Циневич О.Ф.",
                    Telephone = "+74739685945"
                };

                MinFertilizer minFertilizer1 = new MinFertilizer 
                { 
                    NameFertilizer = "HYO3-4",
                    Factory = "АК",
                    Price = 54900,
                    Customer = customer1
                };
                MinFertilizer minFertilizer2 = new MinFertilizer
                {
                    NameFertilizer = "GtFg-43",
                    Factory = "ФК",
                    Price = 132456,
                    Customer = customer2
                };
                MinFertilizer minFertilizer3 = new MinFertilizer
                {
                    NameFertilizer = "РЕХ-23",
                    Factory = "АК",
                    Price = 66986,
                    Customer = customer3
                };
                MinFertilizer minFertilizer4 = new MinFertilizer
                {
                    NameFertilizer = "WDGT43",
                    Factory = "ВК",
                    Price = 1239867,
                    Customer = customer4
                };
                MinFertilizer minFertilizer5 = new MinFertilizer
                {
                    NameFertilizer = "А4ЕР",
                    Factory = "ВК",
                    Price = 98065,
                    Customer = customer1
                };
                MinFertilizer minFertilizer6 = new MinFertilizer
                {
                    NameFertilizer = "IFG-3",
                    Factory = "АС",
                    Price = 45980,
                    Customer = customer2
                };
                MinFertilizer minFertilizer7 = new MinFertilizer
                {
                    NameFertilizer = "UIG034",
                    Factory = "АС",
                    Price = 127543,
                    Customer = customer3
                };
                MinFertilizer minFertilizer8 = new MinFertilizer
                {
                    NameFertilizer = "ETD-34",
                    Factory = "ВК",
                    Price = 56003,
                    Customer = customer4
                };

                db.Customers.AddRange(customer1, customer2, customer3, customer4);
                db.MinFertilizers.AddRange(minFertilizer1, minFertilizer2, minFertilizer3,
                                           minFertilizer4, minFertilizer5, minFertilizer6, minFertilizer7, minFertilizer8);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(int? customers, string name, int page = 1,
            SortState sortOrder = SortState.NameFertilizerAsc)
        {
            int pagesize = 3;
            IQueryable<MinFertilizer> minFertilizers = db.MinFertilizers.Include(x => x.Customer);
            if (customers != null && customers != 0)
            {
                minFertilizers = minFertilizers.Where(p => p.CustomerId == customers);
            }
            if (!String.IsNullOrEmpty(name))
            {
                minFertilizers = minFertilizers.Where(p => p.NameFertilizer.Contains(name));
            }
            switch (sortOrder)
            {
                case SortState.NameFertilizerDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.NameFertilizer);
                    break;
                case SortState.FactoryAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Factory);
                    break;
                case SortState.FactoryDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Factory);
                    break;
                case SortState.PriceAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Price);
                    break;
                case SortState.NameCustomerAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Customer.NameCustomer);
                    break;
                case SortState.NameCustomerDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Customer.NameCustomer);
                    break;
                case SortState.AddressAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Customer.Address);
                    break;
                case SortState.AddressDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Customer.Address);
                    break;
                case SortState.DirectorAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Customer.Director);
                    break;
                case SortState.DirectorDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Customer.Director);
                    break;
                case SortState.TelephoneAsc:
                    minFertilizers = minFertilizers.OrderBy(s => s.Customer.Telephone);
                    break;
                case SortState.TelephoneDesc:
                    minFertilizers = minFertilizers.OrderByDescending(s => s.Customer.Director);
                    break;
                default:
                    minFertilizers = minFertilizers.OrderBy(s => s.NameFertilizer);
                    break;
            }
            var count = await minFertilizers.CountAsync();
            var items = await minFertilizers.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pagesize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Customers.ToList(), customers, name),
                Fertilizers = items
            };
            return View(viewModel);
        }
    }
}
