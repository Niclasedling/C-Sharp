using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Schema;

namespace Uppgift_3
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
            List<Person> UserPersonList = new List<Person>();

            var program = true;
            while (program)
            {
                var isAddingPerson = true;
                do
                {
                    Console.Clear();
                    // Skapar en ny person "UserPerson"
                    Person UserPerson = new Person();

                    // Frågar efter namn på ägaren
                    UserPerson.UserName = SetName("Vad heter du?");

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
                        UserCar._model = SetName("Vilket märke är din bil?");

                        // Frågar efter Regnummer på bilen
                        UserCar.RegistrationNumber = SetName($"Skriv in din {UserCar._model}s registreringsnummer").ToUpper();

                        //Frågar hur mycket bilen väger
                        UserCar.WeightinKilograms = SetNumber($"Hur mycket väger din {UserCar._model} i kilo?");


                        UserCar.Registred = DateTime.Now;

                        // Frågar hur långt bilet gått i mil
                        Console.WriteLine($"Hur många mil har {UserCar._model} kört?");
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
                     $"\n[1] Skapa en till användare och bil?" +
                     $"\n[2] Visa information om nuvarande personer och deras bilar?" +
                     $"\n[3] Avsluta programmet");

                    // En Console ReadLine som kontrollerar att vi skriver in en siffra och att den siffran tillhör "programinput
                    int.TryParse(Console.ReadLine(), out int programinput);
                    Console.Clear();
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
                                Console.Write($"{UserPerson.UserName}:");


                                foreach (var car in UserPerson.ListofCars)
                                {
                                    car.GetCarInfo();
                                }

                            }
                            
                            BackToMenu2();
                            break;
                        //Trycker man "3" kommer programmet avslutas
                        case 3:
                            Console.Clear();
                            program = false;
                            PrintMenu = false;
                            break;
                        // Trycker man i en siffra över 5 kommer default köras och Console.WriteLine att skrivas ut.
                        default:
                            Console.WriteLine("Du måste välja alternativ 1-4 tryck Enter för att komma tillbaka");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        public static void BackToMenu2()
        {
            Console.WriteLine("Tryck enter för att gå tillbaka till menyn");
            Console.ReadLine();
        }
        /// <summary>
        /// En Metod för att skriva ut Namn
        /// </summary>
        /// <param name="whatToAsk"></param>
        /// <returns>Ett namn</returns>
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
        /// <summary>
        /// En metod för att skriva ut siffror
        /// </summary>
        /// <param name="whatToAsk"></param>
        /// <returns>Ett tal</returns>
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

    }
}


