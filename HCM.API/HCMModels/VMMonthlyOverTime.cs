using System.Collections.Generic;

namespace HCM.API.HCMModels
{
    public class VMMonthlyOverTime
    {
       public TrnsSingleEntryOtrequest TrnsSingleEntryOtrequest { get; set; }
       public List<TrnsEmployeeOvertime> TrnsEmployeeOvertime{ get; set; }

    }
}
