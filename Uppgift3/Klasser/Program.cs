using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Schema;

namespace Klasser
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Car> Cars = new List<Car>();

            #region Skapar 4st bilar " BWM, Audi, Volkswagen, Tesla

            Car BMW = new Car("BMW Z3");

            BMW.RegistrationNumber = "WTH 99E";
            BMW.WeightinKilograms = 1000;
            BMW.Registred = DateTime.Now;
            BMW.ElectricCar = false;
            Cars.Add(BMW);

            Car Audi = new Car("Audi A4");

            Audi.RegistrationNumber = "BLC 220";
            Audi.WeightinKilograms = 1500;
            Audi.Registred = DateTime.Now;
            Audi.ElectricCar = false;
            Cars.Add(Audi);

            Car Volkswagen = new Car("Volkswagen Tiguan");

            Volkswagen.RegistrationNumber = "CLA 25T";
            Volkswagen.WeightinKilograms = 2000;
            Volkswagen.Registred = DateTime.Now;
            Volkswagen.ElectricCar = false;
            Cars.Add(Volkswagen);

            Car Tesla = new Car("Tesla Model X");

            Tesla.RegistrationNumber = "BLU 99R";
            Tesla.WeightinKilograms = 2250;
            Tesla.Registred = DateTime.Now;
            Tesla.ElectricCar = true;
            Cars.Add(Tesla);
            #endregion


            GetInfoAboutCar(Cars);
            Console.WriteLine("Tryck på valfri kanpp för att forsätta");
            Console.ReadKey();
            Console.Clear();

            static void GetInfoAboutCar(List<Car> Billista)
            {

                foreach (var Car in Billista)
                {
                    Car.GetCarInfo();
                }

            }


            //List<Car> UserCarList = new List<Car>();
            List<Person> UserPersonList = new List<Person>();

            var program = true;
            while (program)
            {
                var isAddingPerson = true;
                do
                {
                    Console.Clear();

                    Person UserPerson = new Person();

                    // Frågar efter namn på ägaren
                    Console.WriteLine("Vad heter du?");
                    UserPerson.UserName = Console.ReadLine();

                    // Frågar efter ålder på ägaren
                    Console.WriteLine($"Hur gammal är du {UserPerson.UserName}?");
                    UserPerson.UserAge = int.Parse(Console.ReadLine());


                    // Lägger till den skapade personen till listan UserPerson
                    UserPersonList.Add(UserPerson);

                    var isAddingCar = true;
                    do
                    {
                        Console.Clear();
                        Car UserCar = new Car();

                        // Användarens data läggs till i bilens owner
                        UserCar.Owner = UserPerson;

                        // Frågar efter model på bilen
                        Console.WriteLine("Vilket märke är din bil?");
                        UserCar._model = Console.ReadLine();

                        // Frågar efter Regnummer på bilen
                        Console.WriteLine($"Vad för reg nr har {UserCar._model}?");
                        UserCar.RegistrationNumber = Console.ReadLine().ToUpper();

                        //Frågar hur mycket bilen väger
                        Console.WriteLine($"Hur mycket väger din {UserCar._model} i kg?");
                        UserCar.WeightinKilograms = int.Parse(Console.ReadLine());

                        // Frågar när bilen skapade
                        Console.WriteLine($"När byggdes din {UserCar._model}? yyyy-mm-dd");
                        UserCar.Registred = DateTime.Parse(Console.ReadLine());

                        // Frågar hur långt bilet gått i mil
                        Console.WriteLine($"Hur långt har din {UserCar._model} gått?");
                        decimal antalMilbilenkört = 0;
                        antalMilbilenkört = Convert.ToDecimal(Console.ReadLine());
                        UserCar.SetcarMeter(antalMilbilenkört);

                        // Frågar om det är en elbil eller inte
                        Console.WriteLine("Är det en elbil? j/n");
                        var answer = Console.ReadLine().ToLower();
                        if (answer == "j")
                        {
                            UserCar.ElectricCar = true;
                        }

                        UserPerson.ListofCars.Add(UserCar);

                        Console.WriteLine("Vill du lägga till fler bilar j/n?");
                        answer = Console.ReadLine();
                        if (answer != "j")
                        {
                            isAddingCar = false;

                            Console.WriteLine("Vill du lägga till fler personer j/n?");
                            answer = Console.ReadLine();
                            if (answer != "j")
                            {
                                isAddingPerson = false;
                                break;
                            }

                            else
                                break;

                        }

                    } while (isAddingCar);

                } while (isAddingPerson);


                var PrintMenu = true;
                while (PrintMenu)
                {
                    Console.Clear();
                    Console.WriteLine("Vad vill du göra nu?" +
                     $"\n[1] SKapa en till användare och bil?" +
                     $"\n[2] Visa info om alla bilar?" +
                     $"\n[4] Avsluta programmet");

                    // En Console ReadLine som kontrollerar att vi skriver in en siffra och att den siffran tillhör "programinput
                    int.TryParse(Console.ReadLine(), out int programinput);

                    switch (programinput)
                    {   // Trycker man "1" kommer whileloopen "PrintMenu" att avbrytas och vi går ut till vår "program" loop
                        case 1:
                            Console.Clear();
                            PrintMenu = false;
                            break;
                        // Trycker man "2" kommer info om bilar att skrivas ut
                        case 2:
                            foreach (var UserPerson in UserPersonList)
                            {
                                Console.Write(UserPerson.UserName);


                                foreach (var car in UserPerson.ListofCars)
                                {
                                    car.GetCarInfo();
                                }

                            }
                            BackToMenu();
                            break;
                        // Trycker man "3" kommer metoden Eat men input-parametern antalben köras.
                        case 3:

                            break;
                        //Trycker man "4" kommer programmet avslutas
                        case 4:
                            Console.Clear();
                            program = false;
                            PrintMenu = false;
                            break;
                        // Trycker man i en siffra över 5 kommer default köras och Console.WriteLine att skrivas ut.
                        default:
                            Console.WriteLine("Du måste välja alternativ 1-4 tycke Enter för att komma tillbaka");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Tyck enter för att fortsätta");
            Console.ReadLine();
        }
    }
}