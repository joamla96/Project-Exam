using System;

namespace Core
{
    public static class HelperFunctions
    {
        public static Permission ConvertIntToPermission(int permissionlevel)
        {
            Permission permission = Permission.Student;
            switch (permissionlevel)
            {
                default: throw new Exception("Invalid Permission Level");
                case 0: permission = Permission.Student; break;
                case 1: permission = Permission.Teacher; break;
                case 2: permission = Permission.Admin; break;
            }
            return permission;
        }

        public static bool TimeCollides(DateTime now, DateTime start, DateTime end)
        {
            // Solution based on StackOverFlow answer:
            // https://stackoverflow.com/questions/12998739/how-to-check-if-datetime-now-is-between-two-given-datetimes-for-time-part-only

            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }
    }
}
