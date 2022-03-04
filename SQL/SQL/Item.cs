using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace SQL  
{
    class Item : Iitem
    {
        public string Name
        {
            get;

            set;
        }
        public int ID
        {
            get;

            set;
        }
        public int Price
        {
            get; 

            set;
        }


        public Item()
        {

        }
        //this needs to create the item object
        public Item(int id)
        {

            JObject json = ItemJson(id);
            try
            {
                if (json.Equals((JObject)default))
                    Console.WriteLine("the jason was");
                else
                {
                    Name = json["item"]["name"].ToString();
                    ID = Convert.ToInt32(json["item"]["id"]);
                    Price = Convert.ToInt32(json["item"]["current"]["price"]);
                    Console.WriteLine("Name: {0}, Price: {1}", Name, Price);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("item ID {0} has error: {1}", id, e.Message);
            }
        }
        // this needs to take the information and store it
        public void Add(int itemID)
        {
            //if(this.)
        }
        private JObject ItemJson(int id)
        {
            string url = "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + id.ToString();
            string preJson = "";
            bool exc = true;
            int count = 0;
            JObject json = (JObject)default;

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



                        if ((int)httpResponse.StatusCode != 404 && count < 3)
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

        public bool isGEItem(int id)
        {
            if (ItemJson(id).Equals((JObject)default))
            {
                return false;
            }
            return true;
        }
    }
}
