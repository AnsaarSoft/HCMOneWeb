using Blazored.LocalStorage;
using HCM.UI.Interfaces.MasterElement;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using HCM.UI.Interfaces.MasterData;
using DocumentFormat.OpenXml.Office2013.Excel;

namespace HCM.UI.Pages.MasterElement
{
    public partial class ElementTransaction
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public ITrnsElementTransaction _trnsElementTransaction { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        string EmpName = "";
        int EmpPayrollID = 0;
        decimal EmpBasicSalary = 0;
        decimal EmpGrossSalary = 0;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchStringElement = "";
        private bool FilterFunc(TrnsEmployeeElementDetail element) => FilterFuncElement(element, searchStringElement);

        MstElement oModelElement = new MstElement();
        private IEnumerable<MstElement> oListElement = new List<MstElement>();

        MstEmployee oModelEmployee = new MstEmployee();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oPayrollList = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oCfgPeriodDateList = new List<CfgPeriodDate>();

        TrnsEmployeeElement oModel = new TrnsEmployeeElement();
        private IEnumerable<TrnsEmployeeElement> oList = new List<TrnsEmployeeElement>();
        private IEnumerable<TrnsEmployeeElementDetail> oListEmployeeElementDetail = new List<TrnsEmployeeElementDetail>();
        private IEnumerable<TrnsEmployeeElementDetail> oListEmployeeElementDetailRec = new List<TrnsEmployeeElementDetail>();
        private IEnumerable<TrnsEmployeeElementDetail> oListEmployeeElementDetailNonRec = new List<TrnsEmployeeElementDetail>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelEmployee = res;
                    oModel.EmployeeId = oModelEmployee.Id;
                    EmpPayrollID = (int)oModelEmployee.PayrollId;
                    EmpName = oModelEmployee.FirstName + " " + oModelEmployee.MiddleName + " " + oModelEmployee.LastName;
                    EmpBasicSalary = (decimal)oModelEmployee.BasicSalary;
                    EmpGrossSalary = (decimal)oModelEmployee.GrossSalary;
                    await GetEmpPayroll();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogElement(DialogOptions options)
        {
            try
            {
                if (oModelPayroll.Id > 0)
                {
                    EmpGrossSalary = (decimal)oModelEmployee.BasicSalary;
                    var PayrollElements = oModelPayroll.MstElementLinks;
                    var parameters = new DialogParameters();
                    parameters.Add("DialogFor", "ElementTransaction");
                    parameters.Add("PayrollElements", PayrollElements);
                    var dialog = Dialog.Show<DialogBox>("", parameters, options);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                    {
                        var res = (HashSet<MstElement>)result.Data;
                        AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                        List<MstElement> oTempList = new List<MstElement>();
                        oTempList = oListElement.ToList();
                        foreach (var item in res)
                        {
                            var Element = oListElement.Where(x => x.Id == item.Id).FirstOrDefault();
                            if (Element == null)
                            {
                                oTempList.Add(item);
                            }
                        }
                        oListElement = oTempList;
                        List<TrnsEmployeeElementDetail> oTempListDetail = new List<TrnsEmployeeElementDetail>();
                        List<TrnsEmployeeElementDetail> oTempListRec = new List<TrnsEmployeeElementDetail>();
                        if (oListElement.Where(x => x.Type == "Rec").ToList().Count > 0)
                        {
                            foreach (var RecElement in oListElement.Where(x => x.Type == "Rec").ToList())
                            {
                                TrnsEmployeeElementDetail oBJ = new TrnsEmployeeElementDetail();
                                var SetID = oListEmployeeElementDetail.Where(x => x.ElementId == RecElement.Id).FirstOrDefault();
                                if (SetID != null)
                                {
                                    oBJ.Id = SetID.Id;
                                }
                                oBJ.ElementId = RecElement.Id;
                                oBJ.ElementCode = RecElement.Code;
                                oBJ.ElementDescription = RecElement.Description;
                                oBJ.ElementType = RecElement.ElmtType;
                                oBJ.ElementValueType = RecElement.ValueType;
                                oBJ.Type = RecElement.Type;
                                oBJ.FlgActive = RecElement.FlgActive;
                                if (RecElement.ElmtType == "Ear" || RecElement.ElmtType == "Ded")
                                {
                                    oBJ.Amount = BusinessLogic.GetElementAmount(oModelEmployee, RecElement);
                                    oBJ.EmpContr = 0;
                                    oBJ.EmplrContr = 0;
                                }
                                else
                                {
                                    decimal emprAmount = 0;
                                    oBJ.Amount = BusinessLogic.GetElementAmount(oModelEmployee, RecElement, out emprAmount);
                                    oBJ.EmpContr = oBJ.Amount;
                                    oBJ.EmplrContr = emprAmount;
                                }
                                if ((RecElement.ElmtType == "Ear" || RecElement.ElmtType == "Con") && RecElement.FlgEffectOnGross == true)
                                {
                                    EmpGrossSalary = (decimal)(EmpGrossSalary + oBJ.Amount);
                                }
                                else if (RecElement.ElmtType == "Ded" && RecElement.FlgEffectOnGross == true)
                                {
                                    EmpGrossSalary = (decimal)(EmpGrossSalary - oBJ.Amount);
                                }
                                oTempListRec.Add(oBJ);
                                oTempListDetail.Add(oBJ);
                            }
                            oListEmployeeElementDetailRec = oTempListRec.ToList();
                        }
                        List<TrnsEmployeeElementDetail> oTempListNonRec = new List<TrnsEmployeeElementDetail>();
                        if (oListElement.Where(x => x.Type == "Non-Rec").ToList().Count > 0)
                        {
                            foreach (var RecElement in oListElement.Where(x => x.Type == "Non-Rec").ToList())
                            {
                                TrnsEmployeeElementDetail oBJ = new TrnsEmployeeElementDetail();
                                var SetID = oListEmployeeElementDetail.Where(x => x.ElementId == RecElement.Id).FirstOrDefault();
                                if (SetID != null)
                                {
                                    oBJ.Id = SetID.Id;
                                }
                                oBJ.ElementId = RecElement.Id;
                                oBJ.ElementCode = RecElement.Code;
                                oBJ.ElementDescription = RecElement.Description;
                                oBJ.ElementType = RecElement.ElmtType;
                                oBJ.ElementValueType = RecElement.ValueType;
                                oBJ.Type = RecElement.Type;
                                oBJ.FlgActive = RecElement.FlgActive;
                                if (RecElement.ElmtType == "Ear" || RecElement.ElmtType == "Ded")
                                {
                                    oBJ.Amount = BusinessLogic.GetElementAmount(oModelEmployee, RecElement);
                                    oBJ.EmpContr = 0;
                                    oBJ.EmplrContr = 0;
                                }
                                else
                                {
                                    decimal emprAmount = 0;
                                    oBJ.Amount = BusinessLogic.GetElementAmount(oModelEmployee, RecElement, out emprAmount);
                                    oBJ.EmpContr = oBJ.Amount;
                                    oBJ.EmplrContr = emprAmount;

                                }
                                //var CheckCurrentPeriod = oCfgPeriodDateList.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                                //if (CheckCurrentPeriod != null)
                                //{
                                    if ((RecElement.ElmtType == "Ear" || RecElement.ElmtType == "Con") && RecElement.FlgEffectOnGross == true)
                                    {
                                        EmpGrossSalary = (decimal)(EmpGrossSalary + oBJ.Amount);
                                    }
                                    else if (RecElement.ElmtType == "Ded" && RecElement.FlgEffectOnGross == true)
                                    {
                                        EmpGrossSalary = (decimal)(EmpGrossSalary - oBJ.Amount);
                                    }
                                    oTempListNonRec.Add(oBJ);
                                    oTempListDetail.Add(oBJ);
                                //}
                            }
                            oListEmployeeElementDetailNonRec = oTempListNonRec.ToList();
                        }
                        oListEmployeeElementDetail = oTempListDetail.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId) && oListEmployeeElementDetail.Count() > 0)
                {
                    oModel.EmpGrossSalary = EmpGrossSalary;
                    var SelectedHeader = oList.Where(x => x.FlgActive == true && x.EmployeeId == oModelEmployee.Id).FirstOrDefault();
                    if (SelectedHeader != null)
                    {
                        oModel.Id = SelectedHeader.Id;
                        oModel.CreateDate = SelectedHeader.CreateDate;
                        oModel.UserId = SelectedHeader.UserId;
                        oModel.FlgActive = SelectedHeader.FlgActive;
                    }
                    else
                    {
                        oModel.Id = 0;
                    }
                    oModel.TrnsEmployeeElementDetails = oListEmployeeElementDetail.ToList();
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsElementTransaction.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsElementTransaction.Update(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/ElementTransaction", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel.FlgActive = true;
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
                return res;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                return null;
            }
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/ElementTransaction", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllPayrollElements()
        {
            try
            {
                if (oModelPayroll.Id > 0)
                {
                    var PayrollElement = oModelPayroll.MstElementLinks.Select(x => x.ElementId);
                }
                oListElement = await _mstElement.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllCalendarPeriods()
        {
            try
            {
                await Task.Delay(1);
                if (oModelPayroll.Id > 0)
                {
                    oCfgPeriodDateList = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async Task GetEmpPayroll()
        {
            try
            {
                oPayrollList = await _CfgPayrollDefination.GetAllData();
                oModelPayroll = oPayrollList.Where(x => x.Id == EmpPayrollID).FirstOrDefault();
                await GetAllCalendarPeriods();
                await GetAllEmpElementTransaction();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmpElementTransaction()
        {
            try
            {
                oList = await _trnsElementTransaction.GetAllData();
                if (oList != null && oList.Count() > 0)
                {
                    var SelectedHeader = oList.Where(x => x.FlgActive == true && x.EmployeeId == oModelEmployee.Id).FirstOrDefault();
                    EmpGrossSalary = (decimal)SelectedHeader.EmpGrossSalary;
                    oListEmployeeElementDetail = SelectedHeader.TrnsEmployeeElementDetails;
                    oListEmployeeElementDetailRec = oListEmployeeElementDetail.Where(x => x.Type == "Rec").ToList();
                    oListEmployeeElementDetailNonRec = oListEmployeeElementDetail.Where(x => x.Type == "Non-Rec").ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFuncElement(TrnsEmployeeElementDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.ElmtType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.Description.Equals(searchString1))
            //    return true;
            return false;
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    oModel.FlgActive = true;
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion
    }
}