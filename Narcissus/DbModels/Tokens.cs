using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class Tokens
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        public string ClientIp { get; set; }
        public long IssueTime { get; set; }
        public long ExpireTime { get; set; }
        public byte Status { get; set; }
    }
}
