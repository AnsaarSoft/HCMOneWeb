using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Loans
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLoans _mstLoans { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public IMstGratuity _mstGratuity { get; set; }
        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;

        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string searchString1 = "";
        private bool FilterFunc(MstLoan element) => FilterFunc(element, searchString1);

        MstLoan oModel = new MstLoan();
        private IEnumerable<MstLoan> oList = new List<MstLoan>();
        private IEnumerable<MstElement> oListElement = new List<MstElement>();
        private IEnumerable<MstGratuity> oListGratuity = new List<MstGratuity>();

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description) || (oModel.FlgPf == true && !string.IsNullOrWhiteSpace(oModel.ElementCode))
                    || (oModel.FlgGratuity == true && !string.IsNullOrWhiteSpace(oModel.GratuityCode)))
                {
                    if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        if (oModel.Code.Length > 20)
                        {
                            Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                        else
                        {
                            if (oModel.Id == 0)
                            {
                                oModel.UserId = LoginUser;
                                res = await _mstLoans.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUser;
                                res = await _mstLoans.Update(oModel);
                            }
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Loans", forceLoad: true);
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
                Navigation.NavigateTo("/Loans", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
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
        private async Task GetAllGratuity()
        {
            try
            {
                oListGratuity = await _mstGratuity.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLoans()
        {
            try
            {
                oList = await _mstLoans.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstLoan element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ElementCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.GratuityCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
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
                    oModel = new MstLoan();
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
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

                    oModel = res;
                    //oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    DisabledCode = true;
                    //oModel.Description = res.Description;

                    //oModel.FlgActive = res.FlgActive;

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
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    var res = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res.Where(x => x.CMenuID == 35 && x.UserRights == true).ToList().Count > 0)
                    {

                        oModel.FlgActive = true;
                        oModel.LoanValue = 0;
                        oModel.TotalLoanCap = 0;
                        oModel.Pfcap = 0;
                        await GetAllLoans();
                        await GetAllElements();
                        await GetAllGratuity();
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
