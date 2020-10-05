using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Bike : Fordon
    {
        public int MaxSpeed { get; set; }
        /// <summary>
        /// Skriver ut all info om motorcyklar
        /// </summary>
        public override void Getinfo()
        {
            Console.WriteLine("\t---Motorcycklar---");
            base.Getinfo();
            Console.WriteLine($"Max hastighet: {MaxSpeed}");
        }
    }
}
