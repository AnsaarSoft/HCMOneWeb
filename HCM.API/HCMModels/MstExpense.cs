using System;
using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public partial class MstExpense
    {
        public int Id { get; set; }
        public string ExpenseId { get; set; }
        public string Description { get; set; }
        public bool? FlgActive { get; set; }
        public bool? FlgVoss { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
