using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public abstract class Fordon
    {
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal OdoMeter { get; set; }
        public DateTime Registrated { get; set; }

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
        
        public static DateTime Reg(string whatToAsk)
        {
            string Date = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(Date, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Datumet stämmer inte, försök igen");
                Date = Console.ReadLine();
            }

            return DateTime;
        }



    }
}
