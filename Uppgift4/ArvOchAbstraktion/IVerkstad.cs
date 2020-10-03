using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    interface IVerkstad
    {
        public void AddFordon(Fordon fordon);
        public void RemoveFordon(string regNr);
    }
}
