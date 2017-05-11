using System;
using System.Collections.Generic;
using DAL;

namespace Core {
	class DALFacade {
		public List<User> GetAllUsers() {
			DAL.Users usersData = new DAL.Users();

			List<Dictionary<string, string>> usersInfo = usersData.GetAllUsers();
			List<User> users = new List<User>();

			foreach (Dictionary<string, string> userInfo in usersInfo) {
				int permissionLevel = int.Parse(userInfo["PermissionLevel"]);
				User newUser = new User(userInfo["Username"], userInfo["Email"], HelperFunctions.ConvertIntToPermission(permissionLevel));
				users.Add(newUser);
			}

			return users;
		}
	}
}
