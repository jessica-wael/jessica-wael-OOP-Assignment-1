using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Reservation
    {
        public int Id { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Rooms Room { get; }
        public ReservationStatus Status { get; private set; }

        public Reservation(int id, DateTime checkInDate, DateTime checkOutDate, Rooms room)
        {
            if (room == null) { 
                
                throw new ArgumentNullException(nameof(room));
               
            }
            if (checkInDate >= checkOutDate)
            {
                
                throw new InvalidOperationException("Check-in date must be before check-out date.");
                
            }
            if (room.IsUnderMaintenance)
            {
                throw new InvalidOperationException("Cannot reserve this room, it's under maintenance.");
                
            }
            Id = id;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Pending;
        }

        public decimal CalculateTotalCost()
        {
            int totalNights = (CheckOutDate - CheckInDate).Days;
            return totalNights * Room.NightlyRate;
        }

        public void ConfirmReservation()
        {
            if (Status != ReservationStatus.Pending)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Only pending reservations can be confirmed.");
                Console.ResetColor();
            }

            Status = ReservationStatus.Confirmed;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Reservation confirmed.");
            Console.ResetColor();

        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Only confirmed reservations can be checked in.");
                Console.ResetColor();
            }
            Status = ReservationStatus.CheckedIn;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Checked in.");
            Console.ResetColor();
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Only checked-in reservations can be checked out.");
                Console.ResetColor();
            }
            Status = ReservationStatus.CheckedOut;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Checked out.");
            Console.ResetColor();
        }

        public void CancelReservation()
        {
            if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Only pending or confirmed reservations can be cancelled.");
                Console.ResetColor();
            }
            Status = ReservationStatus.Cancelled;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Reservation cancelled.");
            Console.ResetColor();


        }

        

    }     
   
        
}