using Core.Interfaces;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RoomRepository
    {
        List<IRoom> _roomRepository = new List<IRoom>();
        private static RoomRepository _instance = new RoomRepository();
        public static RoomRepository Instance { get { return _instance; } }
        private DALFacade _dalFacade = new DALFacade();

        public void Clear()
        {
            ReservationRepository.Instance.Clear();
            foreach (IRoom room in _roomRepository)
            {
                _dalFacade.DeleteRoom(room);
            }
            _roomRepository.Clear();
        }

        public void Add(IRoom room)
        {
            _roomRepository.Add(room);
        }

        public void Add(char building, int floor, int nr, int maxPeople, Permission minpermissionlevel)
        {
            Room room = new Room(building, floor, nr, maxPeople, minpermissionlevel);
            this.Add(room);
        }

        public List<IRoom> Get()
        {
            return _roomRepository;
        }

        public List<IRoom> Get(Permission permissionlevel)
        {
            List<IRoom> roomsByPermissionLevel = new List<IRoom>();

            foreach (IRoom room in _roomRepository)
            {
                if (room.MinPermissionLevel <= permissionlevel)
                {
                    roomsByPermissionLevel.Add(room);
                }
            }

            return roomsByPermissionLevel;
        }

        public IRoom Get(IRoom checkroom)
        {
            IRoom foundroom = null;
            foreach (IRoom room in _roomRepository)
            {
                if (room.Equals(checkroom))
                {
                    foundroom = room;
                }
            }

            if (foundroom == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return foundroom;
            }
        }

        public IRoom Get(Reservation reservation)
        {
            Room roomsByReservation = null;
            foreach (Room room in _roomRepository)
            {
                if (room == reservation.Room)
                {
                    roomsByReservation = room;
                }
            }
            return roomsByReservation;
        }

        public Stack<IRoom> GetPossible(Permission permissionlevel, int people)
        {
            List<IRoom> permission = this.Get(permissionlevel);
            List<IRoom> possible = new List<IRoom>();
            Stack<IRoom> stack = new Stack<IRoom>();

            foreach (IRoom room in permission)
            {
                if (room.MaxPeople >= people)
                {
                    possible.Add(room);
                }
            }

            possible.Sort();

            foreach (IRoom room in possible)
            {
                stack.Push(room);
            }

            return stack;
        }

        public void Delete(IRoom room)
        {
            _roomRepository.Remove(room);
        }
    }
}
