using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Bus : Fordon
    {
        public int MaxPassengers { get; set; }
        /// <summary>
        /// Skriver ut all info om Lastbilar
        /// </summary>
        public override void Getinfo()
        {
            if (MaxPassengers <= 10)
            {
                Console.WriteLine("\t---Minibuss---");
                base.Getinfo();
                Console.WriteLine($"Max antal passagerare: {MaxPassengers}");
            }
            else
            {
                Console.WriteLine("\t---Buss---");
                base.Getinfo();
                Console.WriteLine($"Max antal passagerare: {MaxPassengers}");
            }
            
        }
    }
}
