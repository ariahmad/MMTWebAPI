using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{

    // this class is used for the web api request from clients
    public class CustomerIdEmail
    {
        public string CustomerId { get; set; }
        public string Email { get; set; }
    }
}