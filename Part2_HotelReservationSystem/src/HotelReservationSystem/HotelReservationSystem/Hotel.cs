using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        private readonly List<Rooms> _rooms = new List<Rooms>();
        private readonly List<Guests> _guests = new List<Guests>();
        private readonly List<Reservation> _reservations = new List<Reservation>();

        public Hotel()
        {
            

        }
        public void AddRoom(Rooms room)
        {
            if (room == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Room can't be null ");
                Console.ResetColor();
            }
            _rooms.Add(room);
            
        }
        public Rooms FindRoom(int roomNumber)
        {
            foreach (var room in _rooms)
            {
                if (room.RoomNumber == roomNumber)
                    return room;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            throw new InvalidOperationException("Room not found.");
            Console.ResetColor();
        }
        public void ChangeNightlyRate(int roomNumber, decimal newRate)
        {
            FindRoom(roomNumber).ChangeNightlyRate(newRate);

        }

        public void StartMaintenance(int roomNumber)
        {
            FindRoom(roomNumber).StartMaintenance();
        }

        public void EndMaintenance(int roomNumber)
        {
            FindRoom(roomNumber).EndMaintenance();
        }

        public Guests FindGuest(int id)
        {
            foreach (var guest in _guests)
            {
                if (guest.Id == id)
                    return guest;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            throw new InvalidOperationException("Guest not found.");
            Console.ResetColor();

        }
        
        public void RegestGuest(Guests guest)
        {
            if (guest == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Guest can't be null ");
                Console.ResetColor();
            }
            foreach (var g in _guests)
            {
                if (g.Id == guest.Id)
                    throw new InvalidOperationException("A guest with this id already exists.");
            }

            _guests.Add(guest);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Guest registered successfully.");
            Console.ResetColor();
        }
    

        private Reservation FindReservation(int reservationId)
        {
            foreach(var r in _reservations)
            {
                if (r.Id == reservationId)
                {
                    return r;
                }
            }
            throw new InvalidOperationException("Reservation not found."); 

        }
        private DateTime? AvailableAgainDate (Rooms room , DateTime CheckIn , DateTime CheckOut)
        {
           
            foreach(var r in _reservations)
            {

                if (r.Room.RoomNumber == room.RoomNumber&&
                    r.Status!=ReservationStatus.Cancelled &&
                    r.Status!=ReservationStatus.CheckedOut &&
                    CheckIn < r.CheckOutDate &&
                    CheckOut > r.CheckInDate)
                {
                    return r.CheckOutDate;
                }
            }
            return null; 
        }
        public Reservation CreateReservation (int Id, Guests guest ,Rooms room , DateTime checkIn, DateTime checkOut)
        {

            if (room == null)
                throw new InvalidOperationException("Room can't be null.");

            if(guest == null)
                throw new InvalidOperationException("Guest can't be null.");

            if (checkOut <= checkIn)
                throw new InvalidOperationException("Check-out date must be after check-in date.");

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException("Room is under maintenance.");

            foreach (var r in _reservations)
            {
                if (r.Id == Id)
                    throw new InvalidOperationException("A reservation with this id already exists.");
            }

            if (AvailableAgainDate(room, checkIn, checkOut)!=null)
                throw new InvalidOperationException("Room is already reserved for the selected dates.");

            Reservation newReservation = new Reservation(Id, checkIn, checkOut, room);
            _reservations.Add(newReservation);
            guest.AddReservation(newReservation);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Reservation created successfully.");
            Console.ResetColor();
            Console.WriteLine($"Room {newReservation.Room.RoomNumber} ({newReservation.Room.Type}) - Total cost: {newReservation.CalculateTotalCost()}");
            return newReservation;



        }

        public void ConfirmReservation(int reservationId)
        {
            FindReservation(reservationId).ConfirmReservation();
        }
    
        public void CheckIn(int reservationId)
        {
            FindReservation(reservationId).CheckIn();
        }

        public void CheckOut(int reservationId)
        {
            FindReservation(reservationId).CheckOut();
        }

        public void CancelReservation(int reservationId)
        {
            FindReservation(reservationId).CancelReservation();
        }


        public void ShowAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            

            if (checkOut <= checkIn)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Check-out date must be after check-in date.");
                Console.ResetColor();
            }
           
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nAvailable Rooms:");
            Console.ResetColor();
            bool isAvailable = false;
            foreach (var room in _rooms)
            {
                if (room.IsUnderMaintenance)
                {
                    continue; 
                }

                DateTime? availableDate = AvailableAgainDate(room, checkIn, checkOut);

                if (availableDate == null)
                {
                    Console.WriteLine($"Room {room.RoomNumber}- {room.Type}- {room.NightlyRate} is available.");
                     isAvailable = true;

                }
                else
                {
                   
                    Console.WriteLine($"Room {room.RoomNumber}- {room.Type}- {room.NightlyRate} is not available. Available again on: {availableDate.Value.ToShortDateString()}");
                  
                }
            }
            if (!isAvailable)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No rooms available for the selected dates.");
                Console.ResetColor();
            }

        }   

    }

}

 