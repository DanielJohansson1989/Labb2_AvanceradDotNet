namespace Labb2_AvanceradDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int racingDistance = 10;
            Car car1 = new Car("Volvo");
            Car car2 = new Car("Ferrari");
            Car car3 = new Car("Toyota");
            
            Thread th1 = new Thread(() => 
            {
                car1.StartRacing(racingDistance);
            });
            
            Thread th2 = new Thread(() => 
            {
                car2.StartRacing(racingDistance);
            });
            
            Thread th3 = new Thread(() => 
            {
                car3.StartRacing(racingDistance);
            });

            Console.WriteLine("[Press enter to get updates in the race]");

            th1.Start();
            th2.Start();
            th3.Start();

            Thread checkStatus = new Thread(() => 
            { 
                while (true)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine($"{car1.Name} has driven {Math.Round(car1.DistanceDriven, 1)} km and current speed is {Math.Round(car1.Speed * 120, 1)} km/h");
                        Console.WriteLine($"{car2.Name} has driven {Math.Round(car2.DistanceDriven, 1)} km and current speed is {Math.Round(car2.Speed * 120, 1)} km/h");
                        Console.WriteLine($"{car3.Name} has driven {Math.Round(car3.DistanceDriven, 1)} km and current speed is {Math.Round(car3.Speed * 120, 1)} km/h");
                    }
                }
            });
            checkStatus.IsBackground = true;
            checkStatus.Start();

            th1.Join();
            th2.Join();
            th3.Join();
            if ((car1.FinishTime < car2.FinishTime) && (car1.FinishTime < car3.FinishTime)) { Console.WriteLine($"{car1.Name} is the winner"); }
            if ((car2.FinishTime < car1.FinishTime) && (car2.FinishTime < car3.FinishTime)) { Console.WriteLine($"{car2.Name} is the winner"); }
            if ((car3.FinishTime < car2.FinishTime) && (car3.FinishTime < car1.FinishTime)) { Console.WriteLine($"{car3.Name} is the winner"); }
               
        }
    }
}
