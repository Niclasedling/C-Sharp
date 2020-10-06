using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    class VerkstadV2 : IVerkstad
    {
        public List<Fordon> Fordonslista { get; set; }

        public VerkstadV2()
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
        /// <summary>
        /// Tar bort ett fordon från verkstaden
        /// </summary>
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
            }
            else
            {
                Console.WriteLine($"En bil med registreringsnummret {regnummerTomatch} hittades inte i verkstaden.");
            }
        }

        public bool TrytoAddVehicles(Bike bike)
        {
            var moped = bike;

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
