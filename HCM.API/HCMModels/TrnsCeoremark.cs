using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrnsCeoremark
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
