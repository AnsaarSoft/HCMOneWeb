using Blazored.LocalStorage;
using ClosedXML.Excel;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.Attendance;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.Reports;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace HCM.UI.Pages.Reports
{
    public partial class ReportUpload
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        [Inject]
        public IMstReport _mstReport { get; set; }

        [Inject]
        public IMstForm _mstForm { get; set; }

        //[Inject]
        //public Imstmenu { get; set; }

        IList<IBrowserFile> excelSheet = new List<IBrowserFile>();

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool ReportCode = false;
        bool ReportType = false;
        bool DocumentType = false;
        string FlgLayout = "";
        int ModuleType = 0;
        string AlphanumericMask = @"^[a-zA-Z0-9_]*$";


        MstDepartment oModelDepartment = new MstDepartment();
        List<MstDepartment> oDepartmentAddList = new List<MstDepartment>();
        List<MstDepartment> oDepartmentUpdateList = new List<MstDepartment>();
        List<MstDepartment> oListDepartmentGridTemp = new List<MstDepartment>();
        private IEnumerable<MstDepartment> oListDepartmentGrid = new List<MstDepartment>();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();


        private string searchStringReport = "";
        private bool FilterFuncReport(MstReport element) => FilterFuncReport(element, searchStringReport);
        MstForm oModelForm = new MstForm();
        private IEnumerable<MstForm> oListForm = new List<MstForm>();

        MstReport oModel = new MstReport();
        private IEnumerable<MstReport> oList = new List<MstReport>();
        #endregion

        #region Functions

        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            try
            {
                Loading = true;
                if (excelSheet.Count > 0)
                {
                    Snackbar.Add("Template already selected, refresh the page for new template to import.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                else
                {
                    var TemplateFile = e.File.Name;
                    excelSheet.Add(e.File);
                    if (!string.IsNullOrWhiteSpace(TemplateFile))
                    {
                        Snackbar.Add("Report Has been loaded...", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        if (!string.IsNullOrWhiteSpace(oModel.FilePath))
                        {
                            oModel.FilePath = "";
                        }
                    }
                    else
                    {
                        Snackbar.Add("Select template to import", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        excelSheet.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        private async Task GetAllForms()
        {
            try
            {
                oListForm = await _mstForm.GetAllData();
                oListForm = oListForm.Where(x => x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task<IEnumerable<MstForm>> SearchForm(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListForm.Select(o => new MstForm
                    {
                        FormCode = o.FormCode,
                        FormName = o.FormName,
                    }).ToList();
                var res = oListForm.Where(x => x.FormName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstForm
                {
                    FormCode = x.FormCode,
                    FormName = x.FormName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task GetAllReports()
        {
            try
            {
                oList = await _mstReport.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncReport(MstReport element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringReport))
                return true;
            if (element.ReportCode.Contains(searchStringReport, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ReportName.Contains(searchStringReport, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringReport))
                return true;
            return false;
        }
        void selectReportType(string value)
        {
            FlgLayout = value;
            if (value == "Report")
            {
                DocumentType = true;
                oModel.FlgLayout = false;
            }
            else if (value == "Layout")
            {
                oModel.FlgLayout = true;
                DocumentType = false;
            }
        }
        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    oModel.Id = res.Id;
                    oModel.ReportCode = res.ReportCode;
                    oModel.ReportName = res.ReportName;
                    oModel.FlgLayout = res.FlgLayout;
                    oModel.ReportDoc = res.ReportDoc;
                    oModel.FlgActive = res.FlgActive;
                    oModel.FilePath = res.FilePath;
                    oModel.CreatedBy = res.CreatedBy;
                    oModel.CreatedDate = res.CreatedDate;
                    DocumentType = true;
                    ReportType = true;
                    ReportCode = true;
                    FlgLayout = "Report";
                    if (oModel.FlgLayout == true)
                    {
                        FlgLayout = "Layout";
                    }
                    // File.Delete(oModel.FilePath);
                    if (oModel.ReportDoc != null)
                    {
                        oModelForm = oListForm.Where(x => x.FormName == oModel.ReportDoc).FirstOrDefault();
                    }
                    oList = oList.Where(x => x.Id != LineNum);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/ReportUpload", forceLoad: true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);

                if (oList.Where(x => x.ReportCode.Trim().ToLowerInvariant() == oModel.ReportCode.Trim().ToLowerInvariant()).Count() > 0)
                {
                    Snackbar.Add(oModel.ReportCode + " : is Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                else
                {
                    var TemplateFile = excelSheet.Select(x => x.Name).FirstOrDefault();
                    TemplateFile = Path.GetFullPath("wwwroot\\Reports\\" + TemplateFile);
                    if (!string.IsNullOrWhiteSpace(oModel.ReportCode) && !string.IsNullOrWhiteSpace(oModel.ReportName) && !string.IsNullOrWhiteSpace(FlgLayout) && (excelSheet.Count > 0 || !string.IsNullOrWhiteSpace(oModel.FilePath)))
                    {
                        oModel.ReportDoc = oModelForm.FormName;
                        if (string.IsNullOrWhiteSpace(oModel.FilePath))
                        {
                            Stream stream = excelSheet.FirstOrDefault().OpenReadStream();
                            FileStream fs = File.Create(TemplateFile);
                            oModel.FilePath = TemplateFile;
                            await stream.CopyToAsync(fs);
                            stream.Close();
                            fs.Close();
                            excelSheet.Clear();
                        }

                        if (oModel.Id == 0)
                        {
                            oModel.CreatedBy = LoginUser;
                            res = await _mstReport.Insert(oModel);
                        }
                        else
                        {
                            oModel.UpdatedBy = LoginUser;
                            res = await _mstReport.Update(oModel);
                        }
                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(3000);
                            Navigation.NavigateTo("/ReportUpload", forceLoad: true);
                        }
                        else
                        {
                            File.Delete(TemplateFile);
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                    }
                    else
                    {
                        Snackbar.Add("Please fill the required field(s) Or Report Has Not Upload...", Severity.Error, (options) => { options.Icon = Icons.Sharp.Info; });

                    }
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
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    oModel.FlgActive = true;
                    await GetAllReports();
                    //
                    await GetAllForms();
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
