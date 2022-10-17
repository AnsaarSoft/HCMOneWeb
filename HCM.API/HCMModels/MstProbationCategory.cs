using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstProbationCategory
    {
        public MstProbationCategory()
        {
            MstProbationCategoryChildDesignations = new HashSet<MstProbationCategoryChildDesignation>();
            MstProbationStatements = new HashSet<MstProbationStatement>();
        }

        public int Id { get; set; }
        public string Year { get; set; }
        public string Attribute { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? DesignationId { get; set; }

        public virtual MstDesignation Designation { get; set; }
        public virtual MstCalendar YearNavigation { get; set; }
        public virtual ICollection<MstProbationCategoryChildDesignation> MstProbationCategoryChildDesignations { get; set; }
        public virtual ICollection<MstProbationStatement> MstProbationStatements { get; set; }
    }
}
