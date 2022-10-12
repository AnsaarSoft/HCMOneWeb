using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationStatement
    {
        public MstProbationStatement()
        {
            MstProbationStatementsChildDesignations = new HashSet<MstProbationStatementsChildDesignation>();
            TrnsProbationAssesDetails = new HashSet<TrnsProbationAssesDetail>();
            TrnsProbationCategorryCycleAttachments = new HashSet<TrnsProbationCategorryCycleAttachment>();
        }

        public int Id { get; set; }
        public int? ProbationCategoryId { get; set; }
        public string Statement { get; set; }
        public bool? FlgActive { get; set; }
        public int? DesignationId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual MstDesignation Designation { get; set; }
        public virtual MstProbationCategory ProbationCategory { get; set; }
        public virtual ICollection<MstProbationStatementsChildDesignation> MstProbationStatementsChildDesignations { get; set; }
        public virtual ICollection<TrnsProbationAssesDetail> TrnsProbationAssesDetails { get; set; }
        public virtual ICollection<TrnsProbationCategorryCycleAttachment> TrnsProbationCategorryCycleAttachments { get; set; }
    }
}
