using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;

namespace Core.UnitTest
{
    [TestClass]
    public class RoomRespositoryTests
    {
        RoomRepository _repoRoom;

        static IUser _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
        static IUser _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
        static IUser _admin = new User("frje", "frje@eal.dk", Permission.Admin);

        [TestInitialize]
        public void TestInitialize()
        {
            _repoRoom = new RoomRepository();
        }
    }
}
