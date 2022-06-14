using HCM.UI.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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


        #endregion

        #region Variables

        bool Loading = false;

        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string searchString1 = "";

        private bool FilterFunc(MstEmailConfig element) => FilterFunc(element);

        MstPayrollBasicInitialization oModel = new MstPayrollBasicInitialization();
        #endregion

        #region Functions

        private async Task<ApiResponseModel> Update()
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

                await GetPayrollinit();

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