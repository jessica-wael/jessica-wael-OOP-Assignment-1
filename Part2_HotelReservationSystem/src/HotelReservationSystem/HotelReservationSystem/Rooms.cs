using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Rooms
    {
        private readonly List<Reservation> _reservations = new();
        public int RoomNumber { get; }
        public RoomType Type { get;  }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        public Rooms(int roomNumber, RoomType type, decimal nightlyRate)
        {
            if (roomNumber <= 0)
            {
                
                throw new InvalidOperationException("Room number cannot be zero or negative.");
                
            }

            if (nightlyRate <= 0)
            {
                throw new InvalidOperationException("Nightly rate cannot be zero or negative.");
               
            }

            RoomNumber = roomNumber;
            Type = type;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = false;
        }
        public void ChangeNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Nightly rate cannot be zero or negative.");
                Console.ResetColor();
            }
            NightlyRate = newRate;
        }
        public void StartMaintenance()
        {
            if(IsUnderMaintenance)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Room is already under maintenance.");
                Console.ResetColor();
            }
            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            if (!IsUnderMaintenance)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Room is not under maintenance.");
                Console.ResetColor();
            }
            IsUnderMaintenance = false;
        }
     
    }
}
