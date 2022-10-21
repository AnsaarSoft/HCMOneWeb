using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class AttendanceRule
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstAttendanceRules _mstAttendanceRule { get; set; }

        [Inject]
        public IMstLeaveType _mstLeaveType { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;

        bool DisabledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string searchString1 = "";

        private TimeSpan? GPBeforeStartTime = new TimeSpan();
        private TimeSpan? GPAfterStartTime = new TimeSpan();
        private TimeSpan? GPAfterTimeEnd = new TimeSpan();
        private TimeSpan? GPBeforeTimeEnd = new TimeSpan();
        private bool FilterFunc(MstAttendanceRule element) => FilterFunc(element, searchString1);

        MstAttendanceRule oModel = new MstAttendanceRule();

        private IEnumerable<MstAttendanceRule> oList = new List<MstAttendanceRule>();
        private IEnumerable<MstLeaveType> oListLeaveType = new List<MstLeaveType>();

        #endregion
        #region Functions
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                oModel.GpAfterStartTime = GPAfterStartTime.ToString();
                oModel.GpAfterTimeEnd = GPAfterTimeEnd.ToString();
                oModel.GpBeforeStartTime = GPBeforeStartTime.ToString();
                oModel.GpBeforeTimeEnd = GPBeforeTimeEnd.ToString();
                if (oModel.Id >= 0)
                {
                    //oModel.UpdateBy = LoginUser;
                    res = await _mstAttendanceRule.Update(oModel);
                }

                if (res != null && res.Id == 1)
                {

                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/AttendanceRule", forceLoad: true);
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
        private async Task<ApiResponseModel> Save2()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                //if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description))
                //{
                //if (oList.Where(x => x.Code == oModel.Code).Count() > 0)
                //{
                //    Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
                //else
                //{
                //if (oModel.Code.Length > 20)
                //{
                //    Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
                //else
                //{
                oModel.GpAfterStartTime = GPAfterStartTime.ToString();
                oModel.GpAfterTimeEnd = GPAfterTimeEnd.ToString();
                oModel.GpBeforeStartTime = GPBeforeStartTime.ToString();
                oModel.GpBeforeTimeEnd = GPBeforeTimeEnd.ToString();
                if (oModel.Id >= 0)
                {
                    res = await _mstAttendanceRule.Insert(oModel);
                }
                else
                {
                    res = await _mstAttendanceRule.Update(oModel);
                }
                //}
                //}
                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/AttendanceRule", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                //oModel.FlgActive = true;
                //oModel.FlgDefault = true;
                //}
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
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
                Navigation.NavigateTo("/AttendanceRule", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAttendanceRuleConfig()
        {
            try
            {
                oModel = await _mstAttendanceRule.GetAllData();
                GPAfterStartTime = TimeSpan.Parse(oModel.GpAfterStartTime);
                GPAfterTimeEnd = TimeSpan.Parse(oModel.GpAfterTimeEnd);
                GPBeforeStartTime = TimeSpan.Parse(oModel.GpBeforeStartTime);
                GPBeforeTimeEnd = TimeSpan.Parse(oModel.GpBeforeTimeEnd);

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLeaveType()
        {
            try
            {
                oListLeaveType = await _mstLeaveType.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstAttendanceRule element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            //if (element.FlgDefault.Equals(searchString1))
            //    return true;
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
                    oModel = new MstAttendanceRule();
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

                    oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    //DisabledCode = true;
                    //oModel.Description = res.Description;

                    //oModel.FlgActive = res.FlgActive;
                    //oModel.FlgDefault = res.FlgDefault;
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
                    //oModel.FlgActive = true;
                    await GetAttendanceRuleConfig();
                    await GetAllLeaveType();
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
