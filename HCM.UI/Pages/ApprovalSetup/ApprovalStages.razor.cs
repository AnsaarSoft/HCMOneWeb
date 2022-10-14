using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.ApprovalSetup
{
    public partial class ApprovalStages
    {
        #region Inject Service

        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public IMstStages _stageService { get; set; }
        //[Inject]
        //public IUserProfile _userProfileService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService _localStorageService { get; set; }

        #endregion

        #region Variable

        private bool Loading = false;

        private string LoginUserCode = "";
        private IEnumerable<MstEmployee> AuthorizerNames { get; set; } = new HashSet<MstEmployee>();

        MstStage oModel = new MstStage();

        //MstUserProfile oUser = new MstUserProfile();
        //List<MstUserProfile> oUserList = new List<MstUserProfile>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Function

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "Stages");
                //var dialog = Dialog.Show<SaveDataDialog>("", parameters, options);
                //var result = await dialog.Result;
                //if (!result.Cancelled)
                //{
                //    var res = (MstStage)result.Data;
                //    oModel = res;
                //    AuthorizerNames = new HashSet<MstUserProfile>();
                //    List<MstUserProfile> oList = new List<MstUserProfile>();
                //    foreach (var item in oModel.MstStageDetails)
                //    {
                //        MstUserProfile LineUser = new MstUserProfile();
                //        LineUser = oUserList.Where(a => a.Id == item.FkUserId).FirstOrDefault();
                //        oList.Add(LineUser);
                //    }
                //    AuthorizerNames = oList;
                //}
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
                parameters.Add("DialogFor", "MultipleEmployeeSelect");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    AuthorizerNames = (ICollection<MstEmployee>)result.Data;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        //async Task<List<MstUserProfile>> GetAllUsers()
        //{
        //    try
        //    {
        //        oUserList = await _userProfileService.GetAllData();
        //        return oUserList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return null;
        //    }
        //}

        //private string GetAuthorizersSelection(List<string> selectedValues)
        //{
        //    try
        //    {
        //        if (selectedValues.Count < 1)
        //        {
        //            return $"Please choose Authorizer";
        //        }
        //        return $"{selectedValues.Count} Authorizer{(selectedValues.Count > 1 ? "s have" : " has")} been selected";
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
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
                if (!string.IsNullOrWhiteSpace(Convert.ToString(oModel.Id)))
                {
                    try
                    {
                        Loading = true;
                        var res1 = new ApiResponseModel();
                        await Task.Delay(1);

                        if (oModel.StageName == null || oModel.NumberOfApprovals == null || oModel.NumberOfRejectins == null)
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (AuthorizerNames == null && AuthorizerNames.Count() == 0)
                        {
                            Snackbar.Add("Please Select Employee.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (AuthorizerNames != null && AuthorizerNames.Count() > 0)
                        {
                            oModel.MstStageDetails.Clear();
                            foreach (var Line in AuthorizerNames)
                            {
                                MstStageDetail oLine = new MstStageDetail();
                                oLine.EmployeeId = Convert.ToInt32(Line.EmpId);
                                oModel.MstStageDetails.Add(oLine);
                            }
                        }
                        if (oModel != null && oModel.MstStageDetails != null && oModel.MstStageDetails.Count > 0)
                        {
                            if (oModel.Id == 0)
                            {
                                res1 = await _stageService.Insert(oModel);
                            }
                            else
                            {
                                res1 = await _stageService.Update(oModel);
                            }
                        }
                        else
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (res1 != null && res1.Id == 1)
                        {
                            Snackbar.Add(res1.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(1000);
                            Navigation.NavigateTo("/Stage", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
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
                Navigation.NavigateTo("/ApprovalStages", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion

        #region Initialize

        protected async override Task OnInitializedAsync()
        {
            try
            {
                //var Session = await _localStorageService.GetItemAsync<MstUserProfile>("User");
                //if (Session != null)
                //{
                //    LoginUserCode = Session.UserCode;
                //    Loading = true;
                //    await GetAllUsers();
                //    Loading = false;
                //}
                //else
                //{
                //    navigation.NavigateTo("/Login", true);
                //}
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        #endregion
    }
}
