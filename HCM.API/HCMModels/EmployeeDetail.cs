using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class EmployeeDetail
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string JobTitle { get; set; }
    }
}
