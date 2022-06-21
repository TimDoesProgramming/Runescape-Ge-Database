using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;


namespace GeDB
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
        public static void WriteQuery(string q, JObject json)
        {
            using (conn)
            {
                
                conn.Open();
                try
                {
                    using (SqlCommand comm = new SqlCommand(q, conn))
                    {
                       
                        comm.Parameters.Add(new SqlParameter("json", json.ToString()));
                        comm.ExecuteNonQuery();
                    }
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("If no message above, then it's a success");

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
        public static void WriteQuery(string q, int ID, int peak, int trough)
        {


            using (conn)
            {

                conn.Open();
                try
                {
                    using (SqlCommand comm = new SqlCommand(q, conn))
                    {

                        comm.Parameters.Add(new SqlParameter("ID", ID));
                        comm.Parameters.Add(new SqlParameter("peak", peak));
                        comm.Parameters.Add(new SqlParameter("trough", trough));
                        comm.Parameters.Add(new SqlParameter("priceDiff", (peak - trough)));
                        comm.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("If no message above, then it's a success");

        }
        public static void WriteQuery(string q, string name, int peak, int trough)
        {


            using (conn)
            {

                conn.Open();
                try
                {
                    using (SqlCommand comm = new SqlCommand(q, conn))
                    {

                        comm.Parameters.Add(new SqlParameter("ID", ID));
                        comm.Parameters.Add(new SqlParameter("peak", peak));
                        comm.Parameters.Add(new SqlParameter("trough", trough));
                        comm.Parameters.Add(new SqlParameter("priceDiff", (peak - trough)));
                        comm.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("If no message above, then it's a success");

        }
        public static void Update(string dbName)
        {

        }

        public static void Insert()
        {

        }
        private static string GetConnectionString()
        {
            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=PracticeSQL";
        }


    }

}
