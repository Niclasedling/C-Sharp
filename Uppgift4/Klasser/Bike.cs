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
            if (MaxSpeed <= 50)
            {
                Console.WriteLine("\t---Moped---");
                base.Getinfo();
                Console.WriteLine($"Max hastighet: {MaxSpeed}");
            }
            else
            {
                Console.WriteLine("\t---Motorcycklar---");
                base.Getinfo();
                Console.WriteLine($"Max hastighet: {MaxSpeed}");
            }
           
        }
    }
}
