using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeDB
{
    class CommonQueryWikiApi : CommonQuery
    {


        public string GetExceptString()
        {
            throw new NotImplementedException();
        }

        public string GetFromOpenJson()
        {
            throw new NotImplementedException();
            
        }

        public string GetInsertStringLatest()
        {
            return @"
                INSERT INTO wiki.items(ID, peak, trough, priceDiff)
                VALUES(@ID, @peak, @trough, @priceDiff)";
        }
        public string GetUpdateStringMapping()
        {
            return @"
                UPDATE wiki.items
                SET name = @name, highAlch = @highAlch, members = @members 
                WHERE ID = @ID";
        }

        public  string GetUpdateString()
        {
            throw new NotImplementedException();
        }
    }
}
