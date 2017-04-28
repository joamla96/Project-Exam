using System;

namespace Core.Interfaces
{
	public interface IUser
	{
		string Username { get; }
		string Email { get; }
        Permission PermissionLevel { get; set; }
    }
}
