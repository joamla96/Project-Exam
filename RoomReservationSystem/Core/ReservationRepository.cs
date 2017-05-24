using Core.Interfaces;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ReservationRepository/* : IObservable*/
    {
        DALFacade _dalFacade = new DALFacade();
        List<Reservation> _reservationRepository = new List<Reservation>();
        //private List<IObserver> _observers = new List<IObserver>();
        RoomRepository _roomRepo = RoomRepository.Instance;
        private static ReservationRepository _instance = new ReservationRepository();
        public static ReservationRepository Instance { get { return _instance; } }

        public IRoom RequestReservation(DateTime from, DateTime to, int peopleNr, IUser user)
        {

            if(user.HasReservation(from.AddSeconds(1), to))
            {
                throw new UserAlreadyHasRoomException();
            }

            List<IRoom> rooms = _roomRepo.GetPossible(user.PermissionLevel, peopleNr);

			List<IRoom> availableRooms = RemoveUnavailableRooms(rooms, from, to);

            if (availableRooms.Count == 0)
            {
                throw new NoRoomsAvailable();
            }
            else
            {
                Reservation reservation = new Reservation(user, availableRooms[0], peopleNr, from, to);
                this.Add(reservation);
                return availableRooms[0];
            }

        }

		public List<IRoom> GetAvailableRooms(DateTime from, DateTime to, IUser user)
		{
			List<IRoom> rooms = _roomRepo.GetPossible(user.PermissionLevel);
			List<IRoom> availableRooms = RemoveUnavailableRooms(rooms, from, to);
			return availableRooms;
		}

		private List<IRoom> RemoveUnavailableRooms(List<IRoom> rooms, DateTime from, DateTime to)
		{
			List<IRoom> availableRooms = new List<IRoom>();

			foreach (IRoom room in rooms)
			{
				bool roomAvailable = room.IsAvailable(from, to);
				if (roomAvailable == true)
				{
					availableRooms.Add(room);
				}
			}
			return availableRooms;
		}

        internal void LoadFromDatabase(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
            reservation.Room.AddReservation(reservation);
            reservation.User.AddReservation(reservation);
        }

        public void Clear()
        {
            foreach (Reservation reservation in _reservationRepository)
            {
                _dalFacade.DeleteReservation(reservation);
            }
            _reservationRepository.Clear();
        }

        public void Add(Reservation reservation)
        {
            _reservationRepository.Add(reservation);
            reservation.Room.AddReservation(reservation);
            reservation.User.AddReservation(reservation);
            _dalFacade.PassReservationToDAL(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _reservationRepository.Remove(reservation);
            reservation.Room.DeleteReservation(reservation);
            reservation.User.DeleteReservation(reservation);
            _dalFacade.DeleteReservation(reservation);
        }

        public void Add(IUser user, IRoom room, int peoplenr, DateTime datefrom, DateTime dateto)
        {
            Reservation reservation = new Reservation(user, room, peoplenr, datefrom, dateto);
            this.Add(reservation);
        }

        public List<Reservation> Get()
        {
            return _reservationRepository;
        }

        public List<Reservation> Get(IUser user)
        {
            List<Reservation> reservationsByUser = new List<Reservation>();

            foreach (Reservation reservation in _reservationRepository)
            {
                if (reservation.User.Equals(user))
                {
                    reservationsByUser.Add(reservation);
                }
            }
            return reservationsByUser;
        }

        public List<Reservation> Get(IRoom room)
        {
            List<Reservation> reservationsByRoom = new List<Reservation>();

            foreach (Reservation reservation in _reservationRepository)
            {
                if (reservation.Room.Equals(room))
                {
                    reservationsByRoom.Add(reservation);
                }
            }
            return reservationsByRoom;
        }

        public Reservation Get(Reservation checkreservation)
        {
            Reservation result = null;

            foreach (Reservation reservation in _reservationRepository)
            {
                if (reservation.Equals(checkreservation))
                {
                    result = reservation;
                }
            }
            return result;
        }

		public List<Reservation> Get(DateTime? from, DateTime? to, IUser user)
		{
			List<Reservation> reservations = new List<Reservation>();
			List<Reservation> allReservations = this.Get();

			if (from != null)
			{
				foreach (Reservation reservation in allReservations)
				{
					if (from < reservation.From)
					{
						reservations.Add(reservation);
					}
				}
				allReservations = reservations;
				reservations = new List<Reservation>();
			}

			if (to != null)
			{
				foreach (Reservation reservation in allReservations)
				{
					if (to > reservation.To)
					{
						reservations.Add(reservation);
					}
				}
				allReservations = reservations;
				reservations = new List<Reservation>();
			}

			if (user != null)
			{
				foreach (Reservation reservation in allReservations)
				{
					if (user.Equals(reservation.User))
					{
						reservations.Add(reservation);
					}
				}
				allReservations = reservations;
				reservations = new List<Reservation>();
			}
			return allReservations;
		}

			//public void Subscribe(IObserver observer)
			//{
			//    _observers.Add(observer);
			//}

			//public void Unsubscribe(IObserver observer)
			//{
			//    _observers.Remove(observer);
			//}

			//public void Notify()
			//{
			//    _observers.ForEach(observer => observer.Update());
			//}
		}
}
