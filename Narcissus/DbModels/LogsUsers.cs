using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class LogsUsers
    {
        public int LogUserId { get; set; }
        public int UserId { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public long Time { get; set; }
    }
}
