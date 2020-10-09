using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace Klasser
{
    public class Car : Fordon
    {
        public bool HasTowbar { get; set; }
        /// <summary>
        /// Skriver ut info om bilar!
        /// </summary>
       public override void Getinfo()
        {
            Console.WriteLine("\t---Bilar---");
            base.Getinfo();
            if (HasTowbar)
            {
                Console.WriteLine("Har dragkrok");
            }
            else
            {
                Console.WriteLine("Har inte dragkrok");
            }
        }
    }
}
