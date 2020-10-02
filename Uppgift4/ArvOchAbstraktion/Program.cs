﻿using System;
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
            Verkstad verkstad = new Verkstad();

            var program = true;
            while (program)
            {
                Console.WriteLine("Vad vill du göra för något?" +
                        "\n [1] Skapa en bil" +
                        "\n [2] Skapa en Motorcyckel" +
                        "\n [3] Skapa en Buss" +
                        "\n [4] Skapa en Lastbil" +
                        "\n [5] Visa alla fordon" +
                        "\n [6] Avsluta programmet");

                int.TryParse(Console.ReadLine(), out int skapafordon);

                switch (skapafordon)
                {
                    case 1: // SKapar en ny bil!
                        Console.Clear();
                        var car = MakeCar();
                        verkstad.Fordonslista.Add(car);
                        Console.Clear();
                        BackToMenu();

                        break;
                    case 2: // Skapar en ny motorcykel!
                        Console.Clear();
                        var bike = MakeBike();
                        verkstad.Fordonslista.Add(bike);
                        BackToMenu();

                        break;
                    case 3:  // Skapar en ny buss!
                        Console.Clear();
                        var bus = MakeBus();
                        verkstad.Fordonslista.Add(bus);
                        BackToMenu();
                        
                        break;
                    case 4: // skapar en lastbil
                        Console.Clear();
                        var truck = MakeTruck();
                        verkstad.Fordonslista.Add(truck);
                        BackToMenu();

                        break;
                    case 5:  // Skriver ut info om alla fordon i listan fordon.
                        Console.Clear();
                        foreach (var fordon in verkstad.Fordonslista)
                        {
                            fordon.Getinfo();
                        }
                        BackToMenu();
                        break;
                    case 6:  // Avbryter programmet
                        program = false;
                        break;

                    default: // Om man trycker på något annat än 1-4 kommer detta att skrivas ut.
                        Console.WriteLine("Du måste välja mellan altevertiv 1-4");
                        break;
                }

            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        public class Verksad : IVerkstad
        {


        }


        public static string SetName(string whatToAsk)
        {
            string Name;
            var check = true;
            do
            {
                Console.WriteLine(whatToAsk);
                Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("Du måste mata in något.");
                }

                else
                {
                    check = false;
                }
            } while (check);

            return Name;
        }
        public static int SetNumber(string whatToAsk)

        {
            int numb = 0;
            var isInputting = true;
            do
            {
                Console.WriteLine(whatToAsk);

                if (!int.TryParse(Console.ReadLine(), out numb))
                {
                    Console.WriteLine("Du måste skriva in ett heltal.");
                }

                else
                {
                    isInputting = false;
                }
            } while (isInputting);

            return numb;
        }
        public static Car MakeCar()
        {
            Car car = new Car();

            car.ModelName = SetName("Vilket märke har din bil?");
            car.RegistrationNumber = SetName("Skriv in bilens Registreringsnummer").ToUpper();
            car.OdoMeter = SetNumber($"Hur långt har {car.ModelName} gått i mil?");
            Console.WriteLine($"När byggdes {car.ModelName} ? yyyy-mm-dd");
            car.Registrated = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"Har din {car.ModelName} en dragkrog? j/n");
            string answer = Console.ReadLine();
            if (answer == "j")
            {
                car.HasTowbar = true;

               
            }
            Console.WriteLine("Lägger till bilen i Fordonslistan");
            return car;
           
            
        }
        public static Bike MakeBike()
        {
            Bike bike = new Bike();

            bike.ModelName = SetName("Vilket märke har din motorcykel?");
            bike.RegistrationNumber = SetName("Skriv in motorcycklens registretingsnummer").ToUpper();
            bike.OdoMeter = SetNumber($"Hur långt har {bike.ModelName} gått i mil?");
            Console.WriteLine($"När byggdes {bike.ModelName}? yyyy-mm-dd");
            bike.Registrated = DateTime.Parse(Console.ReadLine());
            bike.MaxSpeed = SetNumber($"Vad är {bike.ModelName} maxhastiget km/h?");
            Console.WriteLine("Lägger till motorcykeln i Fordonslistan");

            return bike;
        }
        public static Bus MakeBus()
        {
            Bus bus = new Bus();

            bus.ModelName = SetName("Vilket märke har din buss?");
            bus.RegistrationNumber = SetName("Skriv in bussens registretingsnummer").ToUpper();
            bus.OdoMeter = SetNumber($"Hur långt har {bus.ModelName} gått i mil?");
            Console.WriteLine($"När byggdes {bus.ModelName}? yyyy-mm-dd");
            bus.Registrated = DateTime.Parse(Console.ReadLine());
            bus.MaxPassengers = SetNumber("Totalt antal passagerare som får vara på bussen?");
            Console.WriteLine("Lägger till bussen i fordonslistan");

            return bus;
        }
        public static Truck MakeTruck()
        {
            Truck truck = new Truck();

            truck.ModelName = SetName("Vilket märke har Lastbilen");
            truck.RegistrationNumber = SetName("Skriv in lastbilens registretingsnummer").ToUpper();
            truck.OdoMeter = SetNumber($"Hur långt har {truck.ModelName} gått i mil?");
            Console.WriteLine($"När byggdes {truck.ModelName}? yyyy-mm-dd");
            truck.Registrated = DateTime.Parse(Console.ReadLine());
            truck.MaxLoad = SetNumber($"Vad är {truck.ModelName} max lastkapacitet i kilo?");
            Console.WriteLine("Lägger till lastbilen i Fordonslistan");

            return truck;

        }



    }
    


}

