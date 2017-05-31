using Core;
using Core.Interfaces;

namespace UI.GUI.ViewModel
{
	class RegisterRoomVM
	{
		RoomRepository _repoRoom = RoomRepository.Instance;
		public void RegisterRoom(string building, string floor, string nr, string maxpeople,string minpermissionlevel)
		{
			char buildingLetter = char.Parse(building);
			int floorNr = int.Parse(floor);
			int roomNr = int.Parse(nr);
			int maxPeopleNr = int.Parse(maxpeople);
			Permission minPermissionLevel = HelperFunctions.ConvertIntToPermission(int.Parse(minpermissionlevel));

			IRoom room = new Room(buildingLetter, floorNr, roomNr, maxPeopleNr, minPermissionLevel);
			_repoRoom.Add(room);
		}
	}
}
