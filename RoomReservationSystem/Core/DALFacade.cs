using System;
using System.Collections.Generic;
using Core.Interfaces;
using DAL;
using System.IO;

namespace Core {
    public interface IDALFacade
        {
        List<IUser> GetAllUsers();
        List<Reservation> GetAllReservations();
        List<IUser> ConvertFromStringsToUserObjects(List<Dictionary<string, string>> usersinfo);
        List<IRoom> GetAllRooms();
        List<IRoom> ConvertFromStringsToRoomObjects(List<Dictionary<string, string>> list);
        void PassReservationToDAL(Reservation reservation);
    }
    public class DALFacade:IDALFacade
    {
        private Users usersData;
        private Rooms roomsData;
        private Reservations reservationsData;

        internal void DeleteAllUsers()
        {
            usersData.DeleteAllUserFromDatabase();
        }

        internal void DeleteAllRooms()
        {
            roomsData.DeleteAllRoomsFromDatabase();
        }

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

        public List<Reservation> GetAllReservations()
        {
            List<Dictionary<string, string>> reservationsInfo = reservationsData.GetAllReservationsFromDatabase();
            List<Reservation> reservations = this.ConvertFromStringsToReservationObjects(reservationsInfo);
            return reservations;
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
            List<IRoom> rooms = ConvertFromStringsToRoomObjects(roomsInfo);
            return rooms;
        }

        public List<IRoom> ConvertFromStringsToRoomObjects(List<Dictionary<string, string>> list)
        {
            List<IRoom> rooms = new List<IRoom>();

            foreach (Dictionary<string, string> roomInfo in list)
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

        public List<Reservation> ConvertFromStringsToReservationObjects(List<Dictionary<string,string>> reservationsinfo)
        {
            List<Reservation> reservations = new List<Reservation>();

            foreach (Dictionary<string, string> reservationInfo in reservationsinfo)
            {
                IUser dummyUser = new User(reservationInfo["Username"], "", Permission.Student);
                IUser user = repoUsers.Get(dummyUser);

                char building = char.Parse(reservationInfo["Building"]);
                int floorNr = int.Parse(reservationInfo["FloorNr"]);
                int nr = int.Parse(reservationInfo["Nr"]);
                IRoom dummyRoom = new Room(building, floorNr, nr, 0, Permission.Student);
                IRoom room = repoRooms.Get(dummyRoom);

                DateTime from = DateTime.Parse(reservationInfo["DateFrom"]);
                DateTime to = DateTime.Parse(reservationInfo["DateTo"]);
                int peopleNr = int.Parse(reservationInfo["PeopleNr"]);

                Reservation reservation = new Reservation(user, room, peopleNr, from, to);
                reservations.Add(reservation);
            }
            return reservations;
        }

        public void DeleteReservation(Reservation reservation)
        {
            reservationsData.DeleteReservationFromDatabase(reservation.User.Username, reservation.From, reservation.To);
        }

        public void DeleteRoom(IRoom room)
        {
            roomsData.DeleteRoomFromDatabase(room.Building.ToString(), room.Floor.ToString(), room.Nr.ToString());
        }

        public void DeleteUser(IUser user)
        {
            usersData.DeleteUserFromDatabase(user.Username);
        }

        public void PassReservationToDAL(Reservation reservation)
        {
            reservationsData.StoreReservationIntoDatabase(this.ConvertFromReservationObjectToStrings(reservation));
        }

        private Dictionary<string, string> ConvertFromReservationObjectToStrings(Reservation reservation)
        {
            Dictionary<string, string> reservationInfo = new Dictionary<string, string>();

            StringWriter DateToString = new StringWriter();
            StringWriter DateFromString = new StringWriter();

            string dateTo = reservation.To.Year + "-" + reservation.To.Month + "-" + reservation.To.Day;
            DateToString.Write(dateTo + " ");
            string dateFrom = reservation.From.Year + "-" + reservation.From.Month + "-" + reservation.From.Day;
            DateFromString.Write(dateFrom + " ");

            string hourFormat = "{0:00}:{1:00}:{2:00}";
            DateToString.Write(hourFormat, reservation.To.Hour, reservation.To.Minute, reservation.To.Second);
            DateFromString.Write(hourFormat, reservation.From.Hour, reservation.From.Minute, reservation.From.Second);

            reservationInfo.Add("PeopleNr", Convert.ToString(reservation.PeopleNr));
            reservationInfo.Add("DateTo", DateToString.ToString());
            reservationInfo.Add("DateFrom", DateFromString.ToString());
            reservationInfo.Add("Building", Convert.ToString(reservation.Room.Building));
            reservationInfo.Add("FloorNr", Convert.ToString(reservation.Room.Floor));
            reservationInfo.Add("Nr", Convert.ToString(reservation.Room.Nr));
            reservationInfo.Add("Username", Convert.ToString(reservation.User.Username));

            return reservationInfo;
        }

        public void InsertUser(IUser user)
        {
            usersData.InsertUserToDatabase(user.Username, user.Email,(int) user.PermissionLevel);
        }
    }
}
