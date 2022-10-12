namespace HCM.UI.General
{
    public class BusinessLogic
    {
        public static MstEmployee ApplyPayrolStdlElement(MstEmployee oModel, IEnumerable<MstElement> oListElement, string LoginUser)
        {
            try
            {
                TrnsEmployeeElement oTrnsEmployeeElement = new TrnsEmployeeElement();
                //Check Existing Element
                var ExistingElementHeader = oModel.TrnsEmployeeElements.Where(x => x.EmployeeId == oModel.Id).FirstOrDefault();
                if (ExistingElementHeader == null)
                {
                    oTrnsEmployeeElement.EmployeeId = oModel.Id;
                    oTrnsEmployeeElement.FlgActive = true;
                    oTrnsEmployeeElement.CreateDate = DateTime.Now;
                    oTrnsEmployeeElement.UserId = LoginUser;
                    foreach (var Element in oListElement)
                    {
                        TrnsEmployeeElementDetail oTrnsEmployeeElementDetail = new TrnsEmployeeElementDetail();
                        oTrnsEmployeeElementDetail.ElementId = Element.Id;
                        oTrnsEmployeeElementDetail.ElementCode = Element.Code;
                        oTrnsEmployeeElementDetail.ElementDescription = Element.Description;
                        oTrnsEmployeeElementDetail.ElementType = Element.ElmtType;
                        oTrnsEmployeeElementDetail.Type = Element.Type;
                        oTrnsEmployeeElementDetail.ElementValueType = Element.ValueType;
                        oTrnsEmployeeElementDetail.Value = Element.Value;
                        oTrnsEmployeeElementDetail.EmpContr = Element.EmployeeContribution;
                        oTrnsEmployeeElementDetail.EmplrContr = Element.EmployerContribution;
                        oTrnsEmployeeElementDetail.FlgActive = true;
                        oTrnsEmployeeElementDetail.FlgPaid = false;
                        oTrnsEmployeeElementDetail.SourceType = "Employee Master Add";
                        oTrnsEmployeeElementDetail.Amount = 0;
                        oTrnsEmployeeElement.TrnsEmployeeElementDetails.Add(oTrnsEmployeeElementDetail);
                    }
                    oModel.TrnsEmployeeElements.Add(oTrnsEmployeeElement);
                }
                else
                {
                    oTrnsEmployeeElement.EmployeeId = oModel.Id;
                    oTrnsEmployeeElement.FlgActive = true;
                    oTrnsEmployeeElement.UpdateDate = DateTime.Now;
                    oTrnsEmployeeElement.UpdatedBy = LoginUser;
                    var ExistingElementDetail = ExistingElementHeader.TrnsEmployeeElementDetails.Where(x => x.EmpElmtId == ExistingElementHeader.Id).ToList();
                    if (ExistingElementDetail != null && ExistingElementDetail.Count() > 0)
                    {
                        foreach (var Element in oListElement)
                        {
                            var CheckDetail = ExistingElementDetail.Where(x => x.ElementId == Element.Id).FirstOrDefault();
                            if (CheckDetail == null)
                            {
                                TrnsEmployeeElementDetail oTrnsEmployeeElementDetail = new TrnsEmployeeElementDetail();
                                oTrnsEmployeeElementDetail.ElementId = Element.Id;
                                oTrnsEmployeeElementDetail.ElementCode = Element.Code;
                                oTrnsEmployeeElementDetail.ElementDescription = Element.Description;
                                oTrnsEmployeeElementDetail.ElementType = Element.ElmtType;
                                oTrnsEmployeeElementDetail.Type = Element.Type;
                                oTrnsEmployeeElementDetail.ElementValueType = Element.ValueType;
                                oTrnsEmployeeElementDetail.Value = Element.Value;
                                oTrnsEmployeeElementDetail.EmpContr = Element.EmployeeContribution;
                                oTrnsEmployeeElementDetail.EmplrContr = Element.EmployerContribution;
                                oTrnsEmployeeElementDetail.FlgActive = true;
                                oTrnsEmployeeElementDetail.FlgPaid = false;
                                oTrnsEmployeeElementDetail.SourceType = "Employee Master Update";
                                oTrnsEmployeeElementDetail.Amount = 0;
                                //oTrnsEmployeeElement.TrnsEmployeeElementDetails.Add(oTrnsEmployeeElementDetail);                                            
                                oModel.TrnsEmployeeElements.Where(x => x.EmployeeId == oModel.Id).FirstOrDefault().TrnsEmployeeElementDetails.Add(oTrnsEmployeeElementDetail);
                            }
                        }
                    }
                }

                return oModel;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
    }
}
