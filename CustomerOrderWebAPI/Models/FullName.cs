using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class FullName : IFullName
    {
        private IFullName _fullName;

        public FullName()
        {
            _fullName = Customers.GetCustomers;
            this.firstName = _fullName.firstName;
            this.lastName = _fullName.lastName;
           

        }
        public string firstName { get ; set ; }
        public string lastName { get; set ; }
    }
}