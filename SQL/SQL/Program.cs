using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;



namespace GeDB
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * This inserts the first wiki URL
             * 
             * 
             * 
             JsonFuncWikiAPI func2 = new JsonFuncWikiAPI();
            CommonQueryWikiApi q = new CommonQueryWikiApi();

            string itemID;
        
            JObject json = func2.GetJson();

            foreach(JProperty p in json["data"])
            {
                itemID = p.Name;
                Console.WriteLine("{0}", p.Name);

                dbManager.WriteQuery(q.GetInsertStringLatest(), Convert.ToInt32(p.Name), json["data"][itemID]["high"], json["data"][itemID]["low"]);
            }
             */




            Console.ReadLine();

        }
    }
}
