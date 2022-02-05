using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace SQL
{
    class Item
    {
        //this needs to create the item object
        public Item(int id)
        {
            string url = "http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + id.ToString();
            string json ="";

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            Console.WriteLine("{0}", json);
        }
        // this needs to take the information and store it
        public void Add()
        {

        }
    }
}
