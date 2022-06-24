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
    class JsonFuncWikiAPI : JsonFunc
    {

        public JObject GetWikiLatestJson()
        {
            return GetJObjJson(GetLatestWikiURL());
        }

        public JArray GetWikiMappingJson()
        {
            return GetJArrJson(GetMappingWikiURL());
        }
    }
}
