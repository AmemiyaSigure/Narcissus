using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class CoolDown
    {
        public int CoolDownId { get; set; }
        public int UserId { get; set; }
        public int TryTimes { get; set; }
        public long LastTryTime { get; set; }
        public int CoolDownLevel { get; set; }
        public long CoolDownEndTime { get; set; }
    }
}
