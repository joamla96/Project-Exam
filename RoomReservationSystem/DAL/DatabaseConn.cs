using System;

namespace DAL
{
    internal interface ConnInfo { string ConnString { get; } }

    public static class DatabaseConn
    {
        public static int systemEnvironment = 0;
        private static ConnInfo conn;
        public static string ConnString
        {
            get
            {
                switch (systemEnvironment)
                {
                    default: throw new IndexOutOfRangeException();
                    case 0: conn = new ConnProd(); break;
                    case 1: conn = new ConnTest(); break;
                }

                return conn.ConnString;
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
        public string ConnString { get { return CONNSTRING; } }
    }
}
