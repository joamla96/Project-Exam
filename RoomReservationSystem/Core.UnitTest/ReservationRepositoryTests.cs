using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.UnitTest {
	class ReservationRepositoryTests {
		ReservationRepository _repoReservation;

		IUser _auser;
		IRoom _aroom;

		DateTime _from = new DateTime(2016, 4, 29, 8, 0, 0);
		DateTime _to = new DateTime(2016, 4, 29, 16, 0, 0);

		[TestInitialize]
		TestInitialize() {
			_repoReservation = ReservationRepository.Instance; // Singletons
			_repoReservation.Clear();
		}

		[TestMethod]
		ReservationRepoCanAddReservation() {
			Reservation testreservation = new Reservation(_auser, _aroom, 6, _from, _to);
			_repoReservation.Add(testreservation);

			List<Reservation> reservations = _repoReservation.Get();
			Assert.IsTrue(reservations.Contains(testreservation));
		}

		[TestMethod]
		ReservationRepoCanAddReservationByText() {
			_repoReservation.Add(_auser, _aroom, 6, _from, _to);

			List<Reservation> reservations = _repoReservation.Get();
			Assert.IsTrue(reservations.Contains(new Reservation(_auser, _aroom, 6, _from, _to)));
		}

		[TestMethod]
		ReservationRepoCanBeCleared() {
			Reservation testreservation = new Reservation(_auser, _aroom, 6, _from, _to);
			Reservation testreservation1 = new Reservation(_auser, _aroom, 6, _from, _to);
			_repoReservation.Add(testreservation);
			_repoReservation.Add(testreservation1);

			_repoReservation.Clear();

			List<Reservation> reservations = _repoReservation.Get();
			Assert.IsFalse(reservations.Contains(testreservation));
			Assert.IsFalse(reservations.Contains(testreservation1));
		}
	}
}
