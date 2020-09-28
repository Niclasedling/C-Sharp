using System;
using System.Dynamic;

namespace ArvOchAbstraktion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Fordon
    {
        string ModelName { get; set; }
        string RegistrationNumber { get; set; }
        decimal OdoMeter { get; set; }
        DateTime Registrated { get; set; }
    }
    public class Car : Fordon
    {
        bool TowBar { get; set; }
    }
    public class Truck : Fordon
    {
        int MaxWeightinkilo { get; set; }
    }
    public class MotorBike : Fordon
    {
        int MaxSpeed { get; set; }
    }
    publicc class Buss : Fordon
    {
        int MaxPassengers { get; set; }
    }

}
