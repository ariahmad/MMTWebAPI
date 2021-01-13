
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerOrderWebAPI.Models
{
    public class Products
    {
        #region Fields

        private int _PRODUCTID;
        private string _PRODUCTNAME;
        private decimal _PACKHEIGHT;
        private decimal _PACKWIDTH;
        private decimal _PACKWEIGHT;
        private string _COLOUR;
        private string _SIZE;

        #endregion

        #region Properties

       
        public int PRODUCTID
        {
            get
            {
                return _PRODUCTID;
            }
        }

       
        public string PRODUCTNAME
        {
            get
            {
                return _PRODUCTNAME;
            }
        }

       
        public decimal PACKHEIGHT
        {
            get
            {
                return _PACKHEIGHT;
            }
        }

        
        public decimal PACKWIDTH
        {
            get
            {
                return _PACKWIDTH;
            }
        }

       
        public decimal PACKWEIGHT
        {
            get
            {
                return _PACKWEIGHT;
            }
        }

       
        public string COLOUR
        {
            get
            {
                return _COLOUR;
            }
        }

       
        public string SIZE
        {
            get
            {
                return _SIZE;
            }
        }





        #endregion

        #region Data Access


       
        public static List<Products> GetAll()
        {
            List<Products> productList = new List<Products>();

            var con = ConfigurationManager.ConnectionStrings["SSE_TestConnectionString"].ToString();


            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select * from PRODUCTS";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader dataReader = oCmd.ExecuteReader())
                {
                    Products product = new Products();
                    while (dataReader.Read())
                    {
                        product.PopulateFromReader(dataReader);
                        productList.Add(product);
                    }

                    myConnection.Close();
                }
            }
            return productList;

        }



        
        public static Products GetByID(int productID)
        {
            Products product = new Products();

            var con = ConfigurationManager.ConnectionStrings["SSE_TestConnectionString"].ToString();

           
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select * from PRODUCTS where FirstName=@ProductID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ProductID", productID);
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
            _PRODUCTID = (int)dataReader["PRODUCTID"];
            _PRODUCTNAME = dataReader["PRODUCTNAME"].ToString();
            if (dataReader["PACKHEIGHT"] is DBNull) { _PACKHEIGHT = 0; } else { _PACKHEIGHT = (decimal)dataReader["PACKHEIGHT"]; }
            if (dataReader["PACKWEIGHT"] is DBNull) { _PACKWEIGHT = 0; } else { _PACKWEIGHT = (decimal)dataReader["PACKWEIGHT"]; }
            if (dataReader["PACKWIDTH"] is DBNull) { _PACKWIDTH = 0; } else { _PACKWIDTH = (decimal)dataReader["PACKWIDTH"]; }
            _COLOUR = dataReader["COLOUR"].ToString();
            _SIZE = dataReader["SIZE"].ToString();
        }

        #endregion

    }
}