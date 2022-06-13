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
        //this function returns the schema for creating a table with json object
        //should take an SQL parameter 
        public static string GetInsertString(string param)
        {
            string schema;

            schema = @"SELECT *
              FROM OPENJSON("+param+@")
              WITH(
              itemNum   INT             'strict $.item.id',
              name      DATETIME        '$.Order.Date',
              Price     VARCHAR(200)    '$.item.current.price',
              trend30   real            '$.Item.Quantity'
                
              AS JSON)";
            return schema;
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
