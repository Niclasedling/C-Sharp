using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    public class Verkstad
    {
        public List<Fordon> Fordonslista { get; set; }

        public Verkstad()
        {
            Fordonslista = new List<Fordon>();
        }
    }
}
