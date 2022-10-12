using Blazored.LocalStorage;
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
        public IMstLeaveType _mstLeaveType { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstLeaveDeduction _mstLeaveDeduction { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString1 = "";
        private bool FilterFunc(MstLeaveType element) => FilterFunc(element, searchString1);

        MstLeaveType oModel = new MstLeaveType();
        List<MstLove> oLovesList = new List<MstLove>();
        private IEnumerable<MstLeaveType> oList = new List<MstLeaveType>();
        private IEnumerable<MstLeaveDeduction> oListLeaveDeduction = new List<MstLeaveDeduction>();
        private IEnumerable<MstElement> oListElement = new List<MstElement>();
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
                    var res = (MstLeaveType)result.Data;
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
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) && !string.IsNullOrWhiteSpace(oModel.DeductionType) && (oModel.FlgEncash ==true || oModel.FlgPartiallyEncash == true) && !string.IsNullOrWhiteSpace(oModel.ElementCode))
                {
                    if (oModel.Code.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                        {
                            Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                        else
                        {
                            if (oModel.Id == 0)
                            {
                                oModel.CreatedBy = LoginUser;
                                res = await _mstLeaveType.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUser;
                                res = await _mstLeaveType.Update(oModel);
                            }
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

        private bool FilterFunc(MstLeaveType element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeductionType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeductionId.Equals(searchString1))
                return true;
            if (element.LeaveCap.Equals(searchString1))
                return true;
            if (element.ElementCode.Equals(searchString1))
                return true;
            if (element.FlgEncash.Equals(searchString1))
                return true;
            if (element.FlgCarryForward.Equals(searchString1))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;

            return false;
        }

        private async Task GetAllElements()
        {
            try
            {
                oListElement = await _mstElement.GetAllData();
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

                    oModel = res;
                    //oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    DisabledCode = true;
                    //oModel.Description = res.Description;
                    //oModel.DeductionType = res.DeductionType;
                    //oModel.DeductionId = res.DeductionId;
                    //oModel.LeaveCap = res.LeaveCap;
                    //oModel.FlgEncash = res.FlgEncash;
                    //oModel.ElementCode = res.ElementCode;
                    //oModel.EncashmentCap = res.EncashmentCap;
                    //oModel.FlgCarryForward = res.FlgCarryForward;
                    //oModel.CarryForwardLeaves = res.CarryForwardLeaves;
                    //oModel.FlgPartiallyEncash = res.FlgPartiallyEncash;
                    //oModel.FlgActive = res.FlgActive;
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    await GetAllLove();
                    await GetAllLeaveDeduction();
                    await GetAllLeaveType();
                    await GetAllElements();
                    oModel.FlgEncash = true;
                    oModel.FlgCarryForward = true;
                    oModel.FlgActive = true;
                    oModel.LeaveCap = 0;
                    oModel.EncashmentCap = 0;
                    oModel.CarryForwardLeaves = 0;
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