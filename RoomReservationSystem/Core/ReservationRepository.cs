using Core.Interfaces;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ReservationRepository
    {
        DALFacade _dalFacade = new DALFacade();
        List<Reservation> _reservationRepository = new List<Reservation>();
        RoomRepository _roomRepo =  RoomRepository.Instance;
        private static ReservationRepository _instance = new ReservationRepository();
        public static ReservationRepository Instance { get { return _instance; } }

        public IRoom RequestReservation(DateTime from, DateTime to, int peopleNr)
        {
            
            IRoom currentRoom;
            IRoom foundRoom = null;
            Stack<IRoom> rooms = _roomRepo.GetPossible(LoggedIn.User.PermissionLevel, peopleNr);
            while (foundRoom == null && rooms.Count > 1)
            {
                currentRoom = rooms.Pop();
                bool roomAvailable = currentRoom.IsAvailable(from, to);
                if (roomAvailable == true)
                {
                    foundRoom = currentRoom;
                }
            }
            if (foundRoom == null)
            {
                throw new NoRoomsAvailable();
            }
            else
            {
                Reservation reservation = new Reservation(LoggedIn.User, foundRoom, peopleNr, from, to);
                this.Add(reservation);
                return foundRoom;
            }
            
        }
        public void Clear()
        {
            foreach(Reservation reservation in _reservationRepository)
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
        }

        public void Delete(Reservation reservation)
        {
            _reservationRepository.Remove(reservation);
            reservation.Room.DeleteReservation(reservation); //database?
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

            foreach(Reservation reservation in _reservationRepository)
            {
                if(reservation.User.Equals(user))
                {
                    reservationsByUser.Add(reservation);
                }
            }
            return reservationsByUser;
        }

        public List<Reservation> Get(IRoom room)
        {
            List<Reservation> reservationsByRoom = new List<Reservation>();

            foreach(Reservation reservation in _reservationRepository)
            {
                if(reservation.Room.Equals(room))
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
    }
}
