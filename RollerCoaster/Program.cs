using System;
using System.Threading;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int seats = 6;
            int passengersCount = seats * 5;

            Thread[] threads = new Thread[passengersCount + 1];
            Passenger[] passengers = new Passenger[passengersCount];
            Car car = new Car(seats);

            for(int i=0; i<passengersCount; i++)
            {
                passengers[i] = new Passenger(car);
                threads[i] = new Thread(passengers[i].Run);
                threads[i].Start();
            }
            threads[passengersCount] = new Thread(car.Run);
            threads[passengersCount].Start();
            for (int i = 0; i < passengersCount; i++)
            {
                threads[i].Join();
            }
            if (threads[passengersCount].ThreadState != ThreadState.WaitSleepJoin)
                threads[passengersCount].Interrupt();
            Console.WriteLine("\nAll threads ended!");
            Console.ReadLine();
        }
    }
}
