using System;
using System.Dynamic;
using System.ComponentModel;
using Klasser;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;



namespace Klasser
{
    public class InputHelper
    {
        public List<Fordon> Fordonslista { get; set; }

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
            var check = true;
            do
            {
                Console.Write(whatToAsk);

                if (!int.TryParse(Console.ReadLine(), out numb))
                {
                    Console.WriteLine("Du måste skriva in ett heltal.");
                }

                else
                {
                    check = false;
                }
            } while (check);

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
        /// <summary>
        /// En metod som ställer vissa krav för att fordon ska läggas till i listan, gäller VerkstadV2
        /// </summary>
        /// <param name="fordon"></param>
        /// <returns></returns>
        public static bool TrytoAddVehicles(Fordon fordon)
        {
            var isOktoAdd = false;
            if (fordon is Bike)
            {
                var bike = fordon as Bike;
                if (bike.MaxSpeed <= 50)
                {
                    isOktoAdd = true;
                }

            }
            if (fordon is Bus)
            {
                var bus = fordon as Bus;
                if (bus.MaxPassengers <= 8)
                {
                    isOktoAdd = true;
                }

            }
            if (fordon is Truck)
            {
                var truck = fordon as Truck;
                if (truck.MaxLoad <= 2500)
                {
                    isOktoAdd = true;
                }

            }
            if (fordon is Car)
            {
                var car = fordon as Car;
                isOktoAdd = true;
            }

            return isOktoAdd;

        }
        

        /// <summary>
        /// Lägger till ett fordon till verkstaden
        /// </summary>
        /// <param name="fordon"></param>
        public bool AddVehicles(Fordon fordon)
        {
            Fordonslista.Add(fordon);
            return true;
        }
        /// <summary>
        /// Tar bort ett fordon med hjälp av att söka på ett regNr
        /// </summary>
        public void RemoveVehicles()
        {

            var regnummerTomatch = Console.ReadLine().ToUpper();
            Fordon bilAttTabort = null;

            foreach (var fordon in Fordonslista)
            {
                if (regnummerTomatch == fordon.RegistrationNumber)
                {
                    bilAttTabort = fordon;
                }
            }
            if (bilAttTabort != null)
            {
                Fordonslista.Remove(bilAttTabort);
                Console.Clear();
                Console.WriteLine($"Fordon med regNr {regnummerTomatch} har checkat ur verkstaden");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ett fordon med regNr {regnummerTomatch} hittades inte i verkstaden.");
                Console.ReadKey();
            }
        }
    }
}
