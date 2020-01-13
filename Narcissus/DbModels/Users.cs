using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string OpenUserId { get; set; }
        public string PhoneCountryCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
