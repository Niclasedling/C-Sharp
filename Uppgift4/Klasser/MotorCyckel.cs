using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Bike : Fordon
    {
        public int MaxSpeed { get; set; }

        public override void Getinfo()
        {
            Console.WriteLine("\t---Motorcycklar---");
            base.Getinfo();
            Console.WriteLine($"Max hastighet: {MaxSpeed}");
        }
    }
}
