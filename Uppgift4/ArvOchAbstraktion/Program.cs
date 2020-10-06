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

            IVerkstad verkstad = new Verkstad();
            startProgram(verkstad);

        }
        /// <summary>
        /// Startar main
        /// </summary>
        /// <param name="verkstad"></param>
        private static void startProgram(IVerkstad verkstad)
        {
            var check = true;
            while (check)
            {
                Console.WriteLine("----Välkommen till hasses fordonsverkstad----" +
                    "\n " +
                    "\t Vad vill vår kära kund göra?" +
                    "\n " +
                    "\n [1] Lämna till ett fordon" +
                    "\n [2] Hämta ett fordon" +
                    "\n [3] Avsluta vistelsen" +
                    "\n [4] Titta på alla fordon i verkstaden");

                int.TryParse(Console.ReadLine(), out int addVehicles);
                switch (addVehicles)
                {
                    case 1:
                        CreateVehicles(verkstad);
                        break;

                    case 2:
                        Console.WriteLine("Skriv in regummer på det fordon du vill checka ut ifrån verkstaden");
                        verkstad.RemoveVehicles();
                        break;

                    case 3:
                        
                        check = false;
                        break;
                    case 4:
                        Console.Clear();

                        if (verkstad.Fordonslista.Count == 0)

                            Console.WriteLine("Just nu står det inga fordon på verkstaden" +
                                "\n ");

                        else
                            foreach (var fordon in verkstad.Fordonslista)
                            {
                                fordon.Getinfo();
                            }

                        BackToMenu();
                        break;

                    default:
                        Console.WriteLine("Du måste välja alternativ 1-4");
                        break;
                }
            }
        }

        /// <summary>
        /// Skapar ett fordon och lägger till i Listan Fordon
        /// </summary>
        /// <param name="verkstad"></param>
        private static void CreateVehicles(IVerkstad verkstad)
        {
            Console.Clear();
            var program = true;
            while (program)
            {
                Console.WriteLine("Vilket typ av fordon vill du lämna in??" +
                        "\n [1] En bil?" +
                        "\n [2] En motorcyckel?" +
                        "\n [3] En buss" +
                        "\n [4] En lastbil" +
                        "\n [5] Visa alla fordon i verkstaden" +
                        "\n [6] Tillbaka till menyn");

                int.TryParse(Console.ReadLine(), out int creatVehicles);

                switch (creatVehicles)
                {
                    case 1: // SKapar en ny bil!
                        Console.Clear();
                        var car = AddCar();
                        verkstad.AddVehicles(car);
                        Console.Clear();
                        car.Getinfo();
                        Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                            "\n ");
                        BackToMenu();
                        Console.Clear();
                        program = false;

                        break;
                    case 2: // Skapar en ny motorcykel!
                        Console.Clear();
                        var bike = AddBike();
                        verkstad.AddVehicles(bike);
                        Console.Clear();
                        bike.Getinfo();
                        Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                            "\n ");
                        BackToMenu();
                        Console.Clear();
                        program = false;

                        break;
                    case 3:  // Skapar en ny buss!
                        Console.Clear();
                        var bus = AddBus();
                        verkstad.AddVehicles(bus);
                        Console.Clear();
                        bus.Getinfo();
                        Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                            "\n ");
                        BackToMenu();
                        Console.Clear();
                        program = false;

                        break;
                    case 4: // skapar en lastbil
                        Console.Clear();
                        var truck = AddTruck();
                        verkstad.AddVehicles(truck);
                        Console.Clear();
                        truck.Getinfo();
                        Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                            "\n ");
                        BackToMenu();
                        Console.Clear();
                        program = false;

                        break;
                    case 5:  // Skriver ut info om alla fordon i listan fordon.
                        Console.Clear();
                        foreach (var fordon in verkstad.Fordonslista)
                        {
                            fordon.Getinfo();
                        }
                        program = false;
                        break;
                    case 6:  // Avbryter programmet
                        Console.Clear();
                        program = false;
                        break;

                    default: // Om man trycker på något annat än 1-4 kommer detta att skrivas ut.
                        Console.WriteLine("Du måste välja mellan altevertiv 1-4");
                        break;
                }

            }
        }
        /// <summary>
        /// En enkelt metod för att komma tillbaka till div menyer
        /// </summary>
        private static void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att komma till meny");
            Console.ReadLine();
        }
        /// <summary>
        /// En metod för att skriva in namn
        /// </summary>
        /// <param name="whatToAsk"></param>
        /// <returns>Namn</returns>
        private static string SetName(string whatToAsk)
        {
            string Name;
            var check = true;
            do
            {
                Console.Write(whatToAsk);
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
        /// <summary>
        /// En metod för att sätta nummer, som ålder, vikt, m.m
        /// </summary>
        /// <param name="whatToAsk"></param>
        /// <returns>Ett nummer</returns>
        private static int SetNumber(string whatToAsk)

        {
            int numb = 0;
            var isInputting = true;
            do
            {
                Console.Write(whatToAsk);

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
        /// <summary>
        /// Skapar en bil
        /// </summary>
        /// <returns>En bil</returns>
        private static Car AddCar()
        {
            Car car = new Car();

            car.ModelName = SetName("Vilket märke har din bil? ");
            car.RegistrationNumber = SetName("Skriv in bilens Registreringsnummer: ").ToUpper();
            car.OdoMeter = SetNumber($"Hur långt har {car.ModelName} gått i mil? ");
            Console.Write($"Har din {car.ModelName} en dragkrog? j/n: ");
            var answer = Console.ReadLine().ToLower();
            if (answer == "j")
            
                car.HasTowbar = true;

            return car;
        }
        /// <summary>
        /// Skapar en motorcykel
        /// </summary>
        /// <returns>En motorcykel</returns>
        private static Bike AddBike()
        {
            Bike bike = new Bike();

            bike.ModelName = SetName("Vilket märke har din motorcykel? ");
            bike.RegistrationNumber = SetName("Skriv in motorcycklens registretingsnummer: ").ToUpper();
            bike.OdoMeter = SetNumber($"Hur långt har {bike.ModelName} gått i mil? ");
            bike.MaxSpeed = SetNumber($"Vad är {bike.ModelName} maxhastiget km/h? ");

            return bike;
        }
        /// <summary>
        /// Skapar en bus
        /// </summary>
        /// <returns>En buss</returns>
        private static Bus AddBus()
        {
            Bus bus = new Bus();

            bus.ModelName = SetName("Vilket märke har din buss? ");
            bus.RegistrationNumber = SetName("Skriv in bussens registretingsnummer: ").ToUpper();
            bus.OdoMeter = SetNumber($"Hur långt har {bus.ModelName} gått i mil? ");
            bus.MaxPassengers = SetNumber("Totalt antal passagerare som får vara på bussen? ");
            
            return bus;
        }
        /// <summary>
        /// Skapar en lastbil
        /// </summary>
        /// <returns>En lastbil</returns>
        private static Truck AddTruck()
        {
            Truck truck = new Truck();

            truck.ModelName = SetName("Vilket märke har Lastbilen ");
            truck.RegistrationNumber = SetName("Skriv in lastbilens registretingsnummer: ").ToUpper();
            truck.OdoMeter = SetNumber($"Hur långt har {truck.ModelName} gått i mil? ");
            truck.MaxLoad = SetNumber($"Vad är {truck.ModelName} max lastkapacitet i kilo? ");
            
            return truck;
        }
    }

    


}

