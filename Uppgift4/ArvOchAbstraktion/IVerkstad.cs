using Klasser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArvOchAbstraktion
{
    interface IVerkstad
    {
        public void GetFordon(Fordon fordon);
        public List<Fordon> RemoveFordon(Fordon fordon);
    }
}
