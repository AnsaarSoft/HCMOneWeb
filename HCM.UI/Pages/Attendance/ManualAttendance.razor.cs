using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Attendance;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Globalization;

namespace HCM.UI.Pages.Attendance
{
    public partial class ManualAttendance
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ITrnsTempAttendance _trnsTempAttendance { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployee { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variables

        bool Loading = false;
        private string searchString1 = "";
        private string LoginUser = "";
        private TimeSpan? TSPunchTime { get; set; }
        private bool FilterFunc(TrnsTempAttendance element) => FilterFunc(element, searchString1);

        MstEmployee oModelEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();

        TrnsTempAttendance oModel = new TrnsTempAttendance();
        private IEnumerable<TrnsTempAttendance> oList = new List<TrnsTempAttendance>();

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId) && !string.IsNullOrWhiteSpace(oModel.InOut))
                {
                    oModel.EmpId = oModelEmployee.EmpId;
                    oModel.PunchedTime = TSPunchTime.ToString();
                    if (oModel.Id == 0)
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _trnsTempAttendance.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsTempAttendance.Update(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/ManualAttendance", forceLoad: true);
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
                Navigation.NavigateTo("/ManualAttendance", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllEmployee()
        {
            try
            {
                oListEmployee = await _mstEmployee.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllTempAttendance()
        {
            try
            {
                oList = await _trnsTempAttendance.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(TrnsTempAttendance element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.InOut.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PunchedDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PunchedTime.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task<IEnumerable<MstEmployee>> SearchEmployee(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();
                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        public void RemoveRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id != LineNum);
                oList = res;
                if (oList.Count() == 0)
                {
                    oModel = new TrnsTempAttendance();
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
                    oModel = res;
                    TSPunchTime = TimeSpan.Parse(oModel.PunchedTime);
                    oModelEmployee.EmpId = oModel.EmpId;
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    oModel.PunchedDate = DateTime.Now;
                    //var res = await _administrationService.FetchUserAuth(Session.UserCode);
                    oModel.FlgProcessed = false;
                    await GetAllEmployee();
                    await GetAllTempAttendance();
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
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
