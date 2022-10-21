using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
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
using System.Collections.Immutable;
using static MudBlazor.CategoryTypes;


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
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsFlg = false;

        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        string EmpName = "";
        private decimal Amount;
        private decimal Hours;
        private string PayrollPeriodstr = "Select Period";
        private string FullName = "";
        private string searchString1 = "";

        private bool FilterFuncTrnsSingleEntryOtdetail(TrnsSingleEntryOtdetail element) => FilterFuncTrnsSingleEntryOtdetail(element, searchString1);


        MstEmployee oModelMstEmployee = new MstEmployee();
        // private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstOverTime oModelmstOvertime = new MstOverTime();
        private IEnumerable<MstOverTime> oListmstOverTime = new List<MstOverTime>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        TrnsSingleEntryOtrequest oModel = new TrnsSingleEntryOtrequest();
        private IEnumerable<TrnsSingleEntryOtrequest> oList = new List<TrnsSingleEntryOtrequest>();

        TrnsSingleEntryOtdetail oModelTrnsSingleEntryOtdetail = new TrnsSingleEntryOtdetail();
        private IEnumerable<TrnsSingleEntryOtdetail> oListTrnsSingleEntryOtdetail = new List<TrnsSingleEntryOtdetail>();
        private List<TrnsSingleEntryOtdetail> oListTrnsSingleEntryOvertimedetail = new List<TrnsSingleEntryOtdetail>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        //CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        //private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        //private IEnumerable<MstElementLink> oMstElementLinkList = new List<MstElementLink>();


        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private List<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        CfgPeriodDate oModelPayrollPeriod = new CfgPeriodDate();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        DateTime? docdate;
        TimeSpan? timefrom = new TimeSpan();
        TimeSpan? timeto = new TimeSpan();
        string createby, updateby;
        DateTime createdate, updatedate;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

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
                    //var res = (MstEmployee)result.Data;
                    //oModelMstEmployee = res;
                    //oModel.EmployeeId = oModelMstEmployee.Id;

                    //EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;
                    //var EmpDetail = oListEmployee.Where(x => x.EmpId == oModelMstEmployee.EmpId).FirstOrDefault();
                    //oModelPayroll = oListPayroll.Where(x => x.Id == EmpDetail.PayrollId).FirstOrDefault();
                    //CfgPeriodDate mstPayrollPeriod = new CfgPeriodDate();
                    //oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();

                    //// FullName = EmpDetail.FirstName + " " + EmpDetail.MiddleName + " " + EmpDetail.LastName;
                    //oModelMstEmployee.PayrollName = EmpDetail.PayrollName;
                    //oModelMstEmployee = EmpDetail;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsEmployeeOverTime");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsEmployeeOvertime)result.Data;
                    //oModel = res;
                    //oModelMstEmployee = oListEmployee.Where(x => x.Id == oModel.EmployeeId).FirstOrDefault();
                    //EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;

                    // oListTrnsEmployeeOvertimeDetail = oModel.TrnsEmployeeOvertimeDetails.ToList();
                    //oModelTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOvertimeDetail.Where(x => x.EmpOvertimeId == oModel.Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
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
        private async Task<IEnumerable<MstEmployee>> SearchEmployee(string value)
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
        private async Task FillEmployeeCode(MstEmployee oModelMstEmpCode)
        {
            try
            {
                if (oModelMstEmpCode != null)
                {
                    var EmpDetail = oListEmployee.Where(x => x.EmpId == oModelMstEmpCode.EmpId).FirstOrDefault();
                    oModelPayroll = oListPayroll.Where(x => x.Id == EmpDetail.PayrollId).FirstOrDefault();
                    CfgPeriodDate mstPayrollPeriod = new CfgPeriodDate();
                    oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                    //DateTime dt = (DateTime)oPayroll.FirstPeriodEndDt;
                    FullName = EmpDetail.FirstName + " " + EmpDetail.MiddleName + " " + EmpDetail.LastName;
                    oModelMstEmployee.PayrollName = EmpDetail.PayrollName;
                    oModelMstEmployee = EmpDetail;

                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
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
        private async Task<IEnumerable<CfgPayrollDefination>> SearchPayroll(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPayroll.Select(o => new CfgPayrollDefination
                    {
                        Id = o.Id,
                        PayrollName = o.PayrollName,
                        MstElementLinks = o.MstElementLinks,
                    }).ToList();
                var res = oListPayroll.Where(x => x.PayrollName.ToUpper().Contains(value.ToUpper())).ToList();


                return res.Select(x => new CfgPayrollDefination
                {
                    Id = x.Id,
                    PayrollName = x.PayrollName,
                    MstElementLinks = x.MstElementLinks,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task FillPayrollCode(CfgPayrollDefination CfgPayrollDefination)
        {
            try
            {
                if (CfgPayrollDefination != null)
                {
                    var Selectedpayroll = oListPayroll.Where(x => x.Id == CfgPayrollDefination.Id).FirstOrDefault();
                    oListPayrollPeriod = Selectedpayroll.CfgPeriodDates.ToList();
                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        private async Task SearchCriteria()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);

                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId))
                    &&(oModelmstOvertime.Id != null || oModelmstOvertime.Id > 0)
                    || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName) || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    )
                {
                    oListFilteredEmployee = oListEmployee.Where(
                        x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0
                        && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                        || x.DepartmentName == oModelDepartment.DeptName
                        || x.LocationName == oModelLocation.Description
                        // || x.PayrollName == oModelPayroll.PayrollName
                        //|| x. == oModelPayroll.PayrollName
                        ).ToList();


                    //
                    if (oListFilteredEmployee.Count() > 0)
                    {
                        foreach (var item in oListFilteredEmployee)
                        {
                            TrnsSingleEntryOtdetail oTrnsSingleEntryOtdetail = new TrnsSingleEntryOtdetail();
                            oTrnsSingleEntryOtdetail.EmpId = item.Id;
                            oTrnsSingleEntryOtdetail.EmpName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                            oTrnsSingleEntryOtdetail.OverTimeId = oModelmstOvertime.Id;
                            oModel.TrnsSingleEntryOtdetails.Add(oTrnsSingleEntryOtdetail);
                            //    oDetailListadd.Add(deitaolmodel);
                        }
                        // oListFilteredEmployeeTransferDetail = oDetailListadd.ToList();

                    }
                    else
                    {
                        Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Select Employee Filteration.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
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
        private async Task CalHour()
        {
            try
            {
                await Task.Delay(1);
                if ((timefrom != null && timeto != null))
                {

                    string totalhour = (timeto - timefrom).ToString();
                    Hours = Convert.ToDecimal(TimeSpan.Parse(totalhour).TotalHours);
                }



            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/EmployeeOverTime", forceLoad: true);
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
                List<TrnsEmployeeOvertimeDetail> oListTrnsEmployeeOTDtl = new List<TrnsEmployeeOvertimeDetail>();
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
        //private async Task<ApiResponseModel> AddList()
        //{
        //    try
        //    {

        //        Loading = true;
        //        var res = new ApiResponseModel();
        //        await Task.Delay(3);


        //        //  oModel.EmployeeId = oModelMstEmployee.Id;
        //        TrnsEmployeeOvertimeDetail trnsEmployeeOvertimeDetail = new TrnsEmployeeOvertimeDetail();
        //        trnsEmployeeOvertimeDetail.OvertimeId = oModelmstOvertime.Id;
        //        trnsEmployeeOvertimeDetail.EmpOvertimeId = oModel.Id;
        //        trnsEmployeeOvertimeDetail.Otdate = docdate;
        //        trnsEmployeeOvertimeDetail.FromTime = timefrom.ToString();
        //        trnsEmployeeOvertimeDetail.ToTime = timeto.ToString();
        //        trnsEmployeeOvertimeDetail.Othours = Hours;
        //        trnsEmployeeOvertimeDetail.FlgActive = IsFlg;
        //        oModelmstOvertime = oListmstOverTime.Where(x => x.Id == oModelmstOvertime.Id).FirstOrDefault();
        //        trnsEmployeeOvertimeDetail.Amount = BusinessLogic.GetOverTimeAmount(oModelMstEmployee, oModelmstOvertime, Hours);

        //        if ((oModel.PeriodId != null)
        //            && (trnsEmployeeOvertimeDetail.OvertimeId != null && trnsEmployeeOvertimeDetail.OvertimeId > 0)
        //            && (trnsEmployeeOvertimeDetail.Otdate != null)
        //            && (trnsEmployeeOvertimeDetail.Othours != null && trnsEmployeeOvertimeDetail.Othours > 0)
        //            && (trnsEmployeeOvertimeDetail.Amount != null && trnsEmployeeOvertimeDetail.Amount > 0)
        //            && (trnsEmployeeOvertimeDetail.FlgActive != null && trnsEmployeeOvertimeDetail.FlgActive != false))
        //        {
        //            if (oModel.Id != 0)
        //            {
        //                trnsEmployeeOvertimeDetail.UserId = createby  ;
        //                trnsEmployeeOvertimeDetail.CreateDate = createdate;
        //                //trnsEmployeeOvertimeDetail.UpdatedBy = updateby  ;
        //                //trnsEmployeeOvertimeDetail.UpdateDate = updatedate;
        //            }


        //            oListTrnsEmployeeOtDetail.Add(trnsEmployeeOvertimeDetail);
        //            oListTrnsEmployeeOvertimeDetail = oListTrnsEmployeeOtDetail.ToList();
        //            docdate = DateTime.Now;
        //            timefrom = new TimeSpan(0, 0, 0);
        //            timeto = new TimeSpan(0, 0, 0);
        //            Hours = 0;
        //            Amount = 0;
        //            IsFlg = false;
        //            //oModelTrnsEmployeeOvertimeDetail = null;
        //        }

        //        else
        //        {
        //            Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
        //        }




        //        Loading = false;
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        Loading = false;
        //        return null;
        //    }
        //}
        private async Task<ApiResponseModel> Save()
        {
            try
            {

                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);


                //if (oListTrnsEmployeeOvertimeDetail.Count() > 0)
                //{
                //    oModel.EmployeeId = oModelMstEmployee.Id;

                //    oListTrnsEmployeeOtDetail.Clear();
                //    foreach (var item in oListTrnsEmployeeOvertimeDetail)
                //    {
                //        if (oModel.Id == 0)
                //        {
                //            item.UserId = LoginUser;
                //            item.CreateDate = DateTime.Now;
                //            oListTrnsEmployeeOtDetail.Add(item);
                //            oModel.TrnsEmployeeOvertimeDetails = oListTrnsEmployeeOtDetail.ToList();

                //        }
                //        else
                //        {
                //            item.UpdatedBy = LoginUser;
                //            item.UpdateDate = DateTime.Now;
                //            oListTrnsEmployeeOtDetail.Add(item);
                //            oModel.TrnsEmployeeOvertimeDetails = oListTrnsEmployeeOtDetail.ToList();
                //        }
                //    }
                //    if (oModel.Id == 0)
                //    {
                //        oModel.UserId = LoginUser;
                //        res = await _TrnsEmployeeOverTime.Insert(oModel);
                //    }
                //    else
                //    {
                //        oModel.UpdatedBy = LoginUser;
                //        res = await _TrnsEmployeeOverTime.Update(oModel);
                //    }

                //if (res != null && res.Id == 1)
                //{
                //    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //    await Task.Delay(3000);
                //    Navigation.NavigateTo("/EmployeeOverTime", forceLoad: true);
                //}
                //else
                //{
                //    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
                //}

                //else
                //{
                //    Snackbar.Add("Please Add Detail.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}




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
                    oModel.DocStatus = "Created";
                    await GetAllEmployees();
                    await GetAllEmployeesPayroll();
                    await GetAllOvertime();

                    await GetAllDepartments();
                    await GetAllLocation();
                    await SetDocNo();
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

