using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    public class VerkstadV2 : IVerkstad
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
        public bool AddVehicles(Fordon fordon)
        {
            var isOktoAdd = InputHelper.TrytoAddVehicles(fordon);
            if (isOktoAdd)
            {
                Fordonslista.Add(fordon);
                return true;
            }
            else
                return false;
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
                Console.Clear();
                Console.WriteLine($"Fordon med regNr {regnummerTomatch} har checkat ur verkstaden");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"En bil med registreringsnummret {regnummerTomatch} hittades inte i verkstaden.");
                Console.ReadKey();
            }
        }

    }
}
