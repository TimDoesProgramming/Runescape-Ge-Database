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
    static class ItemList
    {
        //this turns a list of items into a collection
        public static List<int> itemList;

        //Gets a list of valid item ids
        private static List<int> GetList()
        {
            List<int> itemIDs = new List<int>();
            Iitem json = new Item();

            for (int i = 1; i < 26154; i++)
            {
                if(json.isGEItem(i))
                    itemIDs.Add(i);
            }
            return itemIDs;
        }
        public static void ListToFile()
        {
            //to be implemented
        }


    }
}
