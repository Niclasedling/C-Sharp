using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Bike : Fordon
    {
        public int MaxSpeed { get; set; }

        public void Bikeinfo()
        {
            Console.WriteLine($"Märke: {ModelName}" +
                $"\nRegistrringsnummber: {RegistrationNumber}" +
                $"\nByggdes: {Registrated}" +
                $"\nMaxHastighet: {MaxSpeed}");
        }


    }
}
