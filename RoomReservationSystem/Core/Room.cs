using System;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{

    public class Room : IRoom
	{
        
        public string ID { get { return String.Format("{0}" + "{1}" + "." + "{2}", Building, Floor, Nr);} }

        public char Building { get; set; }
        public int Floor { get; set; }
        public int Nr { get; set; }
        public int MaxPeople { get; set; }
        public Permission MinPermissionLevel { get; set; }


        List<Reservation> _reservations = new List<Reservation>();
        

        public Room(char building, int floor, int nr, int maxPeople, Permission minPremissionLevel)
        {
            this.Building = building;
            this.Floor = floor;
            this.Nr = nr;
            this.MaxPeople = maxPeople;
            this.MinPermissionLevel = minPremissionLevel;
        }
    }
}
