using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;
using System.Collections.Generic;

namespace Core.UnitTest
{
	[TestClass]
	public class ClientCreateReservation
	{

		IRoom _room1;
		IRoom _room2;
		IRoom _room3;
		IRoom _room4;

		IUser _student;
		IUser _teacher;
		IUser _admin;

		RoomRepository RepoRoom = RoomRepository.Instance; // Singletons
		ReservationRepository RepoReserv = ReservationRepository.Instance;

		[TestInitialize]
		public void TestsInitialize() {
			RepoRoom.Clear();
			RepoReserv.Clear();

			_room1 = new Room('A', 1, 2, 4, Permission.Student);
			_room2 = new Room('A', 1, 99, 8, Permission.Student);
			_room3 = new Room('B', 1, 45, 2, Permission.Student);
			_room4 = new Room('A', 1, 861, 15, Permission.Teacher);

			RepoRoom.Add(_room1);
			RepoRoom.Add(_room2);
			RepoRoom.Add(_room3);

			_student = new User("roxa0198", "roxa0188@edu.eal.dk", Permission.Student);
		}

		[TestMethod]
		public void SortRoomsByMaxPeopleIntoFILOStack() {
			Stack<IRoom> StackRooms = RepoRoom.GetPossible(Permission.Student, 4);

			Assert.AreEqual(StackRooms.Pop(), _room1);
			Assert.AreEqual(StackRooms.Pop(), _room2);
		}

		[TestMethod]
		public void ReqestReservationTest() {

		}

	}
}
