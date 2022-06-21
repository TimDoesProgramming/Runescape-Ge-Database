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
            JsonFunc func = new JsonFuncWikiAPI();
            JsonFuncWikiAPI func2 = new JsonFuncWikiAPI();

            string itemID;
            WikiLatestItem item;
            JObject json = func2.testJson();

            foreach(JProperty p in json["data"])
            {
                itemID = p.Name;

                item = new WikiLatestItem(Convert.ToInt32(p.Name), Convert.ToInt32(json["data"][itemID]["high"].ToString()), Convert.ToInt32(json["data"][itemID]["low"].ToString()));
                
            }
                
               
            
            Console.ReadLine();

        }
    }
}
