﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Truck : Fordon
    {
        public int MaxLoad { get; set; }

        public override void Getinfo()
        {
            Console.WriteLine("Lastbilar:");
            base.Getinfo();
            Console.WriteLine($"Max lastvikt: {MaxLoad}");
        }
    }
}

