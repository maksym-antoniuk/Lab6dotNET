using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part1
    {
        string[] lines;
        private static object _syncRoot = new object();

        public Part1(string path)
        {
            lines = File.ReadAllLines(path);
        }

        public void IsContains(string s)
        {
            Thread[] threads = new Thread[lines.Length - 1];
            for(int i = 0; i < lines.Length - 1; i++)
            {
                threads[i] = new Thread(() =>
                {
                    lock (_syncRoot)
                        Console.Write(Search(lines[i], s) ? Environment.NewLine + "Found" : "");
                });
                threads[i].Start();
            }

            foreach(Thread t in threads)
            {
                t.Join();
            }
        }

        private bool Search(string line, string s)
        {
            lock(_syncRoot)
                return line.Contains(s);
        }
    }
}
