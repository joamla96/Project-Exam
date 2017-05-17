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

        public override string ToString()
        {
            StringWriter output = new StringWriter();

            output.Write(Room.ID + " ");

            string date = From.Day +"."+ From.Month +"."+ From.Year;
            output.Write(date+ " ");

            string hour = From.Hour +":"+ From.Minute + " - " + To.Hour + ":" + To.Minute;
            output.Write(hour);

            return output.ToString();
            //return Room.ID + " " + From + " " + To + "";

            //return String.Format("{0}" + "{1}" + "." + "{2:00}", Building, Floor, Nr);
        }
    }
}

  