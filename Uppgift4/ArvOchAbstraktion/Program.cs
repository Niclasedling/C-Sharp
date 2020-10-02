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

                int.TryParse(Console.ReadLine(), out int numb);

                switch (numb)
                {
                    case 1:
                        Car Car = new Car();
                        List<Car> Billista = new List<Car>();
                        //MakeCar();
                        //// Skapar en ny bil!
                        Car.ModelName = SetName("Vilket märke har din bil?");
                        Car.RegistrationNumber = SetName("Skriv in bilens Registreringsnummer").ToUpper();
                        Car.OdoMeter = SetNumber($"Hur långt har {Car.ModelName} gått i mil?");
                        Console.WriteLine($"När byggdes {Car.ModelName} ? yyyy-mm-dd");
                        Car.Registrated = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine($"Har din {Car.ModelName} en dragkrog?");
                        string answer = Console.ReadLine();
                        if (answer == "j")
                        {
                            Car.HasTowbar = true;
                        }
                        Console.WriteLine("Lägger till bilen i Fordonslistan");
                        // Lägger till den skapade bilen i Listan
                        Billista.Add(Car);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        // Skapar en ny motorcykel!
                        Bike Bike = new Bike();
                        List<Bike> Bikelista = new List<Bike>();
                        //MakeBike();
                        Bike.ModelName = SetName("Vilket märke har din motorcykel?");
                        Bike.RegistrationNumber = SetName("Skriv in motorcycklens registretingsnummer").ToUpper();
                        Bike.OdoMeter = SetNumber($"Hur långt har {Bike.ModelName} gått i mil?");
                        Console.WriteLine($"När byggdes {Bike.ModelName}? yyyy-mm-dd");
                        Bike.Registrated = DateTime.Parse(Console.ReadLine());
                        Bike.MaxSpeed = SetNumber($"Vad är {Bike.ModelName} maxhastiget km/h?");
                        Console.WriteLine("Lägger till motorcykeln i Fordonslistan");
                        Bikelista.Add(Bike);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        // Skapar en ny buss!
                        Buss Buss = new Buss();
                        List<Buss> Busslista = new List<Buss>();
                        //MakeBus();
                        Buss.ModelName = SetName("Vilket märke har din buss?");
                        Buss.RegistrationNumber = SetName("Skriv in bussens registretingsnummer").ToUpper();
                        Buss.OdoMeter = SetNumber($"Hur långt har {Buss.ModelName} gått i mil?");
                        Console.WriteLine($"När byggdes {Buss.ModelName}? yyyy-mm-dd");
                        Buss.Registrated = DateTime.Parse(Console.ReadLine());
                        Buss.MaxPassengers = SetNumber("Totalt antal passagerare som får vara på bussen?");
                        Console.WriteLine("Lägger till bussen i fordonslistan");
                        Busslista.Add(Buss);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        // Skapar en Lastbil
                        Truck Truck = new Truck();
                        List<Truck> Trucklista = new List<Truck>();
                        //MakeTruck();
                        Truck.ModelName = SetName("Vilket märke har Lastbilen");
                        Truck.RegistrationNumber = SetName("Skriv in lastbilens registretingsnummer").ToUpper();
                        Truck.OdoMeter = SetNumber($"Hur långt har {Truck.ModelName} gått i mil?");
                        Console.WriteLine($"När byggdes {Truck.ModelName}? yyyy-mm-dd");
                        Truck.Registrated = DateTime.Parse(Console.ReadLine());
                        Truck.MaxLoad = SetNumber($"Vad är {Truck.ModelName} max lastkapacitet i kilo?");
                        Console.WriteLine("Lägger till lastbilen i Fordonslistan");
                        Trucklista.Add(Truck);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:

                        foreach (var Bil in Billista)
                        {
                            Console.WriteLine("Bilar:")

                            Car.Carinfo();

                            foreach (var Motobike in Bikelista)
                            {
                                Console.WriteLine("Motorcyklar:");
                                Bike.Bikeinfo();

                                foreach (var Bus in Busslista)
                                {
                                    Console.WriteLine("Bussar:");
                                    Buss.Bussinfo();

                                    foreach (var Lastbil in Trucklista)
                                    {
                                        Console.WriteLine("Lastbilar:");
                                        Truck.Truckinfo();
                                    }
                                }
                            }
                        }
                        break;
                    case 6:
                        program = false;
                        break;

                    default:
                        Console.WriteLine("Du måste välja mellan altevertiv 1-4");
                        break;
                }

            }
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
        //public static void MakeCar()
        //{
        //    Car Car = new Car();

        //    Car.ModelName = SetName("Vilket märke har din bil?");
        //    Car.RegistrationNumber = SetName("Skriv in bilens Registreringsnummer").ToUpper();
        //    Car.OdoMeter = SetNumber($"Hur långt har {Car.ModelName} gått i mil?");
        //    Console.WriteLine($"När byggdes {Car.ModelName} ? yyyy-mm-dd");
        //    Car.Registrated = DateTime.Parse(Console.ReadLine());
        //    Console.WriteLine($"Har din {Car.ModelName} en dragkrog?");
        //    string answer = Console.ReadLine();
        //    if (answer == "j")
        //    {
        //        Car.HasTowbar = true;
        //    }
        //    Console.WriteLine("Lägger till bilen i Fordonslistan");
        //    // Lägger till den skapade bilen i Listan
        //    //Billista.Add(Car);
        //    Console.ReadKey();
        //    Console.Clear();
        //}
        //public static void MakeBike()
        //{
        //    Bike Bike = new Bike();

        //    Bike.ModelName = SetName("Vilket märke har din motorcykel?");
        //    Bike.RegistrationNumber = SetName("Skriv in motorcycklens registretingsnummer").ToUpper();
        //    Bike.OdoMeter = SetNumber($"Hur långt har {Bike.ModelName} gått i mil?");
        //    Console.WriteLine($"När byggdes {Bike.ModelName}? yyyy-mm-dd");
        //    Bike.Registrated = DateTime.Parse(Console.ReadLine());
        //    Bike.MaxSpeed = SetNumber($"Vad är {Bike.ModelName} maxhastiget km/h?");
        //    Console.WriteLine("Lägger till motorcykeln i Fordonslistan");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
        //public static void MakeBus()
        //{
        //    Buss Buss = new Buss();

        //    Buss.ModelName = SetName("Vilket märke har din buss?");
        //    Buss.RegistrationNumber = SetName("Skriv in bussens registretingsnummer").ToUpper();
        //    Buss.OdoMeter = SetNumber($"Hur långt har {Buss.ModelName} gått i mil?");
        //    Console.WriteLine($"När byggdes {Buss.ModelName}? yyyy-mm-dd");
        //    Buss.Registrated = DateTime.Parse(Console.ReadLine());
        //    Buss.MaxPassengers = SetNumber("Totalt antal passagerare som får vara på bussen?");
        //    Console.WriteLine("Lägger till bussen i fordonslistan");
        //    //Busslista.Add(Buss);
        //    Console.ReadKey();
        //    Console.Clear();
        //}
        //public static void MakeTruck()
        //{
        //    Truck Truck = new Truck();

        //    Truck.ModelName = SetName("Vilket märke har Lastbilen");
        //    Truck.RegistrationNumber = SetName("Skriv in lastbilens registretingsnummer").ToUpper();
        //    Truck.OdoMeter = SetNumber($"Hur långt har {Truck.ModelName} gått i mil?");
        //    Console.WriteLine($"När byggdes {Truck.ModelName}? yyyy-mm-dd");
        //    Truck.Registrated = DateTime.Parse(Console.ReadLine());
        //    Truck.MaxLoad = SetNumber($"Vad är {Truck.ModelName} max lastkapacitet i kilo?");
        //    Console.WriteLine("Lägger till lastbilen i Fordonslistan");
        //    //Trucklista.Add(Truck);
        //    Console.ReadKey();
        //    Console.Clear();
        //}



    }
    


}

