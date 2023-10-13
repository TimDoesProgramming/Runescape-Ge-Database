using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;





namespace GeDB
{
    class Program
    {
        static void Main(string[] args)
        {



            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            dbManager.FirstWikiInsert();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            
            Console.WriteLine("RunTime {0} ms", ts.Milliseconds);
        }
    }
}
