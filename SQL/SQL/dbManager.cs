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


        public static void Connect()
        {
           
           try
           {
               SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
               builder.DataSource = "LAPTOP-B8Q8GRIK";
               builder.UserID = "sa";
               builder.Password = "admin123";
               builder.InitialCatalog = "PracticeSQL";

               using (SqlConnection conn = new SqlConnection())
               {
                   conn.ConnectionString = builder.ConnectionString;
                   conn.Open();
                    
                   Console.WriteLine("State: {0}", conn.State);  
                   Console.WriteLine("ConnectionString: {0}",
                       conn.ConnectionString);

               }


               Console.WriteLine("success");
               Console.ReadLine();
           }
           catch(SqlException e)
           {
               Console.WriteLine(e.ToString());
           }
       
        }

    
        private static string GetConnectionString()
        {

            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=PracticeSQL";
        }


    }

}
