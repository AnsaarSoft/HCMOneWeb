using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class CfgEmpCodeGeneration
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string Prefix { get; set; }
        public int? Position { get; set; }
        public bool? FlgSelected { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
