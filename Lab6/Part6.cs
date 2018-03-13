using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part6
    {
        static object _syncRoot = new object();
        const int WRITE = 1;
        const int READ = 2;
        Random rand;

        public Part6()
        {
            rand = new Random();
        }

        public void MainFunction()
        {
            new Thread(Write).Start();
            new Thread(Read).Start();
        }

        private void ReadWrite(int mode, int seek = 0)
        {
            lock (_syncRoot)
            {
                switch (mode)
                {
                    case WRITE:
                        File.AppendAllText("D://part6.txt", ((char)rand.Next(33, 126)).ToString());
                        break;
                    case READ:
                        FileStream file = new FileStream("D://part6.txt", FileMode.Open, FileAccess.Read);
                        file.Seek(seek, SeekOrigin.Begin);
                        Console.Write(Convert.ToChar(file.ReadByte()));
                        file.Close();
                        break;
                }
            }
        }

        private void Write()
        {
            while (true)
            {
                ReadWrite(WRITE);
                Thread.Sleep(1000);
            }
        }

        private void Read()
        {
            Thread.Sleep(500);
            int i = 0;
            while (true)
            {
                ReadWrite(READ, i++);
                Thread.Sleep(1500);
            }
        }
    }
}
