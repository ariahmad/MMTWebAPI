using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class Address:ICustomer
    {
        private ICustomer _customer;

        public Address()
        {
            _customer = Customers.GetCustomers;
            this.town = _customer.town;
            this.street = _customer.street;
            this.houseNumber = _customer.houseNumber;
            this.postcode = _customer.postcode;

        }
        public string houseNumber { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }



    }
}