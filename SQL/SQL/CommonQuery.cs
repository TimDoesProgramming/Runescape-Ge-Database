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
    static class CommonQuery
    {


        public static string GetUpdateString()
        {
            string query;

            query = 
                @"UPDATE ge.items
                    SET 
                    name = json.name,
                    surname = json.price,
                    member = json.change,
                    members = json.members
                "+ GetFromOpenJson()+@"
                    WHERE ge.items.itemNum = json.itemNum";

            return query;
        }

        public static string GetFromOpenJson()
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
        public static string GetInsertString()
        {
            string query;

            query = @"
                INSERT INTO ge.items(itemNum, name, price, change, members)
                SELECT * "+ GetFromOpenJson();
            return query;
        }
        public static string GetCreateString(string dbName)
        {
            return (@"USE master
                    GO
                    IF NOT EXISTS(
                        SELECT name
                        FROM sys.databases
                    WHERE name = N'"+dbName+@"')
                    CREATE DATABASE["+dbName+@"]
                    GO");

        }
        public static string GetScehmaString(string schemaName)
        {
            return "CREATE SCHEMA "+schemaName;
        }
        


       

    }
}
