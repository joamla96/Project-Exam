using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.UnitTest
{
    [TestClass]
    public class DALFacadeTests
    {
        [TestMethod]
        public void GetAllUsersTest()
        {
            var mockUsers = new Mock<DAL.Users>();
        }
    }
}
