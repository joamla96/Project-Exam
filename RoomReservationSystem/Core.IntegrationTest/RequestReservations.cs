using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.IntegrationTest
{
    [TestClass]
    public class RequestReservations
    {
        ReservationRepository _repoReserv = ReservationRepository.Instance;
        UserRepository _repoUser = UserRepository.Instance;
        RoomRepository _repoRoom = RoomRepository.Instance;

        IRoom _room1;
        IRoom _room2;

        IUser _student;

        [ClassInitialize]
        public void ClassInit()
        {
            SystemSettings.Enviroment = Enviroment.Test;
        }

        [ClassCleanup]
        public void ClassClean()
        {
            SystemSettings.Enviroment = Enviroment.Prod;
        }

        [TestInitialize]
        public void Init()
        {
            _repoReserv.Clear();
            _repoUser.Clear();
            _repoRoom.Clear();

            _room1 = new Room('A', 1, 49, 4, Permission.Student);
            _room2 = new Room('B', 2, 23, 6, Permission.Student);

            _student = new User("jona8690", "jona8690@edu.eal.dk", Permission.Student);

            _repoRoom.Add(_room1);
            _repoRoom.Add(_room2);
        }

        //[TestMethod]
        //public void StudentCanRequestAReservation() {
        //	//_repoReserv.RequestReservation();
        //}
    }
}
