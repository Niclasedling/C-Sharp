using System;
using System.Collections.Generic;

namespace Klasser
{
    public class Bil : Fordon
    {
        public bool HasTowbar { get; set; }
        public List<Bil> Billista { get; set; }

        public Bil()
        {
            Billista = new List<Bil>();
        }
        Bil Car = new Bil();

        
    }


}
