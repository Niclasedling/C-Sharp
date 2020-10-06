using System;
using System.Dynamic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Klasser;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ArvOchAbstraktion
{

    public class Verkstad : IVerkstad
    {
       
        

        public List<Fordon> Fordonslista { get; set; }

        public Verkstad()
        {
            Fordonslista = new List<Fordon>();
        }
        /// <summary>
        /// Lägger till ett fordon till verkstaden
        /// </summary>
        /// <param name="fordon"></param>
        public void AddVehicles(Fordon fordon)
        {
            Fordonslista.Add(fordon);
        }
      
        public void RemoveVehicles()
        {
           
            var regnummerTomatch = Console.ReadLine().ToUpper();
            Fordon bilAttTabort = null;

            foreach (var bil in Fordonslista)
            {
                if (regnummerTomatch == bil.RegistrationNumber)
                {
                    bilAttTabort = bil;
                }
            }
            if (bilAttTabort != null)
            {
                Fordonslista.Remove(bilAttTabort);
                Console.WriteLine($"Fordon med regNr {regnummerTomatch} har checkat ur verkstaden");
            }
            else
            {
                Console.WriteLine($"En bil med regNr {regnummerTomatch} hittades inte i verkstaden.");
            }
        }
        public bool TrytoAddVehicles(Bike bike)
        {
            
            if (bike.MaxSpeed <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}


