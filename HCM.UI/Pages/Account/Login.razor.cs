using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.Account
{
    public partial class Login
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstUser _mstUser { get; set; }

        #endregion

        #region Variables

        bool Loading = false;
        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        MstUser oModel = new MstUser();

        #endregion

        #region Functions

        void VisiblePassword()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private async Task<MstUser> ValidateLogin()
        {
            try
            {
                Loading = true;
                var res = new MstUser();
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.UserCode) && !string.IsNullOrWhiteSpace(oModel.PassCode))
                {
                    oModel.UserName = "";
                    oModel.Email = "";
                    oModel.FlgActiveUser = true;
                    oModel.FlgPasswordRequest = false;
                    res = await _mstUser.Login(oModel);
                    if (res.Id != 0 && !string.IsNullOrWhiteSpace(res.UserName))
                    {
                        Snackbar.Add("Welcome: " + res.UserCode, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        Navigation.NavigateTo("/Dashboard", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add("Username/Password incorrect", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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

        #endregion
    }
}
