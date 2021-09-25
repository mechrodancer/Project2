using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    class Theater
    {

        private const Int32 max_priceCut = 20;
        private int priceCut_cnt = 1;

        private double new_Price = 0.0;
        private double prev_Price = 0.0;

        private static Random rnd = new Random();
        private PriceCutEvent pricecutevent;

        public delegate void PriceCutEvent(PriceCutEventHandler p);

        private ArrayList orderThreads = new ArrayList();

        public double getPrice()
        {
            return new_Price;
        }

        //Stop after t-many price cuts
        public void theaterFunc()
        {
           while (priceCut_cnt <= max_priceCut)
            {
                Set_ticketPrice();

                if (new_Price < prev_Price) ;
                {
                    PriceCutEvent();
                }

                ProcessOrder(GetOrder(), new_Price);
            }

           foreach (Thread item in processingThreads)
            {
                while (item.IsAlive) ;
            }
        }

        //Using pricing model to set dynamic pricing



        //Emmiting event to ticketbroker if price change (new price < oldprice)


        //Receiving order from MultiCellBuffer


        //Ccreate order Processing thread

        //Method started by main

        //Defines a price cut event to call event handlers in broker
        //For each order, spawn an order processing thread
        
    }

}
