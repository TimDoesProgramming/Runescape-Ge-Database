using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Text.RegularExpressions;

namespace SQL
{
    static class JsonFunc
    {
        /*
         Dependencies: Method GetJson() and Method ReformatJson
             
             
        */

        public static JObject GetFormattedJson(int itemNum)
        {
            return ReformatJson(GetJson(itemNum));
        }
        public static JObject GetJson(int itemNum)
        {
            string url = "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + itemNum.ToString();
            string preJson = "";
            bool exc = true;
            int count = 0;
            int repeat = 3;
            JObject json = null;

            //probably needs to have a check to see if the text is real
            using (WebClient wc = new WebClient())
            {
                //the website writes the json as text
                //this function downloads the string from the url
                do
                {
                    try
                    {
                        exc = false;

                       
                        preJson = wc.DownloadString(url);

                        //converts the string into a json object
                        json = JObject.Parse(preJson);
                        

                    }
                    catch (WebException e)
                    {
                        //The WebException.Response property returns a HtppWebResponse object
                        //https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebresponse?view=net-6.0
                        //https://docs.microsoft.com/en-us/dotnet/framework/network-programming/handling-errors
                        HttpWebResponse httpResponse = (HttpWebResponse)e.Response;



                        if ((int)httpResponse.StatusCode != 404 && count < repeat)
                        {
                            Thread.Sleep(1000);
                            exc = true;
                            count++;
                        }

                        //The StatusCode property has the string value
                        //When cast to into and int, it also has the numeric code associated
                        Console.WriteLine((int)httpResponse.StatusCode + " - " + httpResponse.StatusCode);
                        Console.WriteLine(e.Message);
                    }

                } while (exc);

            }
            return json;
        }



        //three issues, commas, decimals, and units
        //commas in items that are 4 digits
        //decimals in items that have units
        //units in items over 10,000 gold
        public static JObject ReformatJson(JObject json)
        {
            if(json != null)
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

            foreach(char c in incoming)
            {

                if (c != ',' && c != '.'&& c!=' ')
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

        
    }

}
