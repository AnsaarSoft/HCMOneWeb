using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgDbsetting
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string DbuserName { get; set; }
        public string Dbpassword { get; set; }
        public string DatabaseName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
        public string DbdisplayName { get; set; }
    }
}
