
using HotelReservationSystem;
using System;

class Program
{
    static void Main(string[] args)
    {

        Hotel hotel = new Hotel();

        hotel.AddRoom(new Rooms(101, RoomType.Single, 500));
        hotel.AddRoom(new Rooms(102, RoomType.Double, 800));
        hotel.AddRoom(new Rooms(201, RoomType.Suite, 1500));
        hotel.AddRoom(new Rooms(202, RoomType.Suite, 2200));
        hotel.AddRoom(new Rooms(104, RoomType.Single, 600));
        hotel.AddRoom(new Rooms(203, RoomType.Double, 900));

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWelcome to the Hotel Reservation System!");
            Console.ResetColor();
            Console.WriteLine("1. Regester Guest");
            Console.WriteLine("2. Make a Reservation");
            Console.WriteLine("3. Confirm Reservation "); 
            Console.WriteLine("4. CheckIn");
            Console.WriteLine("5. CheckOut");
            Console.WriteLine("6. Cancel Reservation");
            Console.WriteLine("7. Change Nightly Rate");
            Console.WriteLine("8. Start Maintance");
            Console.WriteLine("9 End Maintenance");
            Console.WriteLine("10. Show Available Rooms");
            Console.WriteLine("11. Exit");
            try
            {
                    Console.Write("Please select an option: ");
                    int option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter guest id: ");
                        int guestId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter full name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Enter phone number: ");
                        string phone = Console.ReadLine()!;
                        hotel.RegestGuest(new Guests(guestId, name, phone));
                        break;

                    case 2:
                        Console.Write("\nEnter reservation id: ");
                        int resId = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter guest id: ");
                        int gId = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter room number: ");
                        int roomNo = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter check-in date (yyyy-MM-dd): ");
                        DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

                        Console.Write("Enter check-out date (yyyy-MM-dd): ");
                        DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

                        hotel.CreateReservation(resId, hotel.FindGuest(gId), hotel.FindRoom(roomNo), checkIn, checkOut);

                        break;

                    case 3:
                        Console.Write("\nEnter reservation id: ");
                        hotel.ConfirmReservation(int.Parse(Console.ReadLine()!));
                        break;

                    case 4:
                        Console.Write("\nEnter reservation id: ");
                        hotel.CheckIn(int.Parse(Console.ReadLine()!));
                        break;

                    case 5:
                        Console.Write("\nEnter reservation id: ");
                        hotel.CheckOut(int.Parse(Console.ReadLine()!));
                        break;

                    case 6:
                        Console.Write("\nEnter reservation id: ");
                        hotel.CancelReservation(int.Parse(Console.ReadLine()!));
                        break;

                    case 7:
                        Console.Write("\nEnter room number: ");
                        int roomNum = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter new nightly rate: ");
                        decimal rate = decimal.Parse(Console.ReadLine()!);
                        hotel.ChangeNightlyRate(roomNum, rate);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Nightly rate updated.");
                        Console.ResetColor();
                        break;

                    case 8:
                        Console.Write("\nEnter room number: ");
                        hotel.StartMaintenance(int.Parse(Console.ReadLine()!));

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Room is now under maintenance.");
                        Console.ResetColor();

                        break;

                    case 9:
                        Console.Write("\nEnter room number: ");
                        hotel.EndMaintenance(int.Parse(Console.ReadLine()!));

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Maintenance ended.");
                        Console.ResetColor();
                        break;

                    case 10:
                        Console.Write("\nEnter the check-in date (yyyy-MM-dd):");
                        DateTime checkInInput = DateTime.Parse(Console.ReadLine()!);

                        Console.Write("Enter the check-out date (yyyy-MM-dd):");
                        DateTime checkOutInput = DateTime.Parse(Console.ReadLine()!);
                        hotel.ShowAvailableRooms(checkInInput, checkOutInput);

                        break;

                    case 11:
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input format. Please enter the correct data type.");
                Console.ResetColor();
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();

            }

        }

    }
}