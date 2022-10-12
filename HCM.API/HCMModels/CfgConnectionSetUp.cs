using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgConnectionSetUp
    {
        public int Id { get; set; }
        public bool? FlgAccess { get; set; }
        public bool? FlgSqlServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TableName { get; set; }
        public string FileLocation { get; set; }
        public string Dbname { get; set; }
        public string ServerName { get; set; }
        public string MachineType { get; set; }
        public string CfgEmpId { get; set; }
        public string CfgDateIn { get; set; }
        public string CfgDateOut { get; set; }
        public string CfgTimeIn { get; set; }
        public string CfgTimeOut { get; set; }
        public string CfgInOut { get; set; }
    }
}
