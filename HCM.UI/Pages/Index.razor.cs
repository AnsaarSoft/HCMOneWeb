using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages
{
    public partial class Index
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ILocalStorageService _oLocalStorage { get; set; }

        #endregion

        #region Variables

        bool Loading = false;

        #endregion

        #region Functions        

        #endregion

        #region Events

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                Loading = true;                
                var res = await _oLocalStorage.GetItemAsync<MstUser>("User");
                if(res == null)
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
