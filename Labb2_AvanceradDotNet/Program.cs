namespace Labb2_AvanceradDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int racingDistance = 2;
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
                        Console.WriteLine($"{car1.Name} has driven {car1.DistanceDriven} km and current speed is {car1.Speed * 120} km/h");
                        Console.WriteLine($"{car2.Name} has driven {car2.DistanceDriven} km and current speed is {car2.Speed * 120} km/h");
                        Console.WriteLine($"{car3.Name} has driven {car3.DistanceDriven} km and current speed is {car3.Speed * 120} km/h");
                    }
                }
            });
            checkStatus.IsBackground = true;
            checkStatus.Start();

            Console.WriteLine(Thread.CurrentThread.Name + " " + Thread.CurrentThread.ManagedThreadId);
            th1.Join();
            th2.Join();
            th3.Join();

            
        }
    }
}
