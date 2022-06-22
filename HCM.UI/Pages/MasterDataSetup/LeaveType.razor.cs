using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class LeaveType 
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLeaveType  _mstLeaveType { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstLeaveDeduction _mstLeaveDeduction { get; set; }


        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstLeaveType  element) => FilterFunc(element, searchString1);

        MstLeaveType  oModel = new MstLeaveType ();
        List<MstLove> oLovesList = new List<MstLove>();
        private IEnumerable<MstLeaveType > oList = new List<MstLeaveType>();
        private IEnumerable<MstLeaveDeduction > oListLeaveDeduction = new List<MstLeaveDeduction>();
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
                    var res = (MstLeaveType )result.Data;
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
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && !string.IsNullOrWhiteSpace(oModel.LeaveType))
                {
                    if (oModel.Code.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oModel.Id == 0)
                        {
                            res = await _mstLeaveType.Insert(oModel);
                        }
                        else
                        {
                            res = await _mstLeaveType.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/LeaveType", forceLoad: true);
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
                Navigation.NavigateTo("/LeaveType", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(MstLeaveType  element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LeaveType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeductionId.Equals(searchString1))
                return true;
            if (element.MonthDays.Equals(searchString1))
                return true;
            if (element.LeaveCap.Equals(searchString1))
                return true;
            if (element.FlgEncash.Equals(searchString1))
                return true;
            if (element.FlgCarryForward.Equals(searchString1))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;

            return false;
        }

        private async Task GetAllLeaveType()
        {
            try
            {
                oList = await _mstLeaveType.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLeaveDeduction()
        {
            try
            {
                oListLeaveDeduction = await _mstLeaveDeduction.GetAllData();
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
                    oModel.LeaveType = res.LeaveType;
                    oModel.DeductionId = res.DeductionId;
                    oModel.MonthDays = res.MonthDays;
                    oModel.LeaveCap = res.LeaveCap;
                    oModel.FlgEncash = res.FlgEncash;
                    oModel.FlgCarryForward = res.FlgCarryForward;
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
                await GetAllLove();
                await GetAllLeaveDeduction();
                await GetAllLeaveType();
                oModel.FlgEncash = true;
                oModel.FlgCarryForward = true;
                oModel.FlgActive = true;
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
