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
            Console.WriteLine("\t---Lastbilar---");
            base.Getinfo();
            Console.WriteLine($"Max lastvikt: {MaxLoad}");
        }
    }
}

