using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeDB
{
    //these are common queries for the jagex API
    class CommonQueryJagexAPI : CommonQuery
    {
        public string GetUpdateString()
        {
            string query;

            query =
                @"UPDATE ge.items
                    SET 
                    name = json.name,
                    surname = json.price,
                    member = json.change,
                    members = json.members
                " + GetFromOpenJson() + @"
                    WHERE ge.items.itemNum = json.itemNum";

            return query;
        }

        public string GetFromOpenJson()
        {
            return @" 
                FROM OPENJSON(@json)
                WITH(
                itemNum	    INT				'strict $.item.id',	
                name		VARCHAR(200)	'$.item.name',       
                price	    INT				'$.item.current.price',
                change	    INT				'$.item.today.price',
                members	    BIT				'$.item.members')";
        }

        //this function returns the schema for creating a table with json object
        //should take an SQL parameter 
        public string GetInsertString()
        {
            string query;

            query = @"
                INSERT INTO ge.items(itemNum, name, price, change, members)
                SELECT * " + GetFromOpenJson();
            return query;
        }

        public  string GetExceptString()
        {
            return @"
                EXCEPT 
                SELECT itemNum, name, price, change, members
                FROM ge.items";
        }

    }
}
