using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class UsersRegistrationInfo
    {
        public int Id { get; set; }
        public string RegisterPhoneCountryCode { get; set; }
        public string RegisterPhone { get; set; }
        public string RegisterEmail { get; set; }
        public string RegisterIp { get; set; }
        public long RegisterTime { get; set; }
    }
}
