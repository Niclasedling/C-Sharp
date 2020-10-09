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
            var mainProgram = true;
            while (mainProgram)
            {
                Console.WriteLine("Vilken verkstad vill du välja?" +
                "\n[1] Hasses stora verkstad" +
                "\n[2] Hasses lilla verkstad" +
                "\n[3] Avsluta");

                int.TryParse(Console.ReadLine(), out int Main);
                switch (Main)
                {
                    case 1:
                        IVerkstad verkstad = new Verkstad();
                        MainProgram(verkstad);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        IVerkstad verkstadv2 = new VerkstadV2();
                        MainProgram(verkstadv2);
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Du måste välja alternativ 1-3");
                        break;
                }
            }
        }

        public static void MainProgram(IVerkstad verkstad)
        {
            var check = true;
            while (check)
            {
                Console.WriteLine("----Välkommen till Hasses fordonsverkstad----" +
                    "\n " +
                    "\t Vad vill vår kära kund göra?" +
                    "\n " +
                    "\n [1] Lämna in ett fordon" +
                    "\n [2] Hämta ett fordon" +
                    "\n [3] Titta på alla fordon i verkstaden" +
                    "\n [4] Avsluta vistelse");

                int.TryParse(Console.ReadLine(), out int addVehicles);
                switch (addVehicles)
                {
                    case 1:
                        Console.Clear();
                        var program = true;
                        while (program)
                        {
                            Console.WriteLine("Vilken typ av fordon vill du lämna in??" +
                                    "\n [1] En bil?" +
                                    "\n [2] En motorcyckel?" +
                                    "\n [3] En buss?" +
                                    "\n [4] En lastbil?" +
                                    "\n [5] Visa alla fordon i verkstaden" +
                                    "\n [6] Tillbaka till menys");

                            int.TryParse(Console.ReadLine(), out int creatVehicles);

                            switch (creatVehicles)
                            {
                                case 1:                                ///---------------------------------------///
                                    Console.Clear();                   ///------------SKAPAR EN BIL--------------///
                                    var car = InputHelper.CreateCar(); ///---------------------------------------///
                                    verkstad.AddVehicles(car);
                                    car.Getinfo();
                                    Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                        "\n ");
                                    InputHelper.BackToMenu();
                                    Console.Clear();

                                    break;
                                case 2:
                                    Console.Clear();
                                    var bike = InputHelper.CreateBike();
                                    var tryToAdd = verkstad.AddVehicles(bike);
                                    bike.Getinfo();

                                    if (tryToAdd)                       ///---------------------------------------///
                                    {                                   ///---------SKAPAR EN MOTORCYCKEL---------///
                                        if (bike.MaxSpeed <= 50)        ///---------------------------------------///
                                        {
                                            Console.WriteLine("Mopden är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Motorcyckeln är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Endast mopeder kan lämnas in i den här verkstaden");
                                    }
                                    InputHelper.BackToMenu();
                                    Console.Clear();

                                    break;
                                case 3:
                                    Console.Clear();
                                    var bus = InputHelper.CreateBus();
                                    tryToAdd = verkstad.AddVehicles(bus);
                                    bus.Getinfo();

                                    if (tryToAdd)                          ///---------------------------------------///
                                    {                                      ///------------SKAPAR EN BUSS-------------///
                                        if (bus.MaxPassengers <= 10)       ///---------------------------------------///
                                        {
                                            Console.WriteLine("Minibussen är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bussen är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Endast minibussar kan lämnas in i den här verkstaden");
                                    }
                                    InputHelper.BackToMenu();
                                    Console.Clear();
                                    break;
                                case 4: // skapar en lastbil                ///---------------------------------------///
                                    Console.Clear();                        ///-----------SKAPAR EN LASTBIL-----------///          
                                    var truck = InputHelper.CreateTruck();  ///---------------------------------------///
                                    tryToAdd = verkstad.AddVehicles(truck);
                                    if (tryToAdd)
                                    {
                                        if (truck.MaxLoad <= 2000)
                                        {
                                            Console.WriteLine("Lätt lastbil är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Tung lastbil är tillagd.");
                                            Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                                            "\n ");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Endast lätta lastbilar kan lämnas in i den här verkstaden");
                                    }
                                    InputHelper.BackToMenu();
                                    Console.Clear();
                                    break;
                                case 5:  // Skriver ut info om alla fordon i listan fordon.
                                    Console.Clear();
                                    // Om fordonslistan är null / tom, kommer ett meddelande att visas
                                    if (verkstad.Fordonslista.Count == 0)

                                        Console.WriteLine("Just nu står det inga fordon på verkstaden" +
                                            "\n ");

                                    else
                                        foreach (var fordon in verkstad.Fordonslista)
                                        {
                                            fordon.Getinfo();
                                        }

                                    break;
                                case 6:  // Avbryter programmet
                                    Console.Clear();
                                    program = false;
                                    break;

                                default: // Om man trycker på något annat än 1-4 kommer detta att skrivas ut.
                                    Console.WriteLine("Tyvärr kan vi inte ta emot det fordonet, vänligen välj alternativ 1-4");
                                    break;
                            }
                        }
                        break;


                    case 2:
                        if (verkstad.Fordonslista.Count == 0)
                        {
                            Console.WriteLine("Just nu står det inga fordon på verkstaden" +
                                "\n ");
                            InputHelper.BackToMenu();
                            Console.Clear();
                            break;


                        }
                        else
                        {
                            foreach (var fordon in verkstad.Fordonslista)
                            {
                                fordon.Getinfo();
                            }
                        }
                        Console.WriteLine("Skriv in regummer på det fordon du vill checka ut ifrån verkstaden");
                        verkstad.RemoveVehicles();
                        break;

                    case 3:
                        Console.Clear();
                        if (verkstad.Fordonslista.Count == 0)
                        {
                            Console.WriteLine("Just nu står det inga fordon på verkstaden" +
                                "\n ");
                        }
                        else
                        {
                            foreach (var fordon in verkstad.Fordonslista)
                            {
                                fordon.Getinfo();
                            }
                        }
                        InputHelper.BackToMenu();
                        break;
                    case 4:
                        check = false;
                        break;

                    default:
                        Console.WriteLine("Du måste välja alternativ 1-4");
                        break;
                }
            }
        }
    }
}

