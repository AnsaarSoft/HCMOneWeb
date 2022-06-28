using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class DeductionRule
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstDeductionRule _mstDeductionRule { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstLeaveType _mstLeaveType { get; set; }
        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        private TimeSpan? TSRangeFrom = new TimeSpan();
        private TimeSpan? TSRangeTo = new TimeSpan();
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstDeductionRule element) => FilterFunc(element, searchString1);

        MstDeductionRule oModel = new MstDeductionRule();
        List<MstLove> oLovesList = new List<MstLove>();
        List<MstLeaveType> oLeaveTypeList = new List<MstLeaveType>();
        private IEnumerable<MstDeductionRule> oList = new List<MstDeductionRule>();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var dialog = Dialog.Show<DialogBox>("", options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    DisabledCode = true;
                    var res = (MstDeductionRule)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    oModel = res;
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
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Value))
                {
                    if (oModel.Code.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.RangeFrom = TSRangeFrom.ToString();
                        oModel.RangeTo = TSRangeTo.ToString();
                        if (oModel.Id == 0)
                        {
                            //if (oList.Where(x => x.Code == oModel.Code).Count() > 0)
                            //{
                            //    Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            //}
                            //else
                            //{
                            //    res = await _mstDeductionRule.Insert(oModel);
                            //}
                        }
                        else
                        {
                            res = await _mstDeductionRule.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/DeductionRule", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    
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
                Navigation.NavigateTo("/DeductionRule", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(MstDeductionRule element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Value.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.RangeFrom.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.RangeTo.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Deduction.Equals(searchString1))
                return true;
            if (element.LeaveType.Equals(searchString1))
                return true;
            if (element.GracePeriod.Equals(searchString1))
                return true;
            if (element.LeaveCount.Equals(searchString1))
                return true;

            return false;
        }

        private async Task GetAllDeductionRule()
        {
            try
            {
                oList = await _mstDeductionRule.GetAllData();
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
                oLovesList = await _mstLove.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLeaveType()
        {
            try
            {
                oLeaveTypeList = await _mstLeaveType.GetAllData();
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
                    oModel.Value = res.Value;
                    TSRangeFrom = TimeSpan.Parse(res.RangeFrom);
                    TSRangeTo = TimeSpan.Parse(res.RangeTo);
                    oModel.Deduction = res.Deduction;
                    oModel.LeaveType = res.LeaveType;
                    oModel.GracePeriod = res.GracePeriod;
                    oModel.LeaveCount = res.LeaveCount;
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
                await GetAllLove();
                await GetAllDeductionRule();
                await GetAllLeaveType();
                oModel.Deduction = true;
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
