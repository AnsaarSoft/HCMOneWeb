using HCM.UI.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Blazored.LocalStorage;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Payrollinit
    {
        #region InjectService


        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstPayrollinit _mstPayrollinit { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;

        
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        

        private bool FilterFunc(MstEmailConfig element) => FilterFunc(element);

        MstPayrollBasicInitialization oModel = new MstPayrollBasicInitialization();
        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                
                    if (oModel.Id >= 0)
                    {
                        res = await _mstPayrollinit.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {

                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Payrollinit", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                Navigation.NavigateTo("/Payrollinit", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetPayrollinit()
        {
            try
            {
                oModel = await _mstPayrollinit.GetData();
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

                    await GetPayrollinit();
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