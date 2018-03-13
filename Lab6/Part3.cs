using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part3
    {
        private static object _syncRoot = new object();
        int team1 = 5, team2 = 5, team3 = 5;

        public void MainFunction()
        {
            Console.Write(team1 + "   " + team2 + "   " + team3 + "   ");
            Thread.Sleep(600);
            Thread teamOne = new Thread(t31);
            Thread teamTwo = new Thread(t32);
            Thread teamThree = new Thread(t33);
            teamOne.Start();
            teamTwo.Start();
            teamThree.Start();
        }
        private void kill(int num)
        {
            Monitor.Enter(_syncRoot);
            int m;
            switch (num)
            {
                case 1: team1 += new Random().Next(0, 10); break;
                case 2: team2 += new Random().Next(0, 10); break;
                case 3: team3 += new Random().Next(0, 10); break;
            }
            do
            {
                m = new Random().Next(1, 4);    //m - команда, коорую убиваем
            }
            while (m == num);
            int players = 0;
            switch (m)
            {
                case 1:
                    players = new Random().Next(0, team1);
                    team1 -= players;
                    break;
                case 2:
                    players = new Random().Next(0, team2);
                    team2 -= players;
                    break;
                case 3:
                    players = new Random().Next(0, team3);
                    team3 -= players;
                    break;
            }
            Console.WriteLine(team1 + "   " + team2 + "   " + team3 + "   ");
            Thread.Sleep(1000);
            Monitor.Exit(_syncRoot);
        }
        private void t31() { for (int i = 0; i < 10; i++) kill(1); }
        private void t32() { for (int i = 0; i < 10; i++) kill(2); }
        private void t33() { for (int i = 0; i < 10; i++) kill(3); }
    }
}
