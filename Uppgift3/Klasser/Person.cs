using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    public class Person
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public List<Car> ListofCars { get; set; }
        public void GetPersonInfo()
        {
            Console.WriteLine($"\n Ägare: {UserName}" +
                $"\n Ålder: {UserAge}");
        }

        public Person()
        {
            ListofCars = new List<Car>();
        }
    }
}
