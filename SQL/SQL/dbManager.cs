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


        /*
         
             
             */
        public static void WriteQuery(string q)
        {
            using (conn)
            {
                conn.ConnectionString = builder.ConnectionString;
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
                conn.ConnectionString = builder.ConnectionString;
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
            Console.WriteLine("success");

        }
        public static void WriteQuery(SqlCommand c)
        {
            using (conn)
            {
                conn.ConnectionString = builder.ConnectionString;
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


        public static void WriteQuery(string q, int ID, JToken? jPeak, JToken? jTrough)
        {
            int peak, trough;

            using (conn)
            {
                conn.ConnectionString = builder.ConnectionString;
                conn.Open();
                try
                {
                    using (SqlCommand comm = new SqlCommand(q, conn))
                    {
                        if(jPeak == null && jTrough == null)
                        {
                            peak = 0;
                            trough = 0;
                        }
                        else
                        {
                            peak = jPeak == null ? jTrough.Value<int>() : jPeak.Value<int>();
                            trough = jTrough == null ? jPeak.Value<int>() : jTrough.Value<int>(); 
                        }



                        comm.Parameters.Add(new SqlParameter("ID", (object)ID));
                        comm.Parameters.Add(new SqlParameter("peak", (object)peak));
                        comm.Parameters.Add(new SqlParameter("trough", (object)trough));
                        comm.Parameters.Add(new SqlParameter("priceDiff", (object)(peak - trough)));
                        comm.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("success");

        }
        public static void WriteQuery(string q, int ID, string name, int highAlch, string memString)
        {

            int members = 0;

            if(memString == "true")
            {
                members = 1;
            }

            using (conn)
            {
                conn.ConnectionString = builder.ConnectionString;
                conn.Open();
                try
                {
                    using (SqlCommand comm = new SqlCommand(q, conn))
                    {

                        comm.Parameters.Add(new SqlParameter("ID", (object)ID));
                        comm.Parameters.Add(new SqlParameter("name", name));
                        comm.Parameters.Add(new SqlParameter("highAlch", (object)highAlch));
                        comm.Parameters.Add(new SqlParameter("members", (object)members));
                        comm.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("success");

        }

        /* Part one
          * 
          * This gets the json from the WIKI API endpoint
          * iterates through the JContainer with key ["data"]
          * for Each JProperty in the JContainer the program collects the key/property name as this was the item id and is also the primary key in the DB
          * then the information for each item id is passed to the DB manager who runs the insert query for each item 
          */
        public static void FirstWikiInsert()
        {
            JsonFuncWikiAPI wikiFunc = new JsonFuncWikiAPI();
            CommonQueryWikiApi q = new CommonQueryWikiApi();

            string itemID;

            JObject json = wikiFunc.GetWikiLatestJson();

            foreach (JProperty p in json["data"])
            {
                itemID = p.Name;
                Console.WriteLine("{0}", p.Name);

                WriteQuery(q.GetInsertStringLatest(), Convert.ToInt32(p.Name), json["data"][itemID]["high"], json["data"][itemID]["low"]);
            }
        }

        public static void WikiUpdateMapping()
        {
            JsonFuncWikiAPI wikiFunc = new JsonFuncWikiAPI();
            CommonQueryWikiApi q = new CommonQueryWikiApi();

            JArray json = wikiFunc.GetWikiMappingJson();

            foreach (JObject j in json)
            {
                Console.WriteLine("{0}", j["id"]);
                WriteQuery(q.GetUpdateStringMapping(), Convert.ToInt32(j["id"]), j["name"].ToString(), Convert.ToInt32(j["highalch"]), j["members"].ToString());
            }
        }
    }
}
