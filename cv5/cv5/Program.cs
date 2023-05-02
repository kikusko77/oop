<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
=======
﻿using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace cv5
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an instance of Car
            Osobni car = new Osobni(60, Auto.TypPaliva.Benzin, 20);

            // create an instance of Truck
            Nakladni truck = new Nakladni(200, Auto.TypPaliva.Nafta, 80);

            // set the properties of the car and truck
            car.ZapniRadio(true);
            car.nastavRadio(1, 89.1);
            car.preladNaPredvolbu(1);
            car.RetuneByHand(99.9);
            truck.PrepravovanyNaklad = 50;

            // print the current state of the car and truck
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());

            // try to tank more fuel than the tank can hold
            try
            {
                car.Natankuj(Auto.TypPaliva.Benzin, 100);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            // try to use the radio without turning it on
            try
            {
                car.preladNaPredvolbu(1);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
>>>>>>> 84489ebf86e044165eb0b646d0428de7c99a1740
