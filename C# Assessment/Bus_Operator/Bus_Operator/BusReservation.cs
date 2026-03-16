using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Bus_Operator
{
    internal class BusReservation :Trip
    {
        bool[,] seats = new bool[5, 4];
        Dictionary<int, (string name, double fare, string seatType)> passengers = new Dictionary<int, (string, double, string)>();


        double totalRevenue = 0;

        public BusReservation(string destination, string time, double fare) : base(destination, time, fare)
        {
                
        }

        public void DisplaySeats()
        {
            Console.WriteLine("\nBus Seating Arrangements\n");

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int seatNumber= row * 4 + col + 1;
                    if (seats[row, col])
                    {
                        Console.Write($"{seatNumber,2}[X] ");
                    }
                    else if (col == 0 || col == 3)
                    {
                        Console.Write($"{seatNumber,2}[W] ");
                    }
                    else
                    {
                        Console.Write($"{seatNumber,2}[A] ");
                    }

         
                    if (col == 1)
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }
        }
        public double CalculateFare(int col)
        {
            if (col == 0 || col == 3)
            {
                return BaseFare * 1.15;
            }
            return BaseFare;
        }
        public void BookSeat ( string name,int seatNumber)
        {
            int row= (seatNumber-1) / 4;
            int col = (seatNumber-1) % 4;

            if (seats[row, col])
            {
                Console.WriteLine("Seat already booked...Choose another seat");
                return;
            }
            double fare = CalculateFare(col);
            seats[row, col] = true;

            string seatType = (col == 0 || col == 3) ? "W" : "A";

            passengers.Add(seatNumber,(name,fare,seatType));

            totalRevenue += fare;

            Console.WriteLine($"\nSeat {seatNumber} booked Succefully :)");
            Console.WriteLine($"\nFare {fare}");
            Console.WriteLine($"\nSeatType {seatType}");
            Console.WriteLine("-----------------------------");

        }

        public void ShowManiFest()
        {
            Console.WriteLine("\n Passenger Manifest\n" );

            foreach(var passenger in passengers)
            {
                Console.WriteLine($"Seat {passenger.Key}[{passenger.Value.seatType}] : {passenger.Value.name} | Fare : {passenger.Value.fare}" );
            }
            Console.WriteLine($"\n Total Revenue:{totalRevenue} ");
            
        }

        public void ShowTripDetails()
        {
            Console.WriteLine("BUS TRIP DETAILS");
            Console.WriteLine($"Destination    : {Destination}");
            Console.WriteLine($"Departure Time : {DepartureTime}");
            Console.WriteLine($"Base Fare      : {BaseFare}");
           
        }

    }
}
