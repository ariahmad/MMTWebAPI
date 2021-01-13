using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class Customers : ICustomer, IFullName
    {

        public static Customers GetCustomers { get; set; }

        public string customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime lastLoggedIn { get; set; }
        public bool website { get; set; }
        public string houseNumber { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
        public string preferredLanguage { get; set; }
        public string email { get; set; }
    }
}