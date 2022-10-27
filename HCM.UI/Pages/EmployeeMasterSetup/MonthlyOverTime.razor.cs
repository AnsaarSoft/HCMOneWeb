using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
//using HCM.API.Interfaces.MasterData;
//using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using MudBlazor;
using System.Reflection;
using System.Collections.Immutable;
using static MudBlazor.CategoryTypes;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Forms;
using ClosedXML.Excel;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using System.Linq;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class MonthlyOverTime
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ITrnsSingleEntryOtrequest _TrnsSingleEntryOtrequest { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public ITrnsEmployeeOverTime _TrnsEmployeeOverTime { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
       // public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        //string EmpName = "";
        //private decimal Amount;
        //private decimal Hours;
        //private string PayrollPeriodstr = "Select Period";
       // private string FullName = "";
        private string searchString1 = "";

        string AlphanumericMask = @"^[a-zA-Z0-9_]*$";
        IList<IBrowserFile> excelSheet = new List<IBrowserFile>();
        private bool FilterFuncTrnsSingleEntryOtdetail(TrnsSingleEntryOtdetail element) => FilterFuncTrnsSingleEntryOtdetail(element, searchString1);

        VMMonthlyOverTime vMMonthlyOverTime = new VMMonthlyOverTime();

        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        MstOverTime oModelmstOvertime = new MstOverTime();
        private IEnumerable<MstOverTime> oListmstOverTime = new List<MstOverTime>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        TrnsEmployeeOvertime oModelEmployeeOvertime = new TrnsEmployeeOvertime();
        private IEnumerable<TrnsEmployeeOvertime> oListEmployeeOvertime = new List<TrnsEmployeeOvertime>();
        List<TrnsEmployeeOvertime> oListEmployeeOt = new List<TrnsEmployeeOvertime>();

        TrnsSingleEntryOtrequest oModel = new TrnsSingleEntryOtrequest();
        private IEnumerable<TrnsSingleEntryOtrequest> oList = new List<TrnsSingleEntryOtrequest>();

        TrnsSingleEntryOtdetail oModelTrnsSingleEntryOtdetail = new TrnsSingleEntryOtdetail();
        private IEnumerable<TrnsSingleEntryOtdetail> oListdetail = new List<TrnsSingleEntryOtdetail>();
        private List<TrnsSingleEntryOtdetail> oListTrnsSingleEntryOvertimedetail = new List<TrnsSingleEntryOtdetail>();
        List<TrnsSingleEntryOtdetail> oTrnsTrnsSingleEntryOtdetailAddList = new List<TrnsSingleEntryOtdetail>();
        List<TrnsSingleEntryOtdetail> oTrnsTrnsSingleEntryOtdetailUpdateList = new List<TrnsSingleEntryOtdetail>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private List<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        CfgPeriodDate oModelPayrollPeriod = new CfgPeriodDate();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        private TrnsSingleEntryOtdetail selectedItem1 = null;
     //   private HashSet<TrnsSingleEntryOtdetail> selectedItems1 = new HashSet<TrnsSingleEntryOtdetail>();
        // DateTime? docdate;
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion

        #region Functions
        private async Task<IEnumerable<MstOverTime>> SearchOvertime(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListmstOverTime.Select(o => new MstOverTime
                    {
                        Id = o.Id,
                        Code = o.Code,
                        Description = o.Description,
                    }).ToList();
                var res = oListmstOverTime.Where(x => x.Code.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstOverTime
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private bool FilterFuncTrnsSingleEntryOtdetail(TrnsSingleEntryOtdetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.OvertimeId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private async Task<IEnumerable<MstEmployee>> SearchEmployeeFrom(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();
                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstEmployee>> SearchEmployeeTo(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();
                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstDepartment>> SearchDepartment(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDepartment.Select(o => new MstDepartment
                    {
                        Id = o.Id,
                        DeptName = o.DeptName,
                    }).ToList();
                var res = oListDepartment.Where(x => x.DeptName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDepartment
                {
                    Id = x.Id,
                    DeptName = x.DeptName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstDesignation>> SearchDesignation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDesignation.Select(o => new MstDesignation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListDesignation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDesignation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstBranch>> SearchBranch(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListBranch.Select(o => new MstBranch
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListBranch.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstBranch
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstLocation>> SearchLocation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListLocation.Select(o => new MstLocation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListLocation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstLocation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "MonthlyOT");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsSingleEntryOtrequest)result.Data;
                    oModel = res;
                    oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModel.Ottype).FirstOrDefault();
                    oListEmployeeOt.Clear();
                    foreach (var item in oModel.TrnsSingleEntryOtdetails)
                    {
                        //oModelPayroll = oListPayroll.Where(x => x.Id == item.PayrollId).FirstOrDefault();
                        //oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                        //var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                        if (oModel.Id !=0)
                        {
                            item.UpdatedBy = LoginUser;
                            item.UpdatedDate = DateTime.Now;
                        }

                        TrnsEmployeeOvertime trnsEmployeeOvertime = new TrnsEmployeeOvertime();
                        trnsEmployeeOvertime.EmployeeId = item.EmpId;
                        trnsEmployeeOvertime.PeriodId = item.Periodid;
                        trnsEmployeeOvertime.PeriodName = item.PeriodName;
                        trnsEmployeeOvertime.UserId = LoginUser;
                        trnsEmployeeOvertime.CreateDate = DateTime.Now;
                        TrnsEmployeeOvertimeDetail trnsEmployeeOvertimeDetail = new TrnsEmployeeOvertimeDetail();
                        trnsEmployeeOvertimeDetail.OvertimeId = item.OverTimeId;
                        trnsEmployeeOvertimeDetail.Othours = item.Hours;
                        trnsEmployeeOvertimeDetail.Amount = item.Amount;


                        trnsEmployeeOvertimeDetail.FlgActive = item.FlgActive;
                        trnsEmployeeOvertimeDetail.CreateDate = DateTime.Now;
                        trnsEmployeeOvertimeDetail.UserId = LoginUser;
                        trnsEmployeeOvertime.TrnsEmployeeOvertimeDetails.Add(trnsEmployeeOvertimeDetail);
                        oListEmployeeOt.Add(trnsEmployeeOvertime);
                    }
                    vMMonthlyOverTime.TrnsEmployeeOvertime = oListEmployeeOt;
                    vMMonthlyOverTime.TrnsSingleEntryOtrequest = oModel;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllMonthlyOT()
        {
            try
            {
                oList = await _TrnsSingleEntryOtrequest.GetAllData();
                oList = oList.ToList();
                // oListdetail = (IEnumerable<TrnsSingleEntryOtdetail>)oList.Select(x => x.TrnsSingleEntryOtdetails).ToList();
                //oListdetail = (IEnumerable<TrnsSingleEntryOtdetail>)Detail;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private Task SetDocNo()
        {
            try
            {
                oModel.DocNum = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private async Task GetAllEmployees()
        {
            try
            {
                oListEmployee = await _mstEmployeeMaster.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmployeeOvertime()
        {
            try
            {
                oListEmployeeOvertime = await _TrnsEmployeeOverTime.GetAllData();
                oListEmployeeOvertime = oListEmployeeOvertime.ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllOvertime()
        {
            try
            {
                oListmstOverTime = await _mstOverTime.GetAllData();
                oListmstOverTime = oListmstOverTime.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmployeesPayroll()
        {
            try
            {
                oListPayroll = await _CfgPayrollDefination.GetAllData();
                oListPayroll = oListPayroll.Where(x => x.FlgActive == true).ToList();


                //foreach (var PayrollElement in oListPayrollElementLink)
                //{
                //    var SelectedElement = oElementListPer.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                //    if (SelectedElement != null)
                //    {
                //        oListTemp.Add(SelectedElement);
                //    }
                //}
                //oElementListFilter = oListTemp.ToList();

                //oModelPayroll.PayrollId = SelectedPayroll.Id;
                //oModelPayroll.PayrollCode = SelectedPayroll.PayrollName;
                //oListPayrollPeriod = SelectedPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModel.PayrollId).ToList();
                //var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                //oModel.PaysInPeriodId = SelectedPeriod.Id;
                //oModel.PaysInPeriodCode = SelectedPeriod.PeriodName;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllDepartments()
        {
            try
            {
                oListDepartment = await _mstDepartment.GetAllData();
                //Where(x => x.FlgActive == true).
                oListDepartment = oListDepartment.ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLocation()
        {
            try
            {
                oListLocation = await _mstLocation.GetAllData();
                //Where(x => x.FlgActive == true).
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllBranch()
        {
            try
            {
                oListBranch = await _mstBranch.GetAllData();
                oListBranch = oListBranch.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllDesignation()
        {
            try
            {
                oListDesignation = await _mstDesignation.GetAllData();
                //Where(x => x.FlgActive == true).
                oListDesignation = oListDesignation.ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task SearchCriteria()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);

                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId))
                    && (oModelmstOvertime.Id != null && oModelmstOvertime.Id > 0)
                    || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName) || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    || !string.IsNullOrWhiteSpace(oModelDesignation.Description) || !string.IsNullOrWhiteSpace(oModelBranch.Description)
                    )
                {
                    oListFilteredEmployee = oListEmployee.Where(
                        x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0
                        && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                        || x.DepartmentName == oModelDepartment.DeptName
                        || x.LocationName == oModelLocation.Description
                        || x.BranchName == oModelBranch.Description
                        || x.DesignationName == oModelDesignation.Description
                        ).ToList();
                    if (oListFilteredEmployee.Count() > 0)
                    {
                        foreach (var item in oListFilteredEmployee)
                        {
                            TrnsSingleEntryOtdetail oTrnsSingleEntryOtdetail = new TrnsSingleEntryOtdetail();
                            oModelPayroll = oListPayroll.Where(x => x.Id == item.PayrollId).FirstOrDefault();
                            oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                            var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();

                            oTrnsSingleEntryOtdetail.EmpId = item.Id;
                            oTrnsSingleEntryOtdetail.EmpName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                            oTrnsSingleEntryOtdetail.OverTimeId = oModelmstOvertime.Id;
                            oTrnsSingleEntryOtdetail.OverTimeDescription = oModelmstOvertime.Description;
                            oTrnsSingleEntryOtdetail.PayrollId = item.PayrollId;
                            oTrnsSingleEntryOtdetail.PayrollName = item.PayrollName;
                            oTrnsSingleEntryOtdetail.Periodid = SelectedPeriod.Id;
                            oTrnsSingleEntryOtdetail.PeriodName = SelectedPeriod.PeriodName;
                            oTrnsSingleEntryOtdetail.FlgActive = true;
                            oModel.Ottype = oModelmstOvertime.Id;
                            oModel.OttypeDescription = oModelmstOvertime.Description;

                            //oModel.PeriodId= SelectedPeriod.Id;
                            //oModel.PayrollId = item.PayrollId;

                            oModel.TrnsSingleEntryOtdetails.Add(oTrnsSingleEntryOtdetail);
                        }
                    }
                    else
                    {
                        Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please Select Filteration.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/MonthlyOverTime", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task DeleteFromFilter(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<TrnsSingleEntryOtdetail> oListTrnsSingleEntryOtdetail = new List<TrnsSingleEntryOtdetail>();
                oListTrnsSingleEntryOtdetail = oModel.TrnsSingleEntryOtdetails.ToList();
                if (oModel.TrnsSingleEntryOtdetails.Count() > 0)
                {
                    var FilterRecord = oModel.TrnsSingleEntryOtdetails.Where(x => x.Id == ID).FirstOrDefault();
                    oListTrnsSingleEntryOtdetail.Remove(FilterRecord);
                    oModel.TrnsSingleEntryOtdetails = oListTrnsSingleEntryOtdetail;
                }
                //  List<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOTDtl = new List<TrnsEmployeeOvertimeDetail>();
                //oListTrnsEmployeeOTDtl = oListTrnsEmployeeOvertimeDetail.ToList();
                //if (oListTrnsEmployeeOvertimeDetail.Count() > 0)
                //{
                //    var FilterRecord = oListTrnsEmployeeOvertimeDetail.Where(x => x.Id == ID).FirstOrDefault();
                //    oListTrnsEmployeeOTDtl.Remove(FilterRecord);
                //    oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOTDtl;
                //}
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task<ApiResponseModel> CalculateOverTime()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (oModel.TrnsSingleEntryOtdetails.Count > 0)
                {
                    foreach (var item in oModel.TrnsSingleEntryOtdetails)
                    {
                        if (item.Hours != null && item.Hours > 0 && item.FlgActive == true)
                        {

                            oModelMstEmployee = oListEmployee.Where(x => x.Id == item.EmpId).FirstOrDefault();
                            oModelmstOvertime = oListmstOverTime.Where(x => x.Id == item.OverTimeId).FirstOrDefault();
                            item.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, (decimal)item.Hours);
                            if (oModel.Id == 0)
                            {
                                item.CreatedBy = LoginUser;
                                item.CreatedDate = DateTime.Now;
                            }
                            else
                            {
                                item.UpdatedBy = LoginUser;
                                item.UpdatedDate = DateTime.Now;
                            }
                        }
                        else
                        {
                            Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                    }
                }
                else
                {
                    Snackbar.Add("Please Select Filteration.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        public void CalculateAmount(int empid)
      {
            try
            {
         
                //int empid = (int)selectedItem1.EmpId;
                oModelMstEmployee = oListEmployee.Where(x => x.Id == empid).FirstOrDefault();

                 oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModelmstOvertime.Id).FirstOrDefault();
                //oModelTrnsSingleEntryOtdetail.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Convert.ToDecimal(hour));
                var hour = oModel.TrnsSingleEntryOtdetails.Where(x => x.EmpId == empid).Select(x => x.Hours).FirstOrDefault();
                    var amnt = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Convert.ToDecimal(hour));
                oModel.TrnsSingleEntryOtdetails.Where(x => x.EmpId == empid).FirstOrDefault().Amount = amnt;

                //selectedItem1.Amount = selectedItem1.Hours + 10;
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

                if (oModel.TrnsSingleEntryOtdetails.Count > 0)
                {
                    int LineNumber = 1;
                    foreach (var item in oModel.TrnsSingleEntryOtdetails)
                    {
                        if (item.Hours.GetValueOrDefault() == 0)
                        {
                            res.Message = $"Hour is mandatory. Line Number {LineNumber}";
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Info; });
                            Loading = false;
                            return res;
                        }
                        if (item.Amount.GetValueOrDefault() == 0)
                        {
                            res.Message = $"Hour Calculation is mandatory. Line Number {LineNumber}";
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Info; });
                            Loading = false;
                            return res;
                        }
                        if (oModel.Id == 0)
                        {
                            item.CreatedBy = LoginUser;
                            item.CreatedDate = DateTime.Now;
                        }
                        else
                        {
                            item.UpdatedBy = LoginUser;
                            item.UpdatedDate = DateTime.Now;
                        }
                        LineNumber++;
                    }

                    if (oModel.Id == 0)
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _TrnsSingleEntryOtrequest.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _TrnsSingleEntryOtrequest.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/MonthlyOverTime", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please Select Filteration.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> Post()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                if (oModel.Id != 0)
                {
                    vMMonthlyOverTime.TrnsSingleEntryOtrequest.DocStatus = "Closed";
                    vMMonthlyOverTime.TrnsSingleEntryOtrequest.UpdatedBy = LoginUser;
                    //vMMonthlyOverTime.TrnsEmployeeOvertime.Add(oModelEmployeeOvertime); 
                    res = await _TrnsSingleEntryOtrequest.InsertUpdate(vMMonthlyOverTime);
                }
                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/MonthlyOverTime", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> Void()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                oListEmployeeOt.Clear();
                foreach (var item in oModel.TrnsSingleEntryOtdetails)
                {
                    //oModelPayroll = oListPayroll.Where(x => x.Id == item.PayrollId).FirstOrDefault();
                    //oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                    //var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                    TrnsEmployeeOvertime trnsEmployeeOvertime = new TrnsEmployeeOvertime();
                    trnsEmployeeOvertime = oListEmployeeOvertime.Where(x => x.EmployeeId == item.EmpId && x.PeriodId == item.Periodid).FirstOrDefault();
                    trnsEmployeeOvertime.UpdateDate = DateTime.Now;
                    trnsEmployeeOvertime.UpdatedBy = LoginUser;
                    foreach (var item1 in trnsEmployeeOvertime.TrnsEmployeeOvertimeDetails)
                    {
                        item1.FlgActive = false;
                        item1.UpdateDate = DateTime.Now;
                        item1.UpdatedBy = LoginUser;
                    }
                    oListEmployeeOt.Add(trnsEmployeeOvertime);
                }


                if (oModel.Id != 0)
                {
                    res = await _TrnsEmployeeOverTime.Updatelist(oListEmployeeOt);
                }
                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/MonthlyOverTime", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            try
            {
                Loading = true;
                if (excelSheet.Count > 0)
                {
                    Snackbar.Add("Template already selected, refresh the page for new template to import.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                else
                {
                    var TemplateFile = e.File.Name;
                    excelSheet.Add(e.File);
                    //if (ModuleType > 0)
                    //{
                    if (!string.IsNullOrWhiteSpace(TemplateFile))
                    {
                        Snackbar.Add("Please wait template uploading in process...", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await FillMonthlyOverTimeTemplateGrid();

                    }
                    else
                    {
                        Snackbar.Add("Select template to import", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        excelSheet.Clear();
                    }
                    //}
                    //else
                    //{
                    //    Snackbar.Add("Select Module to import", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //    excelSheet.Clear();
                    //}
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        private async Task FillMonthlyOverTimeTemplateGrid()
        {
            try
            {

                Loading = true;
                _ = InvokeAsync(StateHasChanged);
                await Task.Delay(1);
                bool IsForUpdate = false;
                var TemplateFile = excelSheet.Select(x => x.Name).FirstOrDefault();
                TemplateFile = Path.GetFullPath("wwwroot\\Templates\\" + TemplateFile);
                if (!string.IsNullOrWhiteSpace(TemplateFile))
                {
                    Stream stream = excelSheet.FirstOrDefault().OpenReadStream();
                    FileStream fs = File.Create(TemplateFile);
                    await stream.CopyToAsync(fs);
                    stream.Close();
                    fs.Close();
                    using var workBook = new XLWorkbook(TemplateFile);
                    var ws = workBook.Worksheet("MonthlyOverTimeTemplate");
                    // var ws = workBook.Worksheet("MonthlyOverTimeTemplate");

                    Type type = typeof(VMMonthlyOTImport);
                    int NumberOfRecords = type.GetProperties().Length;
                    var a = ws.Rows().Count();
                    // string CustomPropertyName = "";
                    for (int i = 2; i <= ws.Rows().Count() - 1; i++)
                    {

                        IsForUpdate = false;
                        oModelTrnsSingleEntryOtdetail = new TrnsSingleEntryOtdetail();
                        int empid = 0;
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;
                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelTrnsSingleEntryOtrequest." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string)) //(PropertyInfo.PropertyType == typeof(Int32))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "EmpCode")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }

                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmpCode")
                                {
                                    // var GetEmp = oListEmployee.Where(x => x.EmpId == StringValue).FirstOrDefault();
                                    // var detail = oList.Select(x => x.TrnsSingleEntryOtdetails).ToList();
                                    //var CheckList1 = detail.Where(x=>)
                                    //oList.Where(x => x.id == x.TrnsSingleEntryOtdetails.Where(x=>x.EmpId == GetEmp.Id && x.OverTimeId == ).Select(x=>x.SingleEntryOtid)).FirstOrDefault();

                                    var CheckList = oListEmployee.Where(x => x.EmpId == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelTrnsSingleEntryOtdetail.EmpId = CheckList.Id;
                                        oModelTrnsSingleEntryOtdetail.EmpName = CheckList.FirstName + " " + CheckList.MiddleName + " " + CheckList.LastName;

                                        oModelPayroll = oListPayroll.Where(x => x.Id == CheckList.PayrollId).FirstOrDefault();
                                        oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                                        var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();

                                        oModelTrnsSingleEntryOtdetail.PayrollId = CheckList.PayrollId;
                                        oModelTrnsSingleEntryOtdetail.PayrollName = CheckList.PayrollName;
                                        oModelTrnsSingleEntryOtdetail.Periodid = SelectedPeriod.Id;
                                        oModelTrnsSingleEntryOtdetail.PeriodName = SelectedPeriod.PeriodName;


                                        empid = CheckList.Id;
                                        IsForUpdate = true;
                                        PropertyName = "EmpId";
                                        oModelTrnsSingleEntryOtdetail.GetType().GetProperty(PropertyName).SetValue(oModelTrnsSingleEntryOtdetail, Convert.ToInt32(empid), null);
                                        continue;
                                    }
                                    else
                                    {
                                        //Skip the line if EmpCode has Not in master
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "OverTimeType")
                                {
                                    var CheckList = oListmstOverTime.Where(x => x.Description == StringValue).FirstOrDefault();
                                    // var CheckList1 = oList.Where(x => x.TrnsSingleEntryOtdetails.Where(x=>x.OverTimeId == CheckList.Id)).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModel.Ottype = CheckList.Id;
                                        oModel.OttypeDescription = CheckList.Description;
                                        oModelTrnsSingleEntryOtdetail.OverTimeId = CheckList.Id;
                                        oModelTrnsSingleEntryOtdetail.OverTimeDescription = CheckList.Description;
                                        PropertyName = "OverTimeId";
                                        oModelTrnsSingleEntryOtdetail.GetType().GetProperty(PropertyName).SetValue(oModelTrnsSingleEntryOtdetail, oModelTrnsSingleEntryOtdetail.OverTimeId, null);
                                        continue;
                                    }
                                }
                            }
                            else if (PropertyInfo.PropertyType == typeof(decimal))
                            {
                                if (PropertyName == "TotalHours")
                                {

                                    var hour = Convert.ToDecimal(ws.Cell(i, j).Value.ToString());
                                    if (hour != null && hour > 0)
                                    {
                                        oModelTrnsSingleEntryOtdetail.FlgActive = true;

                                        oModelMstEmployee = oListEmployee.Where(x => x.Id == empid).FirstOrDefault();
                                        oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModel.Ottype).FirstOrDefault();
                                        oModelTrnsSingleEntryOtdetail.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Convert.ToDecimal(hour));

                                        PropertyName = "Hours";
                                        oModelTrnsSingleEntryOtdetail.GetType().GetProperty(PropertyName).SetValue(oModelTrnsSingleEntryOtdetail, Convert.ToDecimal(hour), null);
                                        continue;
                                    }
                                }
                            }
                        }
                        oTrnsTrnsSingleEntryOtdetailAddList.Add(oModelTrnsSingleEntryOtdetail);
                       // if (oModelTrnsSingleEntryOtdetail.Id > 0 && !IsForUpdate)
                        //{

                          //  var CheckDuplicate = oTrnsTrnsSingleEntryOtdetailAddList;//.Where(x => x.SingleEntryOtid == oMode&& x.PunchedDate == oModelTrnsTempAttendance.PunchedDate
                            //                           && x.InOut == oModelTrnsTempAttendance.InOut).FirstOrDefault();
                            //if (CheckDuplicate == null)
                            //{
                            //    oTrnsTempAttendanceAddList.Add(oModelTrnsTempAttendance);
                            //}
                        //}//!string.IsNullOrWhiteSpace(oModelTrnsTempAttendance.FkempId)
                         //    else if (oModelTrnsTempAttendance.FkempId > 0 && IsForUpdate)
                         //    {
                         //        var CheckDuplicate = oTrnsTempAttendanceUpdateList.Where(x => x.FkempId == oModelTrnsTempAttendance.FkempId && x.PunchedDate == oModelTrnsTempAttendance.PunchedDate
                         //                                   && x.InOut == oModelTrnsTempAttendance.InOut).FirstOrDefault();
                         //        if (CheckDuplicate == null)
                         //        {
                         //            oTrnsTempAttendanceUpdateList.Add(oModelTrnsTempAttendance);
                         //        }
                         //    }
                    }
                    //if (oTrnsTempAttendanceUpdateList.Count >= 0 && oTrnsTempAttendanceAddList.Count >= 0)
                    //{
                    //    oListTrnsTempAttendanceGridTemp.AddRange(oTrnsTempAttendanceAddList);
                    //    oListTrnsTempAttendanceGridTemp.AddRange(oTrnsTempAttendanceUpdateList);
                    //}
                    ////else if(!IsForUpdate && oDepartmentAddList.Count > 0)
                    ////{
                    ////        oListDepartmentGridTemp.AddRange(oDepartmentAddList);
                    ////}

                    //oModel.TrnsSingleEntryOtdetails.Add(oModelTrnsSingleEntryOtdetail);
                    oModel.TrnsSingleEntryOtdetails = oTrnsTrnsSingleEntryOtdetailAddList;

                    File.Delete(TemplateFile);
                }
            }

            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
            _ = InvokeAsync(StateHasChanged);
        }
        private async Task MonthlyOverTimeTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "MonthlyOverTimeTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(VMMonthlyOTImport);
                //int SetColumnIndex = 0;
                int prvNum = 0, NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {

                    var PropertyName = type.GetProperties()[i].Name;
                    //if (PropertyName == "FkempId")
                    //{
                    //    PropertyName = "EmpCode";
                    //}
                    //if (PropertyName == "EmpId" || PropertyName == "FlgProcessed" || PropertyName == "CreatedDate" || PropertyName == "CreatedBy" || PropertyName == "UpdatedDate" || PropertyName == "UpdatedBy")
                    //{
                    //    continue;
                    //}
                    //if ((prvNum+1)!= i)
                    //{
                    //    ws.Cell(1, (prvNum + 1)).Value = PropertyName;
                    //    ws.Cell(1, (prvNum + 1)).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                    //    prvNum = i;
                    //    continue;
                    //}
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;

                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        #endregion

        #region Events
        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    oModel.DocStatus = "Draft";
                    await GetAllMonthlyOT();
                    await GetAllEmployeeOvertime();
                    await SetDocNo();
                    await GetAllEmployees();
                    await GetAllEmployeesPayroll();
                    await GetAllOvertime();
                    await GetAllBranch();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
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

