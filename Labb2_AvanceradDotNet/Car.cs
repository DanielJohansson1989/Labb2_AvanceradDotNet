using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_AvanceradDotNet
{
    internal class Car
    {
        public string Name { get; private set; }
        public double DistanceDriven { get; private set; }
        public double Speed { get; private set; }
        public TimeSpan FinishTime { get; private set; }
        public Car(string name)
        {
            Name = name;
            DistanceDriven = 0;
            Speed = 1; //km per every 30 sek.
        }

        public void StartRacing(int distance)
        {
            Console.WriteLine($"{Name} has started the race...");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            do
            {
                Thread.Sleep(50000);
                DistanceDriven += Speed;
                Console.WriteLine($"Name: {Name} DistanceDriven: {DistanceDriven} Speed: {Speed}");
                this.GetRandomProblem();
            } while (DistanceDriven < distance);

            Console.WriteLine($"{Name} has finnished!!!");
            sw.Stop();
            FinishTime = sw.Elapsed;
            Console.WriteLine($"Finish time: { FinishTime}");
            
        }

        private void GetRandomProblem()
        {
            Random random = new Random();
            int randomNumber = random.Next(0,50);

            switch (randomNumber)
            {
                case 0:
                    FuelUp();
                    break;
                case 1:
                case 2:
                    ChangeTires();
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    WashCar();
                    break;
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    ReduceSpeed();
                    break;
                default:
                    break;
            }

        }

        private void FuelUp()
        {
            Console.WriteLine($"{Name} is running out of gas!!! Needs to fuel up, stops for 30 sek.");
            Thread.Sleep(30000);
        }

        private void ChangeTires()
        {
            Console.WriteLine($"A flat tire!!! {Name} needs to change tires, stops for 20 sek");
            Thread.Sleep(20000);
        }

        private void WashCar()
        {
            Console.WriteLine($"A bird crashed into the windshield! {Name} needs to clean windshield, stops for 10 sek");
            Thread.Sleep(10000);
        }

        private void ReduceSpeed() 
        {
            Console.WriteLine($"Engine malfunctioning!!! {Name}'s speed drops with 1km/h");
            Speed -= 0.03;
        }
    }
}
