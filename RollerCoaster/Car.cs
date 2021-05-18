using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RollerCoaster
{
    public class Car
    {
        private int _seats;
        private int _passengers;

        private Semaphore mutex1;
        private Semaphore mutex2;
        private Semaphore allAboard;
        private Semaphore allAway;

        public Semaphore BoardQueue { get; set; }
        public Semaphore UnboardQueue { get; set; }

        public Car(int seats)
        {
            _seats = seats;
            _passengers = 0;

            mutex1 = new Semaphore(1, seats);
            mutex2 = new Semaphore(1, seats);
            allAboard = new Semaphore(0, seats);
            allAway = new Semaphore(0, seats);

            BoardQueue = new Semaphore(0, seats);
            UnboardQueue = new Semaphore(0, seats);
        }

		public void Board()
		{
			mutex1.WaitOne();
			Console.Write("x");

			_passengers++;
			if (_passengers == _seats)
				allAboard.Release();

			mutex1.Release();
		}

		public void Unboard()
		{
			mutex2.WaitOne();
			Console.Write("x");

			_passengers--;
			if (_passengers == 0)
				allAway.Release();

			mutex2.Release();
		}

        public void Run()
        {
			Console.WriteLine("The roller coaster is starting! Number of seats: {0}", _seats);
			while (true)
			{
				Console.Write("\nBoarding: ");
				BoardQueue.Release(_seats);
				allAboard.WaitOne();

				Console.Write("\nUnboarding: ");
				UnboardQueue.Release(_seats);
				allAway.WaitOne();

				Console.WriteLine("\nThere are {0} passangers left.", _passengers);
			}
		}
	}
}
