using System;
using System.Collections.Generic;
using Core.Interfaces;
using DAL;

namespace Core {

    public class DALFacade {
        private Users usersData;
        private Rooms roomsData;
        private Reservations reservationsData;
        private UserRepository repoUsers;
        private RoomRepository repoRooms;

        public DALFacade()
        {
            this.usersData = new Users();
            this.roomsData = new Rooms();
            this.reservationsData = new Reservations();
            this.repoUsers = UserRepository.Instance;
            this.repoRooms = RoomRepository.Instance;
        }

        public DALFacade(Users usersdata, Rooms roomsdata, Reservations reservationsdata, UserRepository repousers, RoomRepository reporooms)
        {
            this.usersData = usersdata;
            this.roomsData = roomsdata;
            this.reservationsData = reservationsdata;
            this.repoUsers = repousers;
            this.repoRooms = reporooms;
        }

        public List<IUser> GetAllUsers()
        {
            List<Dictionary<string, string>> usersInfo = usersData.GetAllUsersFromDatabase();
            List<IUser> users = this.ConvertFromStringsToUserObjects(usersInfo);
            return users;
        }

		public List<IUser> ConvertFromStringsToUserObjects(List<Dictionary<string, string>> usersinfo) {
			
			List<IUser> users = new List<IUser>();

			foreach (Dictionary<string, string> userInfo in usersinfo) {
				int permissionLevel = int.Parse(userInfo["PermissionLevel"]);
				User newUser = new User(userInfo["Username"], userInfo["Email"], HelperFunctions.ConvertIntToPermission(permissionLevel));
				users.Add(newUser);
			}

			return users;
		}

        public List<IRoom> GetAllRooms()
        {
            List<Dictionary<string, string>> roomsInfo = roomsData.GetAllRoomsFromDatabase();
            List<IRoom> rooms = new List<IRoom>();

            foreach (Dictionary<string, string> roomInfo in roomsInfo)
            {
                int minPermissionLevel = int.Parse(roomInfo["MinPermissionLevel"]);
                char building = char.Parse(roomInfo["Building"]);
                int floornr = int.Parse(roomInfo["FloorNr"]);
                int nr = int.Parse(roomInfo["Nr"]);
                int maxpeople = int.Parse(roomInfo["MaxPeople"]);

                Room newRoom = new Room(building, floornr, nr, maxpeople, HelperFunctions.ConvertIntToPermission(minPermissionLevel));
                rooms.Add(newRoom);
            }

            return rooms;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Dictionary<string, string>> reservationsInfo = reservationsData.GetAllReservations();
            List<Reservation> reservations = new List<Reservation>();

            foreach (Dictionary<string, string> reservationInfo in reservationsInfo)
            {
                IUser dummyUser = new User(reservationInfo["Username"], "", Permission.Student);
                IUser user = repoUsers.Get(dummyUser);

                char building = char.Parse(reservationInfo["Building"]);
                int floornr = int.Parse(reservationInfo["FloorNr"]);
                int nr = int.Parse(reservationInfo["Nr"]);
                IRoom dummyRoom = new Room(building, floornr, nr, 0, Permission.Student);
                IRoom room = repoRooms.Get(dummyRoom);

                DateTime from = DateTime.Parse(reservationInfo["DateFrom"]);
                DateTime to = DateTime.Parse(reservationInfo["DateTo"]);
                int peopleNr = int.Parse(reservationInfo["PeopleNr"]);

                Reservation reservation = new Reservation(user, room, peopleNr, from, to);
                reservations.Add(reservation);


            }
            return reservations;
        }
    }
}
