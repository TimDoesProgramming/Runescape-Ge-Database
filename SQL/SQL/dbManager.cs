﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;


namespace SQL
{
    public static class dbManager
    {
        private static SqlConnection conn;
        private static SqlConnectionStringBuilder builder;


        static dbManager()
        {
            conn = new SqlConnection();
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-B8Q8GRIK";
            builder.UserID = "sa";
            builder.Password = "admin123";
            builder.InitialCatalog = "ExchangeDB";
            conn.ConnectionString = builder.ConnectionString;
        }
        //dunno if i want this public
        private static void setDB(string dataSource, string userID, string password, string initialCatalog)
        {
            builder.DataSource = dataSource;
            builder.UserID = userID;
            builder.Password = password;
            builder.InitialCatalog = initialCatalog;
            conn.ConnectionString = builder.ConnectionString;
        }
        public static void WriteQuery(string q)
        {
            using (conn)
            {
                SqlCommand comm = new SqlCommand(q, conn);
                conn.Open();
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void WriteQuery(SqlCommand c)
        {
            using (conn)
            {
                
                conn.Open();
                try
                {
                   c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void Update(string dbName)
        {

        }

        public static void Insert(JObject json)
        {

        }
        private static string GetConnectionString()
        {
            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=PracticeSQL";
        }


    }

}
