using Bus_Operator;

class Program
{
    static void Main(string[] args)
    {


        BusReservation trip = new BusReservation("Japan", "10:00 AM", 500);

        trip.ShowTripDetails();

        while (true)
        {
            trip.DisplaySeats();


            Console.Write("\n Enter your name :");
            string name = Console.ReadLine();


            Console.Write("\n Enter your seat number :");
            int seatNumber = Convert.ToInt32(Console.ReadLine());


            if (seatNumber < 1 || seatNumber > 20)
            {
                Console.WriteLine("Invalid Seat Number");
                continue;
            }


            trip.BookSeat(name, seatNumber);


            trip.DisplaySeats();


            Console.WriteLine("\nDo you want to book another seat? (y/n)");
            string choice = Console.ReadLine();

            if (choice.ToLower()! == "n")
            {
                break;
            }
        }

        trip.ShowManiFest();
        Console.ReadLine();

    }

}




