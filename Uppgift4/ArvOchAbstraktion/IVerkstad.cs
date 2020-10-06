﻿using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    interface IVerkstad
    {
        public void AddVehicles(Fordon fordon);
       
        public void RemoveVehicles();
        public List<Fordon> Fordonslista { get; set; }
    }
}
