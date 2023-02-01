using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApp2
{
    internal class Data
    {
        SqlConnection SqlConn;
        string SqlConnection;

        public Data()
        {
            SqlConnection = "Data Source=LAPTOP-020270\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
        }

        public DataTable GetData(string CustomerID)
        {
            Customer cs = new Customer();
            using (SqlConn = new SqlConnection(SqlConnection))
            {
                string data = "";
                DataTable dt = new DataTable();
                SqlConn.Open();
                SqlCommand sql_cmd = new SqlCommand("AllOrdersforID", SqlConn);
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
               // SqlDataReader read = sql_cmd.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
                adapter.Fill(dt);
                /*while (read.Read()) 
                {
                    data = read[0].ToString();
                }*/
                //DataView DS = new DataView();
                SqlConn.Close();
                return dt;
            }
        }

        public Customer GetDataFromModel(string CustomerID)
        {
            Customer cs = new Customer();
            using (SqlConn = new SqlConnection(SqlConnection))
            {
                string data = "";
                DataTable dt = new DataTable();
                SqlConn.Open();
                SqlCommand sql_cmd = new SqlCommand("AllOrdersforID", SqlConn);
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                SqlDataReader read = sql_cmd.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
                //adapter.Fill(dt);
                while (read.Read()) 
                {
                    cs.CustomerID = read[0].ToString();
                    cs.CustomerName = read[1].ToString();
                }
                //DataView DS = new DataView();
                SqlConn.Close();
                return cs;
            }
        }
        public DataTable GetOrder(string OrderID)
        {
            using (SqlConn = new SqlConnection(SqlConnection))
            {
                string order = "";
                DataTable dt = new DataTable();
                SqlConn.Open();
                SqlCommand sql_cmd = new SqlCommand("GetAllOrderDetails", SqlConn);
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("@OrderID", OrderID);
                // SqlDataReader read = sql_cmd.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
                adapter.Fill(dt);
                /*while (read.Read()) 
                {
                    data = read[0].ToString();
                }*/
                //DataView DS = new DataView();
                SqlConn.Close();
                return dt;
            }
        }
        public DataTable GetProduct(string ProductID)
        {
            using (SqlConn = new SqlConnection(SqlConnection))
            {
                string order = "";
                DataTable dt = new DataTable();
                SqlConn.Open();
                SqlCommand sql_cmd = new SqlCommand("GetALlProductDetails", SqlConn);
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("@ProductID", ProductID);
                // SqlDataReader read = sql_cmd.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(sql_cmd);
                adapter.Fill(dt);
                /*while (read.Read()) 
                {
                    data = read[0].ToString();
                }*/
                //DataView DS = new DataView();
                SqlConn.Close();
                return dt;
            }
        }
    }
}
