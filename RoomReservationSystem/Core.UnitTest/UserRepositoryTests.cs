using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Core.Interfaces;

namespace Core.UnitTest
{
    [TestClass]
    public class UserRepositoryTests
    {
        UserRepository _repoUser = UserRepository.Instance;

        List<IUser> _userList;

        IUser _student;
        IUser _teacher;
        IUser _admin;

        IRoom _room1;
        IRoom _room2;
        IRoom _room3;
        IRoom _room4;
        IRoom _room5;

        Reservation _reservation1;
        Reservation _reservation2;
        Reservation _reservation3;

        DateTime _dateFrom;
        DateTime _dateTo;

        [TestInitialize]
        public void TestInitialize()
        {
            _repoUser.Clear();

            _userList = new List<IUser>();

            _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
            _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
            _admin = new User("frje", "frje@eal.dk", Permission.Admin);

            _repoUser.Add(_student);
            _repoUser.Add(_teacher);
            _repoUser.Add(_admin);

            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            _room2 = new Room('A', 2, 15, 6, Permission.Teacher);
            _room3 = new Room('A', 2, 115, 6, Permission.Admin);
            _room4 = new Room('A', 7, 5, 2, Permission.Student);
            _room5 = new Room('B', 7, 5, 10, Permission.Student);

            _dateFrom = new DateTime(2016, 4, 29, 8, 0, 0);
            _dateTo = new DateTime(2016, 4, 29, 16, 0, 0);

            _reservation1 = new Reservation(_student, _room1, 6, _dateFrom, _dateTo);
            _reservation2 = new Reservation(_teacher, _room2, 6, _dateFrom, _dateTo);
            _reservation3 = new Reservation(_admin, _room3, 6, _dateFrom, _dateTo);
        }

        [TestMethod]
        public void AddUserFromText()
        {
            IUser testUser = new User("matt2695", "matt2695@edu.eal.dk", Permission.Student);
            _repoUser.Add("matt2695", "matt2695@edu.eal.dk", Permission.Student);
            _userList = _repoUser.Get();
            Assert.IsTrue(_userList.Contains(testUser));
        }

        [TestMethod]
        public void AddUserFromObject()
        {
            _userList = _repoUser.Get();
            Assert.IsTrue(_userList.Contains(_student));
        }

        [TestMethod]
        public void GetAllUsers()
        {
            _userList = _repoUser.Get();
            Assert.AreEqual(3, _userList.Count);
        }

        [TestMethod]
        public void GetUserByUser()
        {
            IUser testUser;
            testUser = _repoUser.Get(_student); //again, i don't understand this
            Assert.AreEqual(_student, testUser);
        }

        [TestMethod]
        public void GetUserByUserDoesntReturnOthers()
        {
            IUser testUser;
            testUser = _repoUser.Get(_student); //again, i don't understand this
            Assert.AreNotEqual(_teacher, testUser);
            Assert.AreNotEqual(_admin, testUser);
        }

        [TestMethod]
        public void GetUserByRoom()
        {
            _userList = _repoUser.Get(_room1);
            Assert.IsTrue(_userList.Contains(_student));
        }

        [TestMethod]
        public void GetUserByRoomDoesntReturnOthers()
        {
            _userList = _repoUser.Get(_room1);
            Assert.IsFalse(_userList.Contains(_teacher));
            Assert.IsFalse(_userList.Contains(_admin));
        }

        [TestMethod]
        public void GetUserByReservation()
        {
            _userList = _repoUser.Get(_reservation1);
            Assert.IsTrue(_userList.Contains(_student));
        }

        [TestMethod]
        public void GetUserByReservationDoesntGetOthers()
        {
            _userList = _repoUser.Get(_reservation1);
            Assert.IsFalse(_userList.Contains(_teacher));
            Assert.IsFalse(_userList.Contains(_admin));
        }

        [TestMethod]
        public void DeleteUser()
        {
            _repoUser.Delete(_student);
            _userList = _repoUser.Get();
            Assert.IsFalse(_userList.Contains(_student));
        }

        [TestMethod]
        public void DeleteUserDoesntDeleteOthers()
        {
            _repoUser.Delete(_student);
            _userList = _repoUser.Get();
            Assert.IsTrue(_userList.Contains(_teacher));
            Assert.IsTrue(_userList.Contains(_admin));
        }
    }
}
