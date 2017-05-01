using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Reservation
    {
       

        public Reservation(IUser user, IRoom room, int peopleNr, DateTime from, DateTime to)
        {
            this.User = user;
            this.Room = room;
            this.PeopleNr = peopleNr;
            this.From = from;
            this.To = to;
        }

        public IUser User { get; set; }
        public IRoom Room { get; set; }
        public int PeopleNr { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
    }
}
