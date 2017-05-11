using System;
using System.Collections.Generic;
using Core.Interfaces;
using DAL;

namespace Core {
	class DALFacade {
		public List<IUser> GetAllUsers() {
			DAL.Users usersData = new DAL.Users();

			List<Dictionary<string, string>> usersInfo = usersData.GetAllUsers();
			List<IUser> users = new List<IUser>();

			foreach (Dictionary<string, string> userInfo in usersInfo) {
				int permissionLevel = int.Parse(userInfo["PermissionLevel"]);
				User newUser = new User(userInfo["Username"], userInfo["Email"], HelperFunctions.ConvertIntToPermission(permissionLevel));
				users.Add(newUser);
			}

			return users;
		}
	}
}
