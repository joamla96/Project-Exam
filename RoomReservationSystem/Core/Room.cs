using System;
using Core.Interfaces;

namespace Core
{
	public class Room : IRoom
	{
        public string ID { get return string.Format(; }
        public char Building { get; set; }
        public int Floor { get; set; }
        public int Nr { get; set; }
        public int MaxPeople { get; set; }

        List<Reservation> _reservations = new List<Reservation>();
    }
}
