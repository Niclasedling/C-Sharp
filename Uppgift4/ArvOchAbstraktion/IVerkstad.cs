using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    public interface IVerkstad
    {
        public bool AddVehicles(Fordon fordon);
        public void RemoveVehicles();
        public List<Fordon> Fordonslista { get; set; }
    }
}
