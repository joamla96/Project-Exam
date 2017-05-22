namespace DAL
{
	internal interface ConnInfo
	{
		string ConnString { get; }
	}

	public static class DatabaseConn
	{
		public static int SystemEnviroment = 0;
		private static ConnInfo Conn;
		public static string ConnString { get
			{
				switch(SystemEnviroment)
				{
					case 0:	Conn = new ConnProd(); break;
					case 1: Conn = new ConnTest(); break;
				}

				return Conn.ConnString;
			}
		}
	}

	internal class ConnProd : ConnInfo
	{
		private const string CONNSTRING = @"Server=ealdb1.eal.local; Database=ejl73_db; User Id=ejl73_usr; Password=Baz1nga73";
		public string ConnString { get { return CONNSTRING; } }
	}

	internal class ConnTest : ConnInfo
	{
		private const string CONNSTRING = @"Server=ealdb1.eal.local; Database=ejl73_db; User Id=ejl73_usr; Password=Baz1nga73";
		public string ConnString { get { return CONNSTRING;  } }
	}
}
