using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Guests
    {
        private readonly List<Reservation> _reservations = new List<Reservation>();
        public int Id { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        public IReadOnlyList<Reservation> Reservations => _reservations;


        public Guests(int id , string fullname , string phonenumber)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                throw new InvalidOperationException("Guest Name can't be null ");
               
            }
            if (string.IsNullOrEmpty(phonenumber))
            {
                throw new InvalidOperationException("Guest Phone Number can't be null ");
            }

            Id = id;
            FullName = fullname;
            PhoneNumber = phonenumber;
        }

        internal void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new InvalidOperationException("Reservation can't be null ");
                Console.ResetColor();
            }
            _reservations.Add(reservation);
        }

        

    }
}
