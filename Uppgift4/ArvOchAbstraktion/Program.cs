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
            
            IVerkstad verkstad = new VerkstadV2();
            startProgram(verkstad);
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
                        var car = CreateCar();             ///---------------------------------------///
                        verkstad.AddVehicles(car);
                        car.Getinfo();
                        Console.WriteLine("Tack för ditt förtroende! Välkommer åter!" +
                            "\n ");
                        BackToMenu();
                        Console.Clear();
                        
                        break;
                    case 2:                               
                        Console.Clear();                  
                        var bike = CreateBike();          
                        var tryToAdd = verkstad.AddVehicles(bike);
                        bike.Getinfo();

                        if (tryToAdd)                       ///---------------------------------------///
                        {                                   ///---------SKAPAR EN MOTORCYCKEL---------///
                            if (bike.MaxSpeed <=50)         ///---------------------------------------///
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
                        BackToMenu();
                        Console.Clear();
                        
                        break;
                    case 3:  
                        Console.Clear();
                        var bus = CreateBus();
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
                        BackToMenu();
                        Console.Clear();
                        break;
                    case 4: // skapar en lastbil                ///---------------------------------------///
                        Console.Clear();                        ///-----------SKAPAR EN LASTBIL-----------///          
                        var truck = CreateTruck();              ///---------------------------------------///
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
                        BackToMenu();
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
                        startProgram(verkstad);
                        break;
                    
                    default: // Om man trycker på något annat än 1-4 kommer detta att skrivas ut.
                        Console.WriteLine("Tyvärr kan vi inte ta emot det fordonet, vänligen välj alternativ 1-4");
                        break;
                }

            }

        }

        /// <summary>
        /// Startar main
        /// </summary>
        /// <param name="verkstad"></param>
        public static void startProgram(IVerkstad verkstad)
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
                        check = false;
                        break;

                    case 2:
                        if (verkstad.Fordonslista.Count == 0)

                            Console.WriteLine("Just nu står det inga fordon på verkstaden" +
                                "\n ");

                        else
                            foreach (var fordon in verkstad.Fordonslista)
                            {
                                fordon.Getinfo();
                            }
                        Console.WriteLine("Skriv in regummer på det fordon du vill checka ut ifrån verkstaden");
                        verkstad.RemoveVehicles();
                        break;

                    case 3:
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
                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Du måste välja alternativ 1-4");
                        break;
                }
            }
        }

        /// <summary>
        /// En enkelt metod för att komma tillbaka till div menyer
        /// </summary>
        public static void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att komma till meny");
            Console.ReadLine();
        }
        /// <summary>
        /// En metod för att skriva in namn
        /// </summary>
        /// <param name="whatToAsk"></param>
        /// <returns>Namn</returns>
        public static string SetName(string whatToAsk)
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
        public static int SetNumber(string whatToAsk)

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
        public static Car CreateCar()
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
        public static Bike CreateBike()
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
        public static Bus CreateBus()
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
        public static Truck CreateTruck()
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

