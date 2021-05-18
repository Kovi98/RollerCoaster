using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster
{
    public class Passenger
    {
        private Car _car;

        public Passenger(Car car)
        {
            _car = car;
        }

        public void Run()
        {
            _car.BoardQueue.WaitOne();
            _car.Board();

            _car.UnboardQueue.WaitOne();
            _car.Unboard();
        }
    }
}
