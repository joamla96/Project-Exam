using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;

namespace Core.UnitTest
{
    [TestClass]
    public class CreateInstance
    {
        IRoom _room1;
        IRoom _room2;
        IRoom _room3;

        IUser _student;
        IUser _teacher;
        IUser _admin;

        Reservation _reservation1;
        Reservation _reservation2;
        Reservation _reservation3;

        [TestMethod]
        public void CanCreateRoomInstance()
        {
            _room1 = new Room()
        }
    }
}
