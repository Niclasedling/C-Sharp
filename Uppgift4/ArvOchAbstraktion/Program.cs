using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArvOchAbstraktion
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
         
       
    }
    public interface IVerkstad
    {
        public void RemoveFordon()
        {

        }
        public void GetFordon()
        {

        }
    }
    public class Verksad :IVerkstad
    {

    }

}
