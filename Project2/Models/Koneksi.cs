using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project2.Models
{
    public class Koneksi
    {
        private SqlConnection con;
        
        public Koneksi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}