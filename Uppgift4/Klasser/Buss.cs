using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Buss : Fordon
    {
        public int MaxPassengers { get; set; }
        public void Bussinfo()
        {
            Console.WriteLine($"Märke: {ModelName}" +
                $"\nRegistrringsnummber: {RegistrationNumber}" +
                $"\nByggdes: {Registrated}" +
                $"\nTotalt antal passagerar: {MaxPassengers}");
        }
    }
}
