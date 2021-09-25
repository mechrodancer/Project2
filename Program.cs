using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    public delegate void priceCutEvent(Int32 pr);
    
    class Program
    {
        private const int K = 2;

        private static Thread[] theater_threads = new Thread[K];

        private static Theater[] theaters = new Theater[K];
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Theater Threading Simulator....");

            for(int i = 0; i < K; ++i)
            {
                Theater theater = new Theater();
                theaters[i] = theater;
                theater_threads[i] = new Thread(theater.theaterFunc);
                theater_threads[i].Name = "Theater: " + i;
                theater_threads[i].Start();
                while (!theater_threads[i].IsAlive) ;
            }
            ChickenFarm chickenFarm = new ChickenFarm();
            Thread farmer = new Thread(new ThreadStart(chickenFarm.farmerFunc));
            farmer.Start();
            Retailers chickenStore = new Retailers();
            ChickenFarm.priceCut += new priceCutEvent(chickenStore.chickenOnSale);
            Thread[] retailers = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                retailers[i] = new Thread(new ThreadStart(chickenStore.retailerFunc));
                retailers[i].Name = (i + 1).ToString();
                retailers[i].Start();
            }
        }
    }
}
