using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Truck : Fordon
    {
        public int MaxLoad { get; set; }
        /// <summary>
        /// Skriver ut all info om Lastbilar
        /// </summary>

        public override void Getinfo()
        {
            if (MaxLoad <= 2000)
            {
                Console.WriteLine("\t---Lätta lastbilar---");
                base.Getinfo();
                Console.WriteLine($"Max hastighet: {MaxLoad}");
            }
            else
            {
                Console.WriteLine("\t---Tunga lastbilar---");
                base.Getinfo();
                Console.WriteLine($"Max hastighet: {MaxLoad}");
            }
            
        }
    }
}

