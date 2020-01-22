using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narcissus.Utilities
{
    public class Time
    {
        public static string GetTimeStamp13()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return ((long)(ts.TotalMilliseconds)).ToString();
        }

        public static string GetTimeStamp13(long offsetMilliseconds)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return ((long)(ts.TotalMilliseconds) + offsetMilliseconds).ToString();
        }

        public static string GetTimeStamp10()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return ((long)(ts.TotalSeconds)).ToString();
        }

        public static string GetTimeStamp10(long offsetMilliseconds)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return ((long)(ts.TotalSeconds) + offsetMilliseconds / 1000).ToString();
        }
    }
}
