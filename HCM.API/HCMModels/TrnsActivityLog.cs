using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsActivityLog
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string UserIp { get; set; }
        public int ActivityType { get; set; }
        public string ActivityDescription { get; set; }
        public string Query { get; set; }
        public DateTime? ActivityDatetime { get; set; }
        public string LoggedInDb { get; set; }
    }
}
