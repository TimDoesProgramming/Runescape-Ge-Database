using System;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

namespace GeDB
{
    class JsonFuncJagexAPI : JsonFunc
    {


        public JObject GetFormattedJson(int itemNum)
        {
            return ReformatJson(GetJson(GetJagexURL(itemNum)));
        }

        //three issues, commas, decimals, and units
        //commas in items that are 4 digits
        //decimals in items that have units
        //units in items over 10,000 gold
        public static JObject ReformatJson(JObject json)
        {
            if (json != null)
            {
                json["item"]["members"] = ReformatJsonMembers(json["item"]["members"].ToString());
                json["item"]["current"]["price"] = ReformatJsonPrice(json["item"]["current"]["price"].ToString());
                json["item"]["today"]["price"] = ReformatJsonPrice(json["item"]["today"]["price"].ToString());
            }

            return json;
        }
        public static string ReformatJsonPrice(string incoming)
        {

            StringBuilder str = new StringBuilder(11);
            incoming.ToLower();

            foreach (char c in incoming)
            {

                if (c != ',' && c != '.' && c != ' ')
                {
                    switch (c)
                    {
                        case 'k':
                            str.Append('0', 2);
                            break;
                        case 'm':
                            str.Append('0', 5);
                            break;
                        case 'b':
                            str.Append('0', 8);
                            break;
                        default:
                            str.Append(c);
                            break;
                    }

                }
            }


            return str.ToString();
        }
        public static string ReformatJsonMembers(string incoming)
        {
            string result;

            if (incoming == "true")
                result = "1";
            else if (incoming == "false")
                result = "0";
            else
                result = "NULL";

            return result;
        }
        /*
        public static string readJson(string json)
        {

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
        }
        */


    }
}
