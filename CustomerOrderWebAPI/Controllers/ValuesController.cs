using CustomerOrderWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerOrderWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
       

        // GET api/values
        public IEnumerable<Products> Get()
        {
            List<Products> products = Products.GetAll();

            return products;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            return "value";
        }

        //  api/values/C34454/bob  
        //ToDO: use [FromBody] CustomerIdEmail value as parameter
        [NotImplExceptionFilter]
        public List<CustomerOrders> Get(string customerId, string email)
        {
            //string email = value.Email ;
            //string id = value.CustomerId= "C34454";

            email = "cat.owner@mmtdigital.co.uk";


            GetCustomer(email);

            Customers customers = Customers.GetCustomers;
            if(customers is null)
            {
                //TODO: handling invalid request
            }

            List<CustomerOrders> customerOrders = CustomerOrders.GetByID(customerId);

            foreach (var item in customerOrders)
            {
                FullName fullName = new FullName();
                item.FullName = fullName;

                Address address = new Address();
                item.Address = address;
            }


            return customerOrders;
        } 


        public async void GetCustomer(string email)
        {
            //https://customer-details.azurewebsites.net/api/GetUserDetails?code=uu2ToG/dcsg3DI8CGlpLro1PyLhZNUWHpdPv8VmWFLBaxM0fvUZvkA==&email=cat.owner@mmtdigital.co.uk   
            string code = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
           
            string apiString = "api/GetUserDetails?code=" + code + "&email=" + email;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://customer-details.azurewebsites.net/");
            HttpResponseMessage response = client.GetAsync(apiString).Result;  
            if (response.IsSuccessStatusCode)
            {
                string responseMessage = response.RequestMessage.ToString();
                string contentHeaders = response.Content.Headers.ToString();
                var customerJsonString =await response.Content.ReadAsStringAsync();
                var cust = JsonConvert.DeserializeObject<Customers>(customerJsonString);

                Customers.GetCustomers = cust;
            }
            else
            {
                string statusCode = response.StatusCode.ToString();
                string ReasonPhrase = response.ReasonPhrase;
            }

        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
