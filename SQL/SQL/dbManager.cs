using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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
            builder.InitialCatalog = "PracticeSQL";
            conn.ConnectionString = builder.ConnectionString;
        }
        static void setDB(string dataSource, string userID, string password, string initialCatalog)
        {
            builder.DataSource = dataSource;
            builder.UserID = userID;
            builder.Password = password;
            builder.InitialCatalog = initialCatalog;
            conn.ConnectionString = builder.ConnectionString;
        }
        public static void query(string q)
        {
              
        }
        private static string GetConnectionString()
        {

            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=PracticeSQL";
        }


    }

}
