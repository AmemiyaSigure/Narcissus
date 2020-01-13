using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class UsersOptions
    {
        public int Id { get; set; }
        public bool IsShowPhone { get; set; }
        public bool IsShowEmail { get; set; }
        public bool IsShowGender { get; set; }
        public bool IsShowWebsite { get; set; }
        public bool IsShowLevel { get; set; }
        public bool IsShowExperience { get; set; }
    }
}
