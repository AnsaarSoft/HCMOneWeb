using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class AttendanceLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AttendanceDate { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string CheckInImage { get; set; }
        public string CheckOutImage { get; set; }
        public string CheckInRemarks { get; set; }
        public string CheckOutRemarks { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CheckInLat { get; set; }
        public string CheckInLang { get; set; }
        public string CheckOutLat { get; set; }
        public string CheckOutLang { get; set; }
        public byte? DocType { get; set; }
        public string DocStatus { get; set; }
        public string DocStatusLov { get; set; }
        public string DocAprStatus { get; set; }
        public string DocAprStatusLov { get; set; }
        public int? EmpId { get; set; }
        public string RejecterName { get; set; }
        public string RejecterDept { get; set; }
        public string RejecterDesignation { get; set; }
        public string RejecterRemarks { get; set; }
        public string ProjectIn { get; set; }
        public string ProjectOut { get; set; }
        public string SiteIn { get; set; }
        public string SiteOut { get; set; }
        public string AndroidDocNum { get; set; }
        public string AndroidBuildVersion { get; set; }
        public string Json { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
