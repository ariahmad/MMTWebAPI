using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class Orders
    {

        #region Fields

        private int _ORDERID;
        private int _CUSTOMERID;
        private DateTime _ORDERDATE;
        private DateTime _DELIVERYEXPECTED;
        private bool _CONTAINSGIFT;
        private string _SHIPPINGMODE;
        private string _ORDERSOURCE;

        #endregion

        #region Properties

        /// <summary>
        /// Product ID.
        /// </summary>
        public int ORDERID
        {
            get
            {
                return _ORDERID;
            }
        }

        /// <summary>
        /// Product Name.
        /// </summary>
        public int CUSTOMERID
        {
            get
            {
                return _CUSTOMERID;
            }
        }

        /// <summary>
        /// Pack height.
        /// </summary>
        public DateTime ORDERDATE
        {
            get
            {
                return _ORDERDATE;
            }
        }

        /// <summary>
        /// Pack width
        /// </summary>
        public DateTime DELIVERYEXPECTED
        {
            get
            {
                return _DELIVERYEXPECTED;
            }
        }

        /// <summary>
        /// Pack weight.
        /// </summary>
        public bool CONTAINSGIFT
        {
            get
            {
                return _CONTAINSGIFT;
            }
        }

        /// <summary>
        /// SHIPPINGMODE.
        /// </summary>
        public string SHIPPINGMODE
        {
            get
            {
                return _SHIPPINGMODE;
            }
        }

        /// <summary>
        /// ORDERSOURCE.
        /// </summary>
        public string ORDERSOURCE
        {
            get
            {
                return _ORDERSOURCE;
            }
        }

        #endregion


        #region Data Access


       
        public static Products GetAll()
        {
            Products product = new Products();

            var con = ConfigurationManager.ConnectionStrings["SSE_TestConnectionString"].ToString();


            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select * from Orders";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader dataReader = oCmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        product.PopulateFromReader(dataReader);
                    }

                    myConnection.Close();
                }
            }
            return product;

        }



       
        public static Products GetByID(int ORDERID)
        {
            Products product = new Products();

            var con = ConfigurationManager.ConnectionStrings["SSE_TestConnectionString"].ToString();


            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select * from Orders where ORDERID=@ORDERID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ORDERID", ORDERID);
                myConnection.Open();
                using (SqlDataReader dataReader = oCmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        product.PopulateFromReader(dataReader);
                    }

                    myConnection.Close();
                }
            }
            return product;

        }

       
        internal void PopulateFromReader(SqlDataReader dataReader)
        {
            _ORDERID = (int)dataReader["ORDERID"];
            _CUSTOMERID = (int)dataReader["CUSTOMERID"];
            _ORDERDATE = (DateTime)dataReader["ORDERDATE"];
            _CONTAINSGIFT = (bool)dataReader["CONTAINSGIFT"];
            _DELIVERYEXPECTED = (DateTime)dataReader["DELIVERYEXPECTED"];
            _SHIPPINGMODE = dataReader["FirstName"].ToString();
            _ORDERSOURCE = dataReader["FirstName"].ToString();
        }

        #endregion
    }
}