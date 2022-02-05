using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item(50);


            Console.ReadLine();
            /*
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-B8Q8GRIK";
                builder.UserID = "sa";
                builder.Password = "admin123";
                builder.InitialCatalog = "PracticeSQL";
                Console.WriteLine("1");
                Console.ReadLine();
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
            */
        }
        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=PracticeSQL";
        }
    }
}
