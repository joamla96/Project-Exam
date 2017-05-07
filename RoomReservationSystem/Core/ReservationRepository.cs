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
        List<Reservation> _reservationRepository = new List<Reservation>();
        RoomRepository roomRepo =  RoomRepository.Instance;
        private static ReservationRepository _instance = new ReservationRepository();
        public static ReservationRepository Instance { get { return _instance; } }

        public IRoom RequestReservation(DateTime from, DateTime to, int peopleNr)
        {
            
            IRoom currentRoom;
            IRoom foundRoom = null;
            Stack<IRoom> rooms = roomRepo.GetPossible(LoggedIn.User.PermissionLevel, peopleNr);
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
            _reservationRepository.Clear();
        }

        public void Add(Reservation reservation)
        {
			_reservationRepository.Add(reservation);
			reservation.Room.AddReservation(reservation);
        }
    }
}
