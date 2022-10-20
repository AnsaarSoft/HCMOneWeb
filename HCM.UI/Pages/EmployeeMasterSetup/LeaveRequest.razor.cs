using Blazored.LocalStorage;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using HCM.UI.Interfaces.ShiftManagement;
using System.Globalization;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class LeaveRequest
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLeaveType _mstLeaveType { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public ICfgPayrollDefinationinit _CfgPayrollDefinationinit { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstLeaveCalendar _mstLeaveCalendar { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ITrnsAttendanceRegister _trnsAttendanceRegister { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public ITrnsLeaveRequest _trnsLeaveRequest { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        int EmpPayrollID = 0;
        decimal? LeaveCarryForward = 0, LeaveEntitled = 0, TotalAvailable = 0, LeaveUsed = 0, deductedLeaves, ApprovedLeaves = 0, RequestedLeaves = 0, AllowedAccured = 0;

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        private TimeSpan? TSFromTime { get; set; }
        private TimeSpan? TSToTime { get; set; }

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        MstEmployeeLeaf oModelEmployeeLeaves = new MstEmployeeLeaf();
        TrnsLeavesRequest oModel = new TrnsLeavesRequest();
        private IEnumerable<TrnsLeavesRequest> oList = new List<TrnsLeavesRequest>();

        private IEnumerable<MstLeaveType> oListLeaveType = new List<MstLeaveType>();
        List<MstLove> oLoveList = new List<MstLove>();

        MstEmployee oModelEmployee = new MstEmployee();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        CfgPayrollBasicInitialization oModelPayrollInit = new CfgPayrollBasicInitialization();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oCalendarlList = new List<MstCalendar>();

        MstLeaveCalendar oModelLeaveCalendar = new MstLeaveCalendar();
        private IEnumerable<MstLeaveCalendar> oLeaveCalendarlList = new List<MstLeaveCalendar>();

        private IEnumerable<CfgPayrollDefination> oPayrollList = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oPayrollPeriodList = new List<CfgPeriodDate>();
        private IEnumerable<TrnsAttendanceRegister> oAttendanceRegisterList = new List<TrnsAttendanceRegister>();
        private IEnumerable<MstShift> oShiftList = new List<MstShift>();

        [Parameter]
        public int DocNum { get; set; }

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "LeaveRequest");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsLeavesRequest)result.Data;
                    oModel = res;
                    _dateRange.Start = oModel.LeaveFrom;
                    _dateRange.End = oModel.LeaveTo;
                    SetEmployeeLeaves();
                    if (!string.IsNullOrWhiteSpace(oModel.FromTime) && !string.IsNullOrWhiteSpace(oModel.ToTime))
                    {
                        string[] spFromTime = oModel.FromTime.Split(':');
                        TimeSpan FromTime = new TimeSpan(Convert.ToInt32(spFromTime[0]), Convert.ToInt32(spFromTime[1]), 0);
                        TSFromTime = FromTime;

                        string[] spToTime = oModel.ToTime.Split(':');
                        TimeSpan ToTime = new TimeSpan(Convert.ToInt32(spToTime[0]), Convert.ToInt32(spToTime[1]), 0);
                        TSToTime = ToTime;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
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
                    oModel.EmpId = oModelEmployee.Id;
                    oModel.EmpName = oModelEmployee.FirstName + " " + oModelEmployee.MiddleName + " " + oModelEmployee.LastName;
                    oModel.EmpDept = oModelEmployee.DepartmentName;
                    oModel.EmpDesg = oModelEmployee.DesignationName;
                    oModel.EmpLoc = oModelEmployee.LocationName;
                    EmpPayrollID = (int)oModelEmployee.PayrollId;
                    await GetEmpPayroll();
                    await GetPayrollPeriods();
                    await GetEmployeeAttendanceRegister();
                    await GetAllShift();
                    //await GetAllLeaveType();
                }
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
        private async Task GetAllLeaveRequest()
        {
            try
            {
                oList = await _trnsLeaveRequest.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetPayrollInit()
        {
            try
            {
                oModelPayrollInit = await _CfgPayrollDefinationinit.GetData();
                await GetCalendar();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetCalendar()
        {
            try
            {
                if (oModelPayrollInit.FlgLeaveCalendar == true)
                {
                    oLeaveCalendarlList = await _mstLeaveCalendar.GetAllData();
                    oModelLeaveCalendar = oLeaveCalendarlList.Where(x => x.FlgActive == true).FirstOrDefault();
                }
                else
                {
                    oCalendarlList = await _mstCalendar.GetAllData();
                    oModelCalendar = oCalendarlList.Where(x => x.FlgActive == true).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLove()
        {
            try
            {
                oLoveList = await _mstLove.GetAllData();
                oLoveList = oLoveList.Where(x => x.Type == "LeaveUnits" && (x.Code == "Day" || x.Code == "Hour")).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async void SetEmployeeLeaves()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.LeavesType) && oModelEmployee.MstEmployeeLeaves.Count > 0)
                {
                    var EmpLeave = new MstEmployeeLeaf();
                    if (oModelLeaveCalendar.Code != null)
                    {
                        EmpLeave = oModelEmployee.MstEmployeeLeaves.Where(x => x.LeaveTypeCode == oModel.LeavesType && x.LeaveCalCode == oModelLeaveCalendar.Code).FirstOrDefault();
                        oModel.CalCode = oModelLeaveCalendar.Code;
                    }
                    else if (oModelCalendar.Code != null)
                    {
                        EmpLeave = oModelEmployee.MstEmployeeLeaves.Where(x => x.LeaveTypeCode == oModel.LeavesType && x.LeaveCalCode == oModelCalendar.Code).FirstOrDefault();
                        oModel.CalCode = oModelCalendar.Code;
                    }

                    var RequestedLeavesRecords = oList.Where(a => a.EmpId == oModelEmployee.Id && a.LeavesType == oModel.LeavesType && a.DocAprStatus == "Pending" && a.CalCode == EmpLeave.LeaveCalCode).GroupBy(a => a.EmpId).Select(a => new { Amount = a.Sum(b => b.TotalCount) }).OrderByDescending(a => a.Amount).ToList();
                    if (RequestedLeavesRecords != null && RequestedLeavesRecords.Count > 0)
                    {
                        RequestedLeaves = RequestedLeavesRecords.FirstOrDefault().Amount;
                    }
                    var ApprovedLeavesRecords = oList.Where(a => a.EmpId == oModelEmployee.Id && a.LeavesType == oModel.LeavesType && a.DocAprStatus == "Accepted" && a.CalCode == EmpLeave.LeaveCalCode).GroupBy(a => a.EmpId).Select(a => new { Amount = a.Sum(b => b.TotalCount) }).OrderByDescending(a => a.Amount).ToList();
                    if (ApprovedLeavesRecords != null && ApprovedLeavesRecords.Count > 0)
                    {
                        LeaveUsed = ApprovedLeaves = ApprovedLeavesRecords.FirstOrDefault().Amount;
                    }
                    var ApprovedEncashLeavesRecords = oList.Where(a => a.EmpId == oModelEmployee.Id && a.LeavesType == oModel.LeavesType && a.CalCode == EmpLeave.LeaveCalCode).GroupBy(a => a.EmpId).Select(a => new { Amount = a.Sum(b => b.TotalCount) }).OrderByDescending(a => a.Amount).ToList();
                    if (ApprovedEncashLeavesRecords != null && ApprovedEncashLeavesRecords.Count > 0)
                    {
                        ApprovedLeaves += ApprovedEncashLeavesRecords.FirstOrDefault().Amount;
                    }
                    if (EmpLeave.LeavesCarryForward.ToString() != null)
                    {
                        LeaveCarryForward = EmpLeave.LeavesCarryForward;
                    }
                    if (EmpLeave.LeavesEntitled.ToString() != null)
                    {
                        LeaveEntitled = EmpLeave.LeavesEntitled;
                    }
                    if (LeaveCarryForward != null && LeaveEntitled != null)
                    {
                        TotalAvailable = LeaveCarryForward + LeaveEntitled;
                    }

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
                Navigation.NavigateTo("/LeaveRequest", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task GetEmpPayroll()
        {
            try
            {
                oPayrollList = await _CfgPayrollDefination.GetAllData();
                oModelPayroll = oPayrollList.Where(x => x.Id == EmpPayrollID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetPayrollPeriods()
        {
            try
            {
                await Task.Delay(1);
                if (oModelPayroll.Id > 0)
                {
                    oPayrollPeriodList = oModelPayroll.CfgPeriodDates.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetEmployeeAttendanceRegister()
        {
            try
            {
                oAttendanceRegisterList = await _trnsAttendanceRegister.GetAllData();
                oAttendanceRegisterList = oAttendanceRegisterList.Where(x => x.EmpId == oModelEmployee.Id && x.FlgPosted == false).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllShift()
        {
            try
            {
                oShiftList = await _mstShift.GetAllData();
                oShiftList = oShiftList.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task VerifyPeriodRange()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);

                var LockedPeriod = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.Start && a.EndDate >= _dateRange.End && a.FlgLocked == true).FirstOrDefault();
                if (LockedPeriod != null)
                {
                    Snackbar.Add("Leave not allowed on locked Periods.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                var CurrentPeriod = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.Start && a.EndDate >= _dateRange.Start && a.FlgLocked == false).FirstOrDefault();
                var CurrentPeriod2 = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.End && a.EndDate >= _dateRange.End && a.FlgLocked == false).FirstOrDefault();
                if (CurrentPeriod != CurrentPeriod2)
                {
                    Snackbar.Add("Leave Document range can not fall on multiple Periods.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                string checkPeriodTodate = "";
                string checkPeriodTodate2 = "";
                if (CurrentPeriod != null && CurrentPeriod2 != null)
                {
                    checkPeriodTodate = CurrentPeriod.PeriodName;
                    checkPeriodTodate2 = CurrentPeriod2.PeriodName;
                }
                if (oModelEmployee.JoiningDate > _dateRange.Start)
                {
                    Snackbar.Add("From date could not be greater then to Join date", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                if (oModelEmployee.JoiningDate > _dateRange.End)
                {
                    Snackbar.Add("End date could not be greater then to Join date", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                if (_dateRange.Start > _dateRange.End)
                {
                    Snackbar.Add("From date could not be greater then to date.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                oModel.LeaveFrom = _dateRange.Start;
                oModel.LeaveTo = _dateRange.End;
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task FillUnit()
        {
            try
            {
                await Task.Delay(1);
                decimal HourInPayroll = 0;
                decimal UnitsInOneDay = 0;
                var ShiftDay = oAttendanceRegisterList.Where(x => x.Date == _dateRange.Start).FirstOrDefault();
                if (ShiftDay == null)
                {
                    Snackbar.Add("Please Assign Shift to Selected Employee", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                var ShiftDetail = oShiftList.Select(x => x.MstShiftDetails.Where(x => x.ShiftId == ShiftDay.ShiftId && x.Day == ShiftDay.DateDay).FirstOrDefault()).FirstOrDefault();
                if (ShiftDetail != null)
                {
                    HourInPayroll = Convert.ToDecimal(TimeSpan.Parse(ShiftDetail.Duration).TotalHours);
                }
                if (oModel.Value == "Day")
                {
                    UnitsInOneDay = Convert.ToInt32(HourInPayroll * 60);
                }
                if (oModel.Value == "Hour")
                {
                    if (TSFromTime != null && TSToTime != null)
                    {
                        oModel.FromTime = TSFromTime.ToString();
                        oModel.ToTime = TSToTime.ToString();
                        TimeSpan Dur = DateTime.ParseExact(TSToTime.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture).Subtract(DateTime.ParseExact(TSFromTime.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture));
                        //UnitsInOneDay = Convert.ToDecimal(HourInPayroll * 60) / Convert.ToDecimal(Dur.TotalMinutes);
                        UnitsInOneDay = Convert.ToDecimal(Dur.TotalMinutes);
                    }
                }
                oModel.Units = UnitsInOneDay;
                oModel.TotalCount = UnitsInOneDay / Convert.ToDecimal(HourInPayroll * 60);
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
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId) && !string.IsNullOrWhiteSpace(oModel.Value) && !string.IsNullOrWhiteSpace(oModel.LeavesType) && oAttendanceRegisterList.Count() > 0)
                {
                    if (oModel.Id > 0)
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsLeaveRequest.Update(oModel);
                    }
                    else
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _trnsLeaveRequest.Insert(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/LeaveRequest", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Fill the required fields.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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

        private async Task GetLeaveRequestWithDocNum(int DocNum)
        {
            try
            {
                var result = await _trnsLeaveRequest.GetAllData();
                oModel = result.Where(x => x.DocNum == DocNum).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
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
                    if (DocNum == 0)
                    {
                        LoginUser = Session.UserCode;
                        await GetAllLeaveRequest();
                        await SetDocNo();
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocStatus = "Draft";
                        oModel.DocAprStatus = "Pending";
                        oModel.DocDate = DateTime.Today;
                        oModel.Units = 0;
                        await GetAllLove();
                        await GetPayrollInit();
                    }
                    else
                    {
                        await GetLeaveRequestWithDocNum(DocNum);
                    }
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