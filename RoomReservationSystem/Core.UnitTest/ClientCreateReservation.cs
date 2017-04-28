using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;

namespace Core.UnitTest
{
	[TestClass]
	public class ClientCreateReservation
	{

		IRoom _room1;
		IRoom _room2;
		IRoom _room3;

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
			_room2 = new Room('A', 1, 2, 99, Permission.Admin);
			_room3 = new Room('B', 1, 3, 45, Permission.Teacher);

			_student = new User("roxa0198", "roxa0188@edu.eal.dk", Permission.Student);
			_teacher = new User("lehe", "lehe@eal.dk", Permission.Teacher);
			_admin = new User("joro", "fictive@example.com", Permission.Admin);
		}

	}
}
