using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Calendar
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }


        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledDate = false;
        private string searchString1 = "";
        private bool FilterFunc(MstCalendar element) => FilterFunc(element, searchString1);

        MstCalendar oModel = new MstCalendar();
        private IEnumerable<MstCalendar> oList = new List<MstCalendar>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description))
                {
                    if (oList.Where(x => x.Code == oModel.Code).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.StartDate = _dateRange.Start;
                        oModel.EndDate = _dateRange.End;
                        if (oModel.Id == 0)
                        {
                            res = await _mstCalendar.Insert(oModel);
                        }
                        else
                        {
                            res = await _mstCalendar.Update(oModel);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Calendar", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel.FlgActive = true;
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
                Navigation.NavigateTo("/Calendar", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllCalendars()
        {
            try
            {
                oList = await _mstCalendar.GetAllData();                       
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstCalendar element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.StartDate.Equals(searchString1))
                return true;
            if (element.EndDate.Equals(searchString1))
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
                    oModel = new MstCalendar();
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
                    DisbaledDate = true;
                    oModel.Id = res.Id;
                    oModel.Code = res.Code;
                    oModel.Description = res.Description;
                    oModel.StartDate = _dateRange.Start = res.StartDate;
                    oModel.EndDate = _dateRange.End = res.EndDate;
                    _dateRange = new DateRange(oModel.StartDate, oModel.EndDate);
                    oModel.FlgActive = res.FlgActive;
                    oList = oList.Where(x => x.Id != LineNum);                    
                    //_ = InvokeAsync(StateHasChanged);
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
                oModel.FlgActive = true;                
                await GetAllCalendars();
                if (oList.Count() > 0)
                {
                    var res = oList.Where(x => x.FlgActive == true).Max(x => x.EndDate);
                    _dateRange = new DateRange(res.Value, res.Value);
                    _dateRange.Start = MinDate = res.Value;
                }
                else
                {
                    MinDate = DateTime.Now.Date;
                    _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
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
