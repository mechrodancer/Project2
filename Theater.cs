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
        private static Random rand_date = new Random();
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

        public void Set_ticketPrice()
        {
            DateTime now = DateTime.Now;
            int range = rand_date.Next(1,36);

            Console.WriteLine("Today's date is {0}", now.Date);
            DateTime order_date = DateTime.Now.AddDays(range);

            prev_Price = new_Price;
            Random rand_numOrder = new Random();
            int num_order = rand_numOrder.Next(1, 2);

            new_Price = PricingModel.calc_newPrice(num_order, order_date);
            prev_Price = PricingModel.original_price;

        }

        

        //Emmiting event to ticketbroker if price change (new price < oldprice)
        public void newPriceEvent()
        {

        }


        //Receiving order from MultiCellBuffer
        public void receive_Order()
        {

        }


        //Ccreate order Processing thread
        public void proccess_Order()
        {

        }

        //Method started by main

        //For each order, spawn an order processing thread
        public void show_Order()
        {

        }
       
        //Defines a price cut event to call event handlers in broker 
        public void PriceCutEvent()
        {

        }
        
    }

}
