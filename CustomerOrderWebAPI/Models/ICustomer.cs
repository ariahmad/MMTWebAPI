using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderWebAPI.Models
{
    public interface ICustomer
    {
         string houseNumber { get; set; }
         string street { get; set; }
         string town { get; set; }
         string postcode { get; set; }

        // Customers GetCustomers();
    }
}
