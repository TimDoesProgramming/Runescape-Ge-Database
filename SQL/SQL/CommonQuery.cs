using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeDB
{
    class CommonQuery
    {

        public string GetCreateString(string dbName)
        {
            return (@"USE master
                    GO
                    IF NOT EXISTS(
                        SELECT name
                        FROM sys.databases
                    WHERE name = N'" + dbName + @"')
                    CREATE DATABASE[" + dbName + @"]
                    GO");

        }

        public string GetScehmaString(string schemaName)
        {
            return "CREATE SCHEMA " + schemaName;
        }

        public string getItem(string id)
        {
            return @"SELECT * FROM wiki.items
                    WHERE ID = "+ id;
        }

        public string getItems(string id)
        {
            return @"SELECT * FROM wiki.items
                    WHERE ID = " + id;
        }
    }
}
