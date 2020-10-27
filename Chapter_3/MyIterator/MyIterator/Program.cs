using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyIterator
{
    class Program
    {
        static void Main(string[] args)
        {

            #region "使用IterationSample"
            //object[] values = { "a", "b", "c", "d", "e" };
            //IterationSample collection = new IterationSample(values, 3);
            //foreach(object x in collection)
            //{
            //    Console.WriteLine(x);
            //}
            #endregion

            #region "使用CreateEnumerable"
            //IEnumerable<int> iterable = CreateEnumerable();
            //IEnumerator<int> iterator = iterable.GetEnumerator();
            //Console.WriteLine("Starting to iterate");
            //while (true)
            //{
            //    Console.WriteLine("Calling MoveNext()……");
            //    bool result = iterator.MoveNext();
            //    Console.WriteLine("... MoveNext result={0}", result);
            //    if (!result)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Fetching Current...");
            //    Console.WriteLine("... Current result = {0}", iterator.Current);
            //}
            #endregion

            #region "使用CountWithTimeLimit"
            //DateTime stop = DateTime.Now.AddSeconds(2);
            //foreach (var i in CountWithTimeLimit(stop))
            //{
            //    Console.WriteLine("Received {0}",i);
            //    if (i > 3)
            //    {
            //        Console.WriteLine("Returning");
            //        return;
            //    }
            //    Thread.Sleep(300);
            //}
            #endregion

            MyDates myDates = new MyDates();
            foreach (var time in myDates.DateRange)
            {
                Console.WriteLine(time);
            }
            Console.ReadLine();
        }
        static readonly string Padding = new string(' ', 30);
        static IEnumerable<int> CreateEnumerable()
        {
            Console.WriteLine("{0}Start of CreateEnumerable()", Padding);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}About to yield {1}",Padding,i);
                yield return i;
                Console.WriteLine("{0}After yield",Padding);
            }
            Console.WriteLine("{0}Yielding final value",Padding);
            yield return -1;
            Console.WriteLine("{0}End of CreateEnumerable()",Padding);
        }
        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (DateTime.Now >= limit)
                    {
                        yield break;
                    }
                    yield return i;
                }
            }
            finally
            {
                Console.WriteLine("Stopping!");
            }
        }
    }
}
