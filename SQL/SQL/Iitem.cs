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
    interface Iitem
    {
        bool isGEItem(int id);
        
    }
}
