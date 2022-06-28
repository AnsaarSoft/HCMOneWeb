using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class PayrollSetup
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstPayroll _mstPayroll { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        #endregion

        #region Variables 

        bool Loading = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        bool DisabledCode = false;
        private string PayrollCalendar = "";
        private string searchString1 = "";

        MstPayroll oModel = new MstPayroll();
        List<MstLove> oLoveList = new List<MstLove>();
        List<MstCalendar> oCalendarList = new List<MstCalendar>();

        private IEnumerable<MstElement> oElementList = new List<MstElement>();
        private bool FilterFunc(MstElement element) => FilterFuncElement(element, searchString1);
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                Settings.DialogFor = "PayrollSetup";
                var dialog = Dialog.Show<DialogBox>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
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
                Settings.DialogFor = "Element";
                var dialog = Dialog.Show<DialogBox>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstElement)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    MstElement oModelElement = res;
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
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllCalendar()
        {
            try
            {
                oCalendarList = await _mstCalendar.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllElements()
        {
            try
            {
                oElementList = await _mstElement.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        
        private bool FilterFuncElement(MstElement element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ElmtType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Equals(searchString1))
                return true;
            return false;
        }
        
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                //if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && oModel.OverTimeId > 0 && oModel.DeductionRuleId > 0)
                //{
                //    if (oModel.Code.Length > 20)
                //    {
                //        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //    else
                //    {
                //        oModel.MstShiftsDetails = new List<MstShiftsDetail>();
                //        foreach (var item in oDetailList)
                //        {
                //            oDetail = new MstShiftsDetail();
                //            oDetail.Id = item.Id;
                //            oDetail.Fkid = item.Fkid;
                //            oDetail.Day = item.Day;
                //            oDetail.FlgOutOverlap = item.FlgOutOverlap;
                //            oDetail.FlgExpectedIn = item.FlgExpectedIn;
                //            oDetail.FlgExpectedOut = item.FlgExpectedOut;
                //            oDetail.StartTime = item.TSStartTime.ToString();
                //            oDetail.EndTime = item.TSEndTime.ToString();
                //            oDetail.Duration = item.TSDuration.ToString();
                //            oDetail.BufferStartTime = item.TSBufferStartTime.ToString();
                //            oDetail.BufferEndTime = item.TSBufferEndTime.ToString();
                //            oDetail.StartGraceTime = item.TSGraceStartTime.ToString();
                //            oDetail.EndGraceTime = item.TSGraceEndTime.ToString();
                //            oDetail.BreakTime = item.TSBreakTime.ToString();
                //            oModel.MstShiftsDetails.Add(oDetail);
                //        }
                //        if (oModel.Id == 0)
                //        {
                //            if (oList.Where(x => x.Code == oModel.Code).Count() > 0)
                //            {
                //                Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //            }
                //            else
                //            {
                //                res = await _mstShift.Insert(oModel);
                //            }
                //        }
                //        else
                //        {
                //            res = await _mstShift.Update(oModel);
                //        }
                //    }
                //    if (res != null && res.Id == 1)
                //    {
                //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //        await Task.Delay(3000);
                //        Navigation.NavigateTo("/Shifts", forceLoad: true);
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //    oModel.FlgActive = true;
                //}
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/PayrollSetup", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                oModel.FlgActive = true;
                await GetAllLove();
                await GetAllElements();
                await GetAllCalendar();
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
