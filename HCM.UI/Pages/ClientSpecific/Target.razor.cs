using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.ClientSpecific;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;

namespace HCM.UI.Pages.ClientSpecific
{
    public partial class Target
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstTarget _MstTarget { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledCode = false;
        private string searchString1 = "";
        private string LoginUser = "";
        private int productStageID ;
        private string productStageCode = "";


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        private bool FilterFunc(MstTarget element) => FilterFunc(element, searchString1);

        MstTarget oModel = new MstTarget();
        private IEnumerable<MstTarget> oList = new List<MstTarget>();
        TrnsProductStage oModelTrnsProductStage= new TrnsProductStage();
        #endregion

        #region Functions
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsProductStage");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStage)result.Data;
                    //oModelTrnsProductStage = res;
                    oModel.Psid = res.Id;
                    oModel.Pscode = res.Code;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogItem(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsProductStageItem");
                parameters.Add("productStageID", oModel.Psid);
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsProductStageItem)result.Data;
                    oModel.ItemCode = res.ItemCode;
                    oModel.ItemName = res.ItemDescription;
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
                if (!string.IsNullOrWhiteSpace(oModel.ItemCode) && !string.IsNullOrWhiteSpace(oModel.ItemName))
                {
                    if (oList.Where(x => x.ItemCode.Trim().ToLowerInvariant() == oModel.ItemCode.Trim().ToLowerInvariant() && x.Pscode.Trim().ToLowerInvariant() == oModel.Pscode.Trim().ToLowerInvariant()).Count() > 0)
                    {
                        Snackbar.Add(oModel.ItemCode + " : is Code already exist with same Production Stage Code", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oModel.Id == 0)
                        {
                            oModel.UserId = LoginUser;
                            res = await _MstTarget.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _MstTarget.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Target", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                   // oModel.FlgActive = true;
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
                Navigation.NavigateTo("/Target", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllTarget()
        {
            try
            {
                oList = await _MstTarget.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstTarget element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.ItemCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ItemName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FixValue.Equals(searchString1))
                return true;
            return false;
        }

        public void RemoveRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id != LineNum);
                oList = res;
                if (oList.Count() == 0)
                {
                    oModel = new MstTarget();
                }
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
                    oModel.Id = res.Id;
                    oModel.ItemCode = res.ItemCode;
                    oModel.ItemName = res.ItemName;
                    oModel.FrmPieces = res.FrmPieces;
                    oModel.ToPieces = res.ToPieces;
                    oModel.FixValue = res.FixValue;
                    oModel.Psid = res.Psid;
                    oModel.Pscode = res.Pscode;
                    oModel.UserId = res.UserId;
                    oModel.CreateDate = res.CreateDate;
                    DisbaledCode = true;
                    oList = oList.Where(x => x.Id != LineNum);
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
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    var res = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res.Where(x => x.CMenuID == 71 && x.UserRights == true).ToList().Count > 0)
                    {
                        Loading = true;
                        //oModel.FlgActive = true;
                        await GetAllTarget();
                    }
                    else
                    {
                        Navigation.NavigateTo("/Dashboard", forceLoad: true);
                    }
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion
    }
}