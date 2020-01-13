using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class UsersInfo
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Signature { get; set; }
        public int Gender { get; set; }
        public string Avatar { get; set; }
        public string WebSite { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
