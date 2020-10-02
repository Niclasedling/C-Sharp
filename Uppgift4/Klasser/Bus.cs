using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Bus : Fordon
    {
        public int MaxPassengers { get; set; }

        public override void Getinfo()
        {
            Console.WriteLine("\t---Bussar---");
            base.Getinfo();
            Console.WriteLine($"Max antal passagerare:{MaxPassengers}");
        }
    }
}
