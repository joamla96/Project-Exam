﻿using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class RoomRepository {
		List<IRoom> _roomRepository = new List<IRoom>();

        private static RoomRepository _instance = new RoomRepository();
        public static RoomRepository Instance { get { return _instance; } }

        //public bool IsAvailable(DateTime from, DateTime to)
        //{
        //    throw new NotImplementedException();
        //}

        public void Clear()
        {
            _roomRepository.Clear();
        }

        public void Add(IRoom room)
        {
            _roomRepository.Add(room);
        }

        public void Add(char building, int floor, int nr, int maxPeople, Permission minPermissionLevel)
        {
            Room room = new Room(building, floor, nr, maxPeople, minPermissionLevel);
            _roomRepository.Add(room);
        }

        public List<IRoom> Get()
        {
            return _roomRepository;
        }

		public List<IRoom> Get(Permission PermissionLevel) {
			throw new NotImplementedException();
		}

		public IRoom Get(Reservation reservation)
        {
            Room result = null;
            foreach(Room room in _roomRepository)
            {
                if(room == reservation.Room)
                {
                    result = room;
                }
            }
            return result;
        }

        public Stack<IRoom> GetPossible(Permission student, int v)
        {
            throw new NotImplementedException();
        }

        public void Delete(IRoom room)
        {
            _roomRepository.Remove(room);
        }


    }
}
