using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class LogsApps
    {
        public int LogAppId { get; set; }
        public int AppId { get; set; }
        public int UserId { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public long Time { get; set; }
    }
}
