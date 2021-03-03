using System;
using System.Collections.Generic;
using System.IO;
using SetExample.Entities;


namespace SetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<LogRecord> set = new HashSet<LogRecord>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            /* 
             * Text expected from a txt:
             * amanda 2020-08-26T20:45:08
               alex86 2020-08-26T21:49:37
               bobbrown 2020-08-27T03:19:13
               amanda 2020-08-27T08:11:00
               jeniffer3 2020-08-27T09:19:24
               alex86 2020-08-27T22:39:52
               amanda 2020-08-28T07:42:19 */
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(" ");
                        string name = line[0];
                        DateTime dateTime = DateTime.Parse(line[1]);
                        set.Add(new LogRecord { Username = name, Instant = dateTime });
                    }
                    Console.WriteLine("Total user: "  + set.Count);

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
