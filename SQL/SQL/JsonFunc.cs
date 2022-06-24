using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Text.Json;
using System.Net;

namespace GeDB
{
    class JsonFunc
    {

        protected static void Repeat(ref int count, int repeat, ref bool exc)
        {

            if (count < repeat)
            {
                Console.WriteLine("Hit API call limit, retrying: {0} ", count + 1);
                Thread.Sleep(30000);
                exc = true;
                count++;
            }
        }
        public static string GetPreJson(string url)
        {
            string preJson = "";
            bool exc = true;
            int count = 0;
            int repeat = 3;

            using (WebClient wc = new WebClient())
            {
                //the website writes the json as text
                //this function downloads the string from the url
                wc.Headers.Add("User-Agent", "Creating a flipping program - Hi_Im_Tim#1648");
                do
                {
                    try
                    {
                        exc = false;

                        preJson = wc.DownloadString(url);

                    }
                    catch (WebException e)
                    {
                        //The WebException.Response property returns a HtppWebResponse object
                        //https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebresponse?view=net-6.0
                        //https://docs.microsoft.com/en-us/dotnet/framework/network-programming/handling-errors
                        HttpWebResponse httpResponse = (HttpWebResponse)e.Response;


                        if ((int)httpResponse.StatusCode != 404)
                        {
                            Repeat(ref count, repeat, ref exc);
                        }

                        //The StatusCode property has the string value
                        //When cast to into and int, it also has the numeric code associated
                        Console.WriteLine(e.Message);
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Repeat(ref count, repeat, ref exc);
                    }

                } while (exc);

            }
            return preJson;
        }


        public static JObject GetJObjJson(string url)
        {
            JObject json = null;

            try
            {
                //converts the string into a json object
                json = JObject.Parse(GetPreJson(url));
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }

            return json;
        }

        public static JArray GetJArrJson(string url)
        {
            JArray json = null;

            try
            {
                //converts the string into a json object
                json = JArray.Parse(GetPreJson(url));
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }

            return json;
        }

        protected static string GetJagexURL(int itemID)
        {
            return "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + itemID.ToString();
        }

        protected static string GetLatestWikiURL()
        {
            return "https://prices.runescape.wiki/api/v1/osrs/latest";
        }
        protected static string GetMappingWikiURL()
        {
            return "https://prices.runescape.wiki/api/v1/osrs/mapping";
        }

    }
}
