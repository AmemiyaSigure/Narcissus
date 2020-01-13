using System;
using System.Collections.Generic;

namespace Narcissus.DbModels
{
    public partial class AppsTokens
    {
        public int AppTokenId { get; set; }
        public int AppId { get; set; }
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        public string ClientIp { get; set; }
        public long IssueTime { get; set; }
        public long ExpireTime { get; set; }
    }
}
