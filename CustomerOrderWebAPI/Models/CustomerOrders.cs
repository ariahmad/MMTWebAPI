using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class CustomerOrders
    {
       // TODO: change structure to get a required json structure
        public FullName FullName { get; set; }
        public Address Address { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DeliveryExpected { get; set; }




        public static List<CustomerOrders> GetByID(string customerId)
        {
            List<CustomerOrders> orders = new List<CustomerOrders>();

            var con = ConfigurationManager.ConnectionStrings["SSE_TestConnectionString"].ToString();


            using (SqlConnection myConnection = new SqlConnection(con))
            {
              

                // TODO: change below to store procedure in the database, I tried but had no permission

                string oString = "Select ord.ORDERID,ord.ORDERDATE,case when ord.CONTAINSGIFT =1 then 'Gift' else prd.PRODUCTNAME end as PRODUCTNAME, otm.QUANTITY, otm.PRICE,  ord.DELIVERYEXPECTED from orders ord" +
                                 " inner join ORDERITEMS otm on otm.ORDERID = ord.ORDERID inner join PRODUCTS prd on prd.PRODUCTID = otm.PRODUCTID" +
                                 " where CUSTOMERID = @customerId and ord.ORDERDATE = (select top 1 ORDERDATE from ORDERS where CUSTOMERID = @customerId order by ORDERDATE desc)" +
                                 " order by ORDERDATE desc";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@customerId", customerId);
                myConnection.Open();
                using (SqlDataReader dataReader = oCmd.ExecuteReader())
                {
                   
                    while (dataReader.Read())
                    {
                        CustomerOrders customerOrders = new CustomerOrders();
                        customerOrders.PopulateFromReader(dataReader);
                        orders.Add(customerOrders);
                    }

                    myConnection.Close();
                }
            }
            return orders;

        }


        internal void PopulateFromReader(SqlDataReader dataReader)
        {
            // TODO: check for DBNull in the below
            OrderID = (int)dataReader["ORDERID"];
            OrderDate = (DateTime)dataReader["ORDERDATE"];
            ProductName = dataReader["PRODUCTNAME"].ToString();
            OrderDate = (DateTime)dataReader["ORDERDATE"];
            Quantity = (int)dataReader["QUANTITY"];
            Price = (decimal)dataReader["PRICE"];
            DeliveryExpected = (DateTime)dataReader["DELIVERYEXPECTED"];

        }
    }
}