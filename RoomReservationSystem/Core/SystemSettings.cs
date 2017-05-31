namespace Core
{
    public enum Permission { Student, Teacher, Admin }
    public enum Environment { Prod, Dev, Test }

    public static class SystemSettings
    {

        private static Environment Env = Environment.Prod;

        public static bool _threadRunning = true;

        public static Environment Environment
        {
            get { return Env; }
            set
            {
                // When we change environment, change the database as well...
                UpdateSystemEnvironment();
                Env = value;
            }
        }

        public static void UpdateSystemEnvironment()
        {
            if (Env == Environment.Test) { DAL.DatabaseConn.systemEnvironment = 1; }
            else { DAL.DatabaseConn.systemEnvironment = 0; }
        }
    }
}
