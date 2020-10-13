using System;

namespace Uppgift_3
{
    public class Car
    {
        private decimal _carMeter;
        public string _model;

        // Varje bil har en ägare
        public Person Owner { get; set; }
        public string RegistrationNumber { get; set; }
        public int WeightinKilograms { get; set; }
        public DateTime Registred { get; set; }
        public bool ElectricCar { get; set; }

        /// <summary>
        /// Skriver ut info om bilen
        /// </summary>
        public void GetCarInfo()
        {
            Console.WriteLine($"\n Model: {_model}" +
                    $"\n Registeringsnummer: {RegistrationNumber}" +
                    $"\n Vikt:{WeightinKilograms}" +
                    $"\n Regostrerades:{Registred}");
            if (ElectricCar)
            {
                Console.WriteLine(" Detta är en elbil");
            }
        }
        /// <summary>
        /// Skriver ut info om bilen och ägaren
        /// </summary>
        public void GetUserCarInfo()
        {
            // skriver ut ägarens namn också
            Console.WriteLine($"\n Ägare: {Owner.UserName}" +
                    $"\n Model: {_model}" +
                    $"\n Reg Nr: {RegistrationNumber}" +
                    $"\n Vikt:{WeightinKilograms}" +
                    $"\n Regostrerades:{Registred}" +
                    $"\n Bilar har gått {_carMeter.ToString()} mil");
            if (ElectricCar)
            {
                Console.WriteLine(" Detta är en elbil");
            }
        }
        /// <summary>
        /// Räknar om milen bilen åkt och lägger till på de tidigare milen åkt
        /// </summary>
        /// <param name="antalMilbilenkört"></param>
        /// <returns>Milen bilen kört totalt</returns>
        public string GetcarMeter(decimal antalMilbilenkört)
        {
            return _carMeter.ToString();
        }
        /// <summary>
        /// En metod för att sätta milen bilen kört
        /// </summary>
        /// <param name="antalMilbilenkört"></param>
        public void SetcarMeter(decimal antalMilbilenkört)
        {

            if (antalMilbilenkört > 0)
            {
                _carMeter += antalMilbilenkört;
            }

        }
        public Car(string _modelname)
        {
            _model = _modelname;

        }
        public Car()
        {

        }

    }


}


