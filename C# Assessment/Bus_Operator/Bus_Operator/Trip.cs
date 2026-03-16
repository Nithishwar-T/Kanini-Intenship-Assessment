using System;
using System.Collections.Generic;
using System.Text;

namespace Bus_Operator
{
    internal class Trip
    {
        public string Destination;
        public string DepartureTime;
        public double BaseFare;

        public Trip(string destination, string departureTime, double baseFare)
        {
            Destination = destination;
            DepartureTime = departureTime;
            BaseFare = baseFare;
        }
    }
}

    