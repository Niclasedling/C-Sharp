using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Truck : Fordon
    {
        public int MaxLoad { get; set; }
        public void Truckinfo()
        {
            Console.WriteLine($"Märke: {ModelName}" +
                $"\nRegistrringsnummber: {RegistrationNumber}" +
                $"\nByggdes: {Registrated}" +
                $"\nMax lastkapacitet: {MaxLoad}");
        }
    }
}

