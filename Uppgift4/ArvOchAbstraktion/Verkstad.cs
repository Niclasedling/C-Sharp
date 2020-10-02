using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    public class Verkstad : IVerkstad
    {
        public List<Fordon> Fordonslista { get; set; }

        public Verkstad()
        {
            Fordonslista = new List<Fordon>();
        }
        public void GetFordon(Fordon fordon)
        {
            Fordonslista.Add((fordon));
        }
        public void RemoveFordon(Fordon fordon)
        {
            Fordonslista.Remove((fordon));
        }
    }
}
