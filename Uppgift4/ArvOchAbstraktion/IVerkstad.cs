using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    interface IVerkstad
    {
        /// <summary>
        /// Lägger till ett fordon till verkstaden
        /// </summary>
        /// <param name="fordon"></param>
        public void AddVehicles(Fordon fordon);
        /// <summary>
        /// Tar bort ett fordon i listan men hjälp av registreringsnummer som sökväg
        /// </summary>
        public void RemoveVehicles();
        public List<Fordon> Fordonslista { get; set; }
    }
}
