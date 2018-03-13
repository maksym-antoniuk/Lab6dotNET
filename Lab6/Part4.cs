using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part4
    {
        List<Animal> rams;
        Animal wolf;
        Random rand;

        public Part4()
        {
            rand = new Random();
            rams = new List<Animal>();
            rams.Add(new Animal(rand.Next(0, 100), rand.Next(0, 100), rand));
            rams.Add(new Animal(rand.Next(0, 100), rand.Next(0, 100), rand));
            rams.Add(new Animal(rand.Next(0, 100), rand.Next(0, 100), rand));
            wolf = new Animal(rand.Next(0, 100), rand.Next(0, 100), rand);
        }

        public void Start()
        {
            wolf.Run();
            foreach(Animal a in rams)
            {
                a.Run();
            }
        }

        public void Game()
        {
            new Thread(() => { 
            int _new = 0;
                while (true)
                {
                    if (rams.Count == 0)
                    {
                        Console.WriteLine("Баранов не осталось в живых!");
                        break;
                    }
                    for (int i = 0; i < rams.Count; i++)
                    {
                        if (wolf.X == rams[i].X && wolf.Y == rams[i].Y)
                        {
                            Console.WriteLine("Волк съел барана");
                            rams.Remove(rams[i]);
                        }
                    }
                    for (int i = 0; i < rams.Count; i++)
                    {
                        for (int j = i + 1; j < rams.Count; j++)
                        {
                            if (rams[i].X == rams[j].X && rams[i].Y == rams[j].Y)
                            {
                                _new++;
                                Console.WriteLine("Бараны расплодились");
                            }
                        }
                    }
                    for (int i = 0; i < _new; i++)
                    {
                        rams.Add(new Animal(rand.Next(0, 100), rand.Next(0, 100), rand));
                    }
                        
                    _new = 0;
                }
            }).Start();
        }
    }

    public class Animal
    {
        Random rand;
        int x;
        int y;
        bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Animal(int x, int y, Random rand)
        {
            this.rand = rand;
            isAlive = true;
            this.x = x;
            this.y = y;
        }

        public void Run()
        {
            new Thread(() => {
                while (isAlive)
                {
                    lock (rand)
                    {
                        //Thread.Sleep(100);
                        x = rand.Next(0, 100);
                        y = rand.Next(0, 100);
                    }
                    
                }
            }).Start();
        }
    }

    
}
