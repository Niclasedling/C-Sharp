using System;
using System.Text;
using System.Collections.Generic;


namespace Klasser
{
    public class Car : Fordon
    {
        public bool HasTowbar { get; set; }


        public void Carinfo()
        {
            Console.WriteLine($"Märke: {ModelName}" +
                $"\nRegistrringsnummber: {RegistrationNumber}" +
                $"\nByggdes: {Registrated}" +
                $"\nDragkrock: {HasTowbar}");
        }



    }


}
