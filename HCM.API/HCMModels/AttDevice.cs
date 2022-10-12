using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttDevice
    {
        public AttDevice()
        {
            AttDevUsers = new HashSet<AttDevUser>();
        }

        public int Id { get; set; }
        public string Department { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string CommKey { get; set; }
        public string CommPort { get; set; }
        public string BaudRate { get; set; }
        public string Modal { get; set; }
        public string Dela { get; set; }
        public string Timeout { get; set; }
        public bool? FlgActive { get; set; }

        public virtual ICollection<AttDevUser> AttDevUsers { get; set; }
    }
}
