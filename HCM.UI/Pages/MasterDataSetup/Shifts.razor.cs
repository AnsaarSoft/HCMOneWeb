using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Shifts
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstOverTime _mstOverTime { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public IMstDeductionRule _mstDeductionRule { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstShift element) => FilterFunc(element, searchString1);

        MstShift oModel = new MstShift();
        MstShiftDetail oDetail = new MstShiftDetail();
        List<MstLove> oLoveList = new List<MstLove>();
        List<VMMstShiftDetail> oDetailList = new List<VMMstShiftDetail>();
        private IEnumerable<MstShift> oList = new List<MstShift>();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        private IEnumerable<MstOverTime> oListOverTime = new List<MstOverTime>();

        private IEnumerable<MstDeductionRule> oListDeduction = new List<MstDeductionRule>();

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "Shifts");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    oDetailList.Clear();
                    DisabledCode = true;
                    var res = (MstShift)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oModel = res;
                    foreach (var item in oModel.MstShiftDetails)
                    {
                        VMMstShiftDetail vm = new VMMstShiftDetail();
                        vm.Id = item.Id;
                        vm.Fkid = item.ShiftId;
                        vm.Day = item.Day;

                        string[] spStartTime = item.StartTime.Split(':');
                        TimeSpan TsStartTime = new TimeSpan(Convert.ToInt32(spStartTime[0]), Convert.ToInt32(spStartTime[1]), 0);
                        vm.TSStartTime = TsStartTime;

                        string[] spEndTime = item.EndTime.Split(':');
                        TimeSpan TsEndTime = new TimeSpan(Convert.ToInt32(spEndTime[0]), Convert.ToInt32(spEndTime[1]), 0);
                        vm.TSEndTime = TsEndTime;

                        string[] spDurationTime = item.Duration.Split(':');
                        TimeSpan TsDurationTime = new TimeSpan(Convert.ToInt32(spDurationTime[0]), Convert.ToInt32(spDurationTime[1]), 0);
                        vm.TSDuration = TsDurationTime;

                        string[] spBufferStartTime = item.BufferStartTime.Split(':');
                        TimeSpan TSBufferStartTime = new TimeSpan(Convert.ToInt32(spBufferStartTime[0]), Convert.ToInt32(spBufferStartTime[1]), 0);
                        vm.TSBufferStartTime = TSBufferStartTime;

                        string[] spBufferEndTime = item.BufferEndTime.Split(':');
                        TimeSpan TSBufferEndTime = new TimeSpan(Convert.ToInt32(spBufferEndTime[0]), Convert.ToInt32(spBufferEndTime[1]), 0);
                        vm.TSBufferEndTime = TSBufferEndTime;

                        string[] spGraceStartTime = item.StartGraceTime.Split(':');
                        TimeSpan TSGraceStartTime = new TimeSpan(Convert.ToInt32(spGraceStartTime[0]), Convert.ToInt32(spGraceStartTime[1]), 0);
                        vm.TSGraceStartTime = TSBufferEndTime;

                        string[] spGraceEndTime = item.StartGraceTime.Split(':');
                        TimeSpan TSGraceEndTime = new TimeSpan(Convert.ToInt32(spGraceEndTime[0]), Convert.ToInt32(spGraceEndTime[1]), 0);
                        vm.TSGraceEndTime = TSGraceEndTime;

                        string[] spBreakTime = item.BreakTime.Split(':');
                        TimeSpan TSBreakTime = new TimeSpan(Convert.ToInt32(spBreakTime[0]), Convert.ToInt32(spBreakTime[1]), 0);
                        vm.TSBreakTime = TSBreakTime;

                        vm.FlgOutOverlap = item.FlgOutOverlap;
                        vm.FlgExpectedIn = item.FlgExpectedIn;
                        vm.FlgExpectedOut = item.FlgExpectedOut;
                        oDetailList.Add(vm);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenProcessDialog(DialogOptions options, List<VMMstShiftDetail> oDetailListDG)
        {
            try
            {
                if (oDetailList.Count == 0)
                {
                    var parameters = new DialogParameters();
                    parameters.Add("DialogFor", "Shifts");
                    var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                    {
                        //DisabledCode = true;
                        var res = (List<VMMstShiftDetail>)result.Data;
                        AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                        oDetailList = res;
                    }
                }
                else
                {
                    var parameters = new DialogParameters();
                    parameters.Add("oDetailListPara", oDetailListDG);
                    parameters.Add("DialogFor", "Shifts");
                    var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                    var result = await dialog.Result;

                    if (!result.Cancelled)
                    {
                        var res = (List<VMMstShiftDetail>)result.Data;
                        AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                        oDetailList = res;
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
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && oModel.OverTimeId > 0 && oModel.DeductionRuleId > 0)
                {
                    if (oModel.Code.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.MstShiftDetails = new List<MstShiftDetail>();
                        foreach (var item in oDetailList)
                        {
                            oDetail = new MstShiftDetail();
                            oDetail.Id = item.Id;
                            oDetail.ShiftId = item.Fkid;
                            oDetail.Day = item.Day;
                            oDetail.FlgOutOverlap = item.FlgOutOverlap;
                            oDetail.FlgExpectedIn = item.FlgExpectedIn;
                            oDetail.FlgExpectedOut = item.FlgExpectedOut;
                            oDetail.StartTime = item.TSStartTime.ToString();
                            oDetail.EndTime = item.TSEndTime.ToString();
                            oDetail.Duration = item.TSDuration.ToString();
                            oDetail.BufferStartTime = item.TSBufferStartTime.ToString();
                            oDetail.BufferEndTime = item.TSBufferEndTime.ToString();
                            oDetail.StartGraceTime = item.TSGraceStartTime.ToString();
                            oDetail.EndGraceTime = item.TSGraceEndTime.ToString();
                            oDetail.BreakTime = item.TSBreakTime.ToString();
                            oModel.MstShiftDetails.Add(oDetail);
                        }
                        if (oModel.Id == 0)
                        {
                            if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                            {
                                Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                            else
                            {
                                oModel.UserId = LoginUser;
                                res = await _mstShift.Insert(oModel);
                            }
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstShift.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Shifts", forceLoad: true);
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
                Navigation.NavigateTo("/Shifts", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(MstShift element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async Task GetAllLove()
        {
            try
            {
                oLoveList = await _mstLove.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllOverTime()
        {
            try
            {
                oListOverTime = await _mstOverTime.GetAllData();
                oListOverTime = oListOverTime.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDeductionRule()
        {
            try
            {
                oListDeduction = await _mstDeductionRule.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

                    oModel.Id = res.Id;
                    oModel.Code = res.Code;
                    DisabledCode = true;
                    oModel.Description = res.Description;
                    oModel.FlgActive = res.FlgActive;
                    oList = oList.Where(x => x.Id != LineNum);
                    //_ = InvokeAsync(StateHasChanged);
                }
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
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    oModel.FlgHoliDayOverTime = true;
                    oModel.FlgOffDayOverTime = true;

                    oModel.FlgActive = true;
                    //oModel.FlgOverTime = true;
                    oModel.FlgOtwrkHrs = true;
                    await GetAllLove();
                    await GetAllOverTime();
                    await GetAllDeductionRule();
                    //await GetAllShift();
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
