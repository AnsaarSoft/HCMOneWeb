using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Gratuity
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstGratuity _mstGratuity { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        #endregion

        #region Variables

        bool Loading = false;
        bool DisabledCode = false;
        private string searchString1 = "";
        private string LoginUser = "";
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private bool FilterFunc(MstGratuity element) => FilterFunc(element, searchString1);

        MstGratuity oModel = new MstGratuity();
        List<MstGratuityDetail> oDetail = new List<MstGratuityDetail>();
        private IEnumerable<MstGratuity> oList = new List<MstGratuity>();
        private IEnumerable<MstGratuityDetail> oDetailList = new List<MstGratuityDetail>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "GratuitySetup");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    DisabledCode = true;
                    var res = (MstGratuity)result.Data;
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    //oModel = res;
                    oModel.Id = res.Id;
                    oModel.GrtCode = res.GrtCode;
                    oModel.BasedOn = res.BasedOn;
                    oModel.BasedOnValue = res.BasedOnValue;
                    oModel.FlgAbsoluteYears = res.FlgAbsoluteYears;
                    oModel.FlgWopleaves = res.FlgWopleaves;
                    oModel.FlgEffectiveDate = res.FlgEffectiveDate;
                    oDetailList = res.MstGratuityDetails;
                    oDetail = oDetailList.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenEditDialog(DialogOptions options, MstGratuityDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaGratuity", oDetailPara);
                parameters.Add("DialogFor", "GratuitySetup");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    var res = (MstGratuityDetail)result.Data;
                    var update = oDetailList.Where(x => x.Description == res.Description).FirstOrDefault();
                    if (update != null)
                    {
                        oDetail.Remove(update);
                    }
                    MstGratuityDetail oGratuityDetail = new MstGratuityDetail();
                    oGratuityDetail.Id = res.Id;
                    oGratuityDetail.GratId = res.GratId;
                    oGratuityDetail.Description = res.Description;
                    oGratuityDetail.FromPoints = res.FromPoints;
                    oGratuityDetail.ToPoints = res.ToPoints;
                    oGratuityDetail.DaysCount = res.DaysCount;
                    //oGratuityDetail.UpdateBy = LoginUser;
                    oDetail.Add(oGratuityDetail);
                    oDetailList = oDetail.ToList();
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenAddDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "GratuitySetup");
                var dialog = Dialog.Show<ProcessDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstGratuityDetail)result.Data;

                    //res.UserId = LoginUser;
                    oDetail.Add(res);
                    oDetailList = oDetail;
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
                if (!string.IsNullOrWhiteSpace(oModel.GrtCode) && !string.IsNullOrWhiteSpace(oModel.BasedOn) && oDetailList.Count() > 0)
                {
                    if (oList.Where(x => x.GrtCode.Trim().ToLowerInvariant() == oModel.GrtCode.Trim().ToLowerInvariant()).Count() > 0 && oModel.Id == 0)
                    {
                        Snackbar.Add(oModel.Code + " : Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.MstGratuityDetails = oDetailList.ToList();
                        if (oModel.Id == 0)
                        {
                            oModel.UserId = LoginUser;
                            res = await _mstGratuity.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstGratuity.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Gratuity", forceLoad: true);
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
                Navigation.NavigateTo("/Gratuity", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllGratuity()
        {
            try
            {
                oList = await _mstGratuity.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstGratuity element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.GrtCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.BasedOn.Equals(searchString1))
                return true;
            if (element.FlgWopleaves.Equals(searchString1))
                return true;
            return false;
        }

        public void RemoveRecord(string LineNum)
        {
            try
            {
                var res = oDetail.Where(x => x.Description == LineNum).FirstOrDefault();
                oDetail.Remove(res);
                //if (oDetail.Count() == 0)
                //{
                oDetailList = oDetail;
                //}
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
                    //var res = await _administrationService.FetchUserAuth(Session.UserCode);
                    Loading = true;
                    oModel.BasedOnValue = 0;
                    oModel.FlgWopleaves = true;
                    oModel.FlgAbsoluteYears = true;
                    oModel.FlgEffectiveDate = true;
                    await GetAllGratuity();
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
