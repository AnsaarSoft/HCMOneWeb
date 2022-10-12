using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class TrainingRequestForm
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string TrainingRequired { get; set; }
        public int? TrainingCategory { get; set; }
        public string Trainer { get; set; }
        public string Scope { get; set; }
        public string ExpectedOutcome { get; set; }
        public string FileExtension { get; set; }
        public string DocName { get; set; }
        public decimal? TrainingFee { get; set; }
        public decimal? TravellingFees { get; set; }
        public decimal? AccommodationFees { get; set; }
        public decimal? PettyExpenses { get; set; }
        public decimal? OtherExpenses { get; set; }
        public decimal? Total { get; set; }
        public int? DocNum { get; set; }
        public string DocStatus { get; set; }
        public string DocAprStatus { get; set; }
        public int? DocType { get; set; }
        public int? CourseId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string SpecificCategory { get; set; }

        public virtual MstEmployee Emp { get; set; }
    }
}
