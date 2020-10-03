using System;
using System.Dynamic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Klasser;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ArvOchAbstraktion
{
    class Program
    {
        static void Main(string[] args)
        {

            Verkstad backend = new Verkstad();
            var check = true;
            while (check)
            {
                Console.WriteLine("Välj ett alternativ" +
                    "\n [1] Lägg  till ett fordon" +
                    "\n [2] Ta bort ett fordon" +
                    "\n [3] Avsluta program");

                int.TryParse(Console.ReadLine(), out int skapafordon);
                switch (skapafordon)
                {
                    case 1:
                        Console.Clear();
                        backend.Input();
                        break;
                    case 2:
                       
                        foreach (var bil in backend.Fordonslista)
                        {
                            bil.Getinfo();
                            
                        }
                        Console.WriteLine("Vilket fordon vill du ta bort?");
                        var regNr = Console.ReadLine();
                        backend.RemoveFordon(regNr);
                        break;
                    case 3:
                        check = false;
                        break;

                    default:
                        break;
                }
            }
            
        }
    }
    


}

