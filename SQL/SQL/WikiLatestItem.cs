using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace GeDB  
{
    class WikiLatestItem
    {

        public int ID
        {
            get;
            set;
        }
        public int Peak
        {
            get; 

            set;
        }
        public int Trough
        {
            get;

            set;
        }

        public WikiLatestItem(int id, int peak, int trough)
        {
            
            ID = id;
            Peak = peak;
            Trough = trough;
        }

    }
}
