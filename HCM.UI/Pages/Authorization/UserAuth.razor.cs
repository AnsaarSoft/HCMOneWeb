using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor;

namespace HCM.UI.Pages.Authorization
{
    public partial class UserAuth
    {
        #region Inject Service

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IUserAuthorization UserAuthorization { get; set; }

        #endregion

        #region Variables

        private bool Loading = false;
        private bool CheckedAll = false;

        private string LoginUser = "";

        MstEmployee oModelEmployee = new MstEmployee();

        private IEnumerable<VMUserAuthorization> oList = new List<VMUserAuthorization>();

        private HashSet<MstEmployee> SelectedEmployee = new HashSet<MstEmployee>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        MudTable<VMUserAuthorization> TableRef { get; set; }

        #endregion

        #region Function

        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelEmployee = res;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenCopyDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "MultipleEmployeeSelect");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = result.Data;
                    SelectedEmployee = (HashSet<MstEmployee>)result.Data;
                }

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private TableGroupDefinition<VMUserAuthorization> _groupDefinition = new()
        {
            GroupName = "Module Name ",
            Indentation = false,
            Expandable = true,
            IsInitiallyExpanded = false,
            Selector = (e) => e.PMenuName

        };

        public async void Save()
        {
            if (oModelEmployee.EmpId == null)
            {
                Snackbar.Add("Select Employee.", Severity.Error, (options) => { options.Icon = Icons.Sharp.DoneAll; });
                return;
            }
            List<UserAuthorization> oUserAuthorizationList = new List<UserAuthorization>();
            if (SelectedEmployee.Count > 0)
            {
                foreach (var item1 in SelectedEmployee)
                {
                    foreach (var item in oList)
                    {
                        var check = oList.Where(x => x.PMenuID == item.PMenuID && x.UserRights == true).FirstOrDefault();
                        if (check != null)
                        {
                            var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID && x.FkuserId == item1.EmpId).FirstOrDefault();
                            if (checkParent == null)
                            {
                                UserAuthorization oUserAuthorization = new UserAuthorization();
                                oUserAuthorization.FkuserId = item1.EmpId;
                                oUserAuthorization.MenuName = item.PMenuName;
                                oUserAuthorization.UserRights = 2;
                                oUserAuthorization.FkmenuId = item.PMenuID;
                                if (item.ID == 0)
                                {
                                    oUserAuthorization.CreatedBy = LoginUser;
                                    oUserAuthorization.CreatedDate = DateTime.Now;
                                }
                                else
                                {
                                    oUserAuthorization.CreatedBy = item.CreatedBy;
                                    oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                    oUserAuthorization.UpdatedBy = LoginUser;
                                    oUserAuthorization.UpdatedDate = DateTime.Now;
                                }
                                oUserAuthorizationList.Add(oUserAuthorization);
                            }
                        }
                        else
                        {
                            var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID && x.FkuserId == item1.EmpId).FirstOrDefault();
                            if (checkParent == null)
                            {
                                UserAuthorization oUserAuthorization = new UserAuthorization();
                                oUserAuthorization.FkuserId = item1.EmpId;
                                oUserAuthorization.MenuName = item.PMenuName;
                                oUserAuthorization.UserRights = 1;
                                oUserAuthorization.FkmenuId = item.PMenuID;
                                if (item.ID == 0)
                                {
                                    oUserAuthorization.CreatedBy = LoginUser;
                                    oUserAuthorization.CreatedDate = DateTime.Now;
                                }
                                else
                                {
                                    oUserAuthorization.CreatedBy = item.CreatedBy;
                                    oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                    oUserAuthorization.UpdatedBy = LoginUser;
                                    oUserAuthorization.UpdatedDate = DateTime.Now;
                                }
                                oUserAuthorizationList.Add(oUserAuthorization);
                            }
                        }
                        var checkChild = oList.Where(x => x.CMenuID == item.CMenuID && x.UserRights == true).FirstOrDefault();
                        if (checkChild != null)
                        {
                            UserAuthorization oUserAuthorization = new UserAuthorization();
                            oUserAuthorization.FkuserId = item1.EmpId;
                            oUserAuthorization.MenuName = item.CMenuName;
                            oUserAuthorization.UserRights = 2;
                            oUserAuthorization.FkmenuId = item.CMenuID;
                            if (item.ID == 0)
                            {
                                oUserAuthorization.CreatedBy = LoginUser;
                                oUserAuthorization.CreatedDate = DateTime.Now;
                            }
                            else
                            {
                                oUserAuthorization.CreatedBy = item.CreatedBy;
                                oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                oUserAuthorization.UpdatedBy = LoginUser;
                                oUserAuthorization.UpdatedDate = DateTime.Now;
                            }
                            oUserAuthorizationList.Add(oUserAuthorization);
                        }
                        else
                        {
                            UserAuthorization oUserAuthorization = new UserAuthorization();
                            oUserAuthorization.FkuserId = item1.EmpId;
                            oUserAuthorization.MenuName = item.CMenuName;
                            oUserAuthorization.UserRights = 1;
                            oUserAuthorization.FkmenuId = item.CMenuID;
                            if (item.ID == 0)
                            {
                                oUserAuthorization.CreatedBy = LoginUser;
                                oUserAuthorization.CreatedDate = DateTime.Now;
                            }
                            else
                            {
                                oUserAuthorization.CreatedBy = item.CreatedBy;
                                oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                oUserAuthorization.UpdatedBy = LoginUser;
                                oUserAuthorization.UpdatedDate = DateTime.Now;
                            }
                            oUserAuthorizationList.Add(oUserAuthorization);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in oList)
                {
                    var check = oList.Where(x => x.PMenuID == item.PMenuID && x.UserRights == true).FirstOrDefault();
                    if (check != null)
                    {
                        var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID).FirstOrDefault();
                        if (checkParent == null)
                        {
                            UserAuthorization oUserAuthorization = new UserAuthorization();
                            oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                            oUserAuthorization.MenuName = item.PMenuName;
                            oUserAuthorization.UserRights = 2;
                            oUserAuthorization.FkmenuId = item.PMenuID;
                            if (item.ID == 0)
                            {
                                oUserAuthorization.CreatedBy = LoginUser;
                                oUserAuthorization.CreatedDate = DateTime.Now;
                            }
                            else
                            {
                                oUserAuthorization.CreatedBy = item.CreatedBy;
                                oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                oUserAuthorization.UpdatedBy = LoginUser;
                                oUserAuthorization.UpdatedDate = DateTime.Now;
                            }
                            oUserAuthorizationList.Add(oUserAuthorization);
                        }
                    }
                    else
                    {
                        var checkParent = oUserAuthorizationList.Where(x => x.FkmenuId == item.PMenuID).FirstOrDefault();
                        if (checkParent == null)
                        {
                            UserAuthorization oUserAuthorization = new UserAuthorization();
                            oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                            oUserAuthorization.MenuName = item.PMenuName;
                            oUserAuthorization.UserRights = 1;
                            oUserAuthorization.FkmenuId = item.PMenuID;
                            if (item.ID == 0)
                            {
                                oUserAuthorization.CreatedBy = LoginUser;
                                oUserAuthorization.CreatedDate = DateTime.Now;
                            }
                            else
                            {
                                oUserAuthorization.CreatedBy = item.CreatedBy;
                                oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                                oUserAuthorization.UpdatedBy = LoginUser;
                                oUserAuthorization.UpdatedDate = DateTime.Now;
                            }
                            oUserAuthorizationList.Add(oUserAuthorization);
                        }
                    }
                    var checkChild = oList.Where(x => x.CMenuID == item.CMenuID && x.UserRights == true).FirstOrDefault();
                    if (checkChild != null)
                    {
                        UserAuthorization oUserAuthorization = new UserAuthorization();
                        oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                        oUserAuthorization.MenuName = item.CMenuName;
                        oUserAuthorization.UserRights = 2;
                        oUserAuthorization.FkmenuId = item.CMenuID;
                        if (item.ID == 0)
                        {
                            oUserAuthorization.CreatedBy = LoginUser;
                            oUserAuthorization.CreatedDate = DateTime.Now;
                        }
                        else
                        {
                            oUserAuthorization.CreatedBy = item.CreatedBy;
                            oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                            oUserAuthorization.UpdatedBy = LoginUser;
                            oUserAuthorization.UpdatedDate = DateTime.Now;
                        }
                        oUserAuthorizationList.Add(oUserAuthorization);
                    }
                    else
                    {
                        UserAuthorization oUserAuthorization = new UserAuthorization();
                        oUserAuthorization.FkuserId = oModelEmployee.EmpId;
                        oUserAuthorization.MenuName = item.CMenuName;
                        oUserAuthorization.UserRights = 1;
                        oUserAuthorization.FkmenuId = item.CMenuID;
                        if (item.ID == 0)
                        {
                            oUserAuthorization.CreatedBy = LoginUser;
                            oUserAuthorization.CreatedDate = DateTime.Now;
                        }
                        else
                        {
                            oUserAuthorization.CreatedBy = item.CreatedBy;
                            oUserAuthorization.CreatedDate = Convert.ToDateTime(item.CreatedDate);
                            oUserAuthorization.UpdatedBy = LoginUser;
                            oUserAuthorization.UpdatedDate = DateTime.Now;
                        }
                        oUserAuthorizationList.Add(oUserAuthorization);
                    }
                }
            }
            var res = await UserAuthorization.AddUserAuthorization(oUserAuthorizationList);
            if (res != null && res.Id == 1)
            {
                Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                await Task.Delay(3000);
                Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
            }
            else
            {
                Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
            }
            Loading = false;
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/UserAuth", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllAuthMenu()
        {
            try
            {
                oList = await UserAuthorization.GetAllAuthorizationMenu(oModelEmployee.EmpId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Initialized

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                }
                else
                {
                    Navigation.NavigateTo("/Login", true);
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        #endregion
    }
}
