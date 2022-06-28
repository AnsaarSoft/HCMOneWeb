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

        #endregion

        #region Variables 

        bool Loading = false;

        MstPayroll oModel = new MstPayroll();

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
       
        #endregion
    }
}
