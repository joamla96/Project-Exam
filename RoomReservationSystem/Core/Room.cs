using System;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{

    public class Room : IRoom, IComparable
	{
        
        public string ID { get { return String.Format("{0}" + "{1}" + "." + "{2:00}", Building, Floor, Nr);} }

        public char Building { get; set; }
        public int Floor { get; set; }
        public int Nr { get; set; }
        public int MaxPeople { get; set; }
        public Permission MinPermissionLevel { get; set; }

        private List<Reservation> _reservations = new List<Reservation>();
        

        public Room(char building, int floor, int nr, int maxpeople, Permission minpermissionlevel)
        {
            this.Building = building;
            this.Floor = floor;
            this.Nr = nr;
            this.MaxPeople = maxpeople;
            this.MinPermissionLevel = minpermissionlevel;
        }

		public bool IsAvailable(DateTime from, DateTime to) {
			bool isAvailable = true;
			foreach(Reservation res in _reservations) {
				if(TimeCollides(res.From, from, to) || TimeCollides(res.To, from, to)) {
					isAvailable = false;
				}
			}

			return isAvailable;
		}

		private bool TimeCollides(DateTime now, DateTime start, DateTime end) {
			// Solution based on StackOverFlow answer:
			// https://stackoverflow.com/questions/12998739/how-to-check-if-datetime-now-is-between-two-given-datetimes-for-time-part-only

			// see if start comes before end
			if (start < end)
				return start <= now && now <= end;
			// start is after end, so do the inverse comparison
			return !(end < now && now < start);
		}

		public override bool Equals(object obj) {
			bool thesame = false;
			if(obj is IRoom) {
				IRoom Other = (IRoom)obj;

				if (this.ID.Equals(Other.ID)) thesame = true;
			}

			return thesame;
		}

		public override int GetHashCode() {
			return this.ID.GetHashCode();
		}

		public int CompareTo(object obj) {
			int result;
			if (obj is IRoom) {
				IRoom Other = (IRoom)obj;

				if (Other.MaxPeople < this.MaxPeople) {
					result = -1;
				} else if (Other.MaxPeople > this.MaxPeople) {
					result = 1;
				} else result = 0;
			} else throw new InvalidCastException();

			return result;
		}

		public void AddReservation(Reservation reserv) {
			_reservations.Add(reserv);
		}

        public List<Reservation> GetReservations()
        {
            return _reservations;
        }

        public void DeleteReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }
    }
}
