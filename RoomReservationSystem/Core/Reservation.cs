using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Core
{
    public class Reservation
    {

        public IUser User { get; set; }
        public IRoom Room { get; set; }
        public int PeopleNr { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Reservation(IUser user, IRoom room, int peoplenr, DateTime from, DateTime to)
        {
            this.User = user;
            this.Room = room;
            this.PeopleNr = peoplenr;
            this.From = from;
            this.To = to;
        }

        public override bool Equals(object obj)
        {
            bool thesame = false;
            if (obj is Reservation)
            {
                Reservation Other = (Reservation)obj;

                if (this.User.Equals(Other.User) && this.From.Equals(Other.From) && this.To.Equals(Other.To)) thesame = true;
            }

            return thesame;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringWriter output = new StringWriter();

            output.Write(Room.ID + " ");

            string date = From.Day + "." + From.Month + "." + From.Year;
            output.Write(date + " ");

            string hourFormat = "{0:00}:{1:00} - {2:00}:{3:00}";
            output.Write(hourFormat, From.Hour, From.Minute, To.Hour, To.Minute);

            return output.ToString();
        }

    }
}

  