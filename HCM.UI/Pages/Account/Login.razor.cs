﻿using HCM.API.Models;
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

        MstEmployee oModel = new MstEmployee();

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

        private async Task<MstEmployee> ValidateLogin()
        {
            try
            {
                Loading = true;
                var res = new MstEmployee();
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.EmpId) && !string.IsNullOrWhiteSpace(oModel.Password))
                {
                    //oModel.EmpId = "";
                    //oModel.OfficeEmail = "";
                    //oModel.FlgActive = true;
                    //oModel.FlgPasswordRequest = false;                    
                    res = await _mstUser.Login(oModel);
                    if (res.Id != 0 && !string.IsNullOrWhiteSpace(res.FirstName))
                    {
                        Snackbar.Add("Welcome: " + res.FirstName, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
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

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(1);
                if (1 == 1)
                {
                    oModel.EmpId = "FT-00001";
                    oModel.Password = "123456";
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
