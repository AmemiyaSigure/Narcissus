using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class UsersSecurity
    {
        public int Id { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public long? LastLoginTime { get; set; }
        public string LastLoginIp { get; set; }
        public string LastLoginToken { get; set; }
    }
}
