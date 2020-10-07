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
        public bool AddVehicles(Fordon fordon)
        {
            Fordonslista.Add(fordon);
            return true;
        }
      /// <summary>
      /// Tar bort ett fordon med hjälp av att söka på ett regNr
      /// </summary>
        public void RemoveVehicles()
        {
           
            var regnummerTomatch = Console.ReadLine().ToUpper();
            Fordon bilAttTabort = null;

            foreach (var fordon in Fordonslista)
            {
                if (regnummerTomatch == fordon.RegistrationNumber)
                {
                    bilAttTabort = fordon;
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


