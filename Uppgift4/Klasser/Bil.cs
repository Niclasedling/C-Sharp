using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace Klasser
{
    public class Car : Fordon
    {
        public bool HasTowbar { get; set; }

        public override void Getinfo()
        {
            Console.WriteLine("Bilar:");
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
