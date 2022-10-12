using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class ViewDeptHiearcy
    {
        public int Id { get; set; }
        public byte? DeptLevel { get; set; }
        public string Code { get; set; }
        public string DeptName { get; set; }
        public int? L1id { get; set; }
        public string L1code { get; set; }
        public string L1deptName { get; set; }
        public int? L2id { get; set; }
        public string L2code { get; set; }
        public string L2deptName { get; set; }
        public int? L3id { get; set; }
        public string L3code { get; set; }
        public string L3deptName { get; set; }
        public int? L4id { get; set; }
        public string L4code { get; set; }
        public string L4deptName { get; set; }
    }
}
