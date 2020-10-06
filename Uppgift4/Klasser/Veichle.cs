using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Fordon
    {
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal OdoMeter { get; set; }
        public DateTime Registrated { get; set; }
        /// <summary>
        /// Skriver ut infromation om alla fordon som för nuvarande finns i listan
        /// </summary>
        public virtual void Getinfo()
        {
            Console.WriteLine($"Märke: { ModelName}" +
                $"\nReg nummer: {RegistrationNumber}" +
                $"\nByggdes: {DateTime.Now}");

        }

    }

}
