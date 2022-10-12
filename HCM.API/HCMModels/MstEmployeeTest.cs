using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstEmployeeTest
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
