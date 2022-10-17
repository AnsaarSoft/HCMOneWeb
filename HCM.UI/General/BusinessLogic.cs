using DocumentFormat.OpenXml.Math;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;

namespace HCM.UI.General
{
    public class BusinessLogic
    {       

        #region Employee Master
        public static MstEmployee ApplyPayrolStdlElement(MstEmployee oModel, IEnumerable<MstElement> oListElement, string LoginUser)
        {
            try
            {
                decimal EmpGrossSalary = (decimal)oModel.BasicSalary;
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
                        //oTrnsEmployeeElementDetail.Amount = 0;

                        decimal emprAmount = 0;
                        oTrnsEmployeeElementDetail.Amount = BusinessLogic.GetElementAmount(oModel, Element, out emprAmount);

                        if ((Element.ElmtType == "Ear" || Element.ElmtType == "Con") && Element.FlgEffectOnGross == true)
                        {
                            EmpGrossSalary = (decimal)(EmpGrossSalary + oTrnsEmployeeElementDetail.Amount);
                        }
                        else if (Element.ElmtType == "Ded" && Element.FlgEffectOnGross == true)
                        {
                            EmpGrossSalary = (decimal)(EmpGrossSalary - oTrnsEmployeeElementDetail.Amount);
                        }
                        oTrnsEmployeeElement.EmpGrossSalary = EmpGrossSalary;
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
                                if (Element.ElmtType == "Ear" || Element.ElmtType == "Ded")
                                {
                                    oTrnsEmployeeElementDetail.Amount = GetElementAmount(oModel, Element);
                                    oTrnsEmployeeElementDetail.EmpContr = 0;
                                    oTrnsEmployeeElementDetail.EmplrContr = 0;
                                }
                                else
                                {
                                    decimal emprAmount = 0;
                                    oTrnsEmployeeElementDetail.Amount = BusinessLogic.GetElementAmount(oModel, Element, out emprAmount);
                                    oTrnsEmployeeElementDetail.EmpContr = oTrnsEmployeeElementDetail.Amount;
                                    oTrnsEmployeeElementDetail.EmplrContr = emprAmount;

                                }
                                if ((Element.ElmtType == "Ear" || Element.ElmtType == "Con") && Element.FlgEffectOnGross == true)
                                {
                                    EmpGrossSalary = (decimal)(EmpGrossSalary + oTrnsEmployeeElementDetail.Amount);
                                }
                                else if (Element.ElmtType == "Ded" && Element.FlgEffectOnGross == true)
                                {
                                    EmpGrossSalary = (decimal)(EmpGrossSalary - oTrnsEmployeeElementDetail.Amount);
                                }
                                oTrnsEmployeeElement.EmpGrossSalary = EmpGrossSalary;
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

        #endregion

        #region Element Transaction

        public static decimal GetElementAmount(MstEmployee oEmp, MstElement oElement)
        {
            decimal amount = 0;
            try
            {
                if (oElement is not null)
                {
                    if (oElement.ValueType == "POB")
                    {
                        decimal basic = oEmp.BasicSalary.GetValueOrDefault();
                        decimal configvalue = oElement.Value.GetValueOrDefault();
                        amount = (basic / 100) * configvalue;
                    }
                    else if (oElement.ValueType == "POG")
                    {
                        decimal gross = oEmp.GrossSalary.GetValueOrDefault();
                        decimal configvalue = oElement.Value.GetValueOrDefault();
                        amount = (gross / 100) * configvalue;
                    }
                    else
                    {
                        amount = oElement.Value.GetValueOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return amount;
        }

        public static decimal GetElementAmount(MstEmployee oEmp, MstElement oElement, out decimal EmprAmount)
        {
            decimal amount = 0;
            EmprAmount = 0;
            try
            {
                if (oElement is not null)
                {
                    if (oElement.ValueType == "POB")
                    {
                        decimal basic = oEmp.BasicSalary.GetValueOrDefault();
                        decimal configvalue = oElement.EmployeeContribution.GetValueOrDefault();
                        decimal configvalueempr = oElement.EmployerContribution.GetValueOrDefault();

                        amount = (basic / 100) * configvalue;
                        EmprAmount = (basic / 100) * configvalueempr;
                    }
                    else if (oElement.ValueType == "POG")
                    {
                        decimal gross = oEmp.GrossSalary.GetValueOrDefault();
                        decimal configvalue = oElement.EmployeeContribution.GetValueOrDefault();
                        decimal configvalueempr = oElement.EmployerContribution.GetValueOrDefault();
                        amount = (gross / 100) * configvalue;
                        EmprAmount = (gross / 100) * configvalueempr;
                    }
                    else
                    {
                        amount = oElement.Value.GetValueOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return amount;
        }

        #endregion

        #region Employee Overtime

        public static decimal GetOverTimeAmount(MstEmployee oEmp, MstOverTime oTime, decimal TotalHour)
        {
            decimal amount = 0;
            try
            {
                if (oTime is not null)
                {
                    if (oTime.ValueType == "POB")
                    {
                        decimal basic = oEmp.BasicSalary.GetValueOrDefault();
                        decimal configvalue = oTime.Value.GetValueOrDefault();
                        decimal confighour = oTime.Hour.GetValueOrDefault();
                        decimal configMonthDays = oTime.MonthDays.GetValueOrDefault();

                        decimal perHourSalary = (((basic / 100) * configvalue) / configMonthDays) / confighour;
                        amount = perHourSalary * TotalHour;
                        return amount;
                    }
                    else if (oTime.ValueType == "POG")
                    {
                        decimal gross = oEmp.GrossSalary.GetValueOrDefault();
                        decimal configvalue = oTime.Value.GetValueOrDefault();
                        decimal confighour = oTime.Hour.GetValueOrDefault();
                        decimal configMonthDays = oTime.MonthDays.GetValueOrDefault();

                        decimal perHourSalary = (((gross / 100) * configvalue) / configMonthDays) / confighour;
                        amount = perHourSalary * TotalHour;
                        return amount;
                    }
                    else
                    {
                        amount = oTime.Value.GetValueOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return amount;
        }

        #endregion
    }
}
