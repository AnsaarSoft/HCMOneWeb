using Blazored.LocalStorage;
using ClosedXML.Excel;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Text.RegularExpressions;
using System.Reflection;
using DocumentFormat.OpenXml;

namespace HCM.UI.Pages.Batch
{
    public partial class BatchProcessing
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public ITrnsElementTransaction _trnsElementTransaction { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";
        IList<IBrowserFile> excelSheet = new List<IBrowserFile>();

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchString = "";
        private bool FilterFuncFiltered(TrnsBatchesDetail element) => FilterFuncFiltered(element, searchString);

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<MstElementLink> oListPayrollElementLink = new List<MstElementLink>();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        private IEnumerable<MstElement> oElementListPer = new List<MstElement>();
        private IEnumerable<MstElement> oElementListFilter = new List<MstElement>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<TrnsEmployeeElement> oListEmployeeElement = new List<TrnsEmployeeElement>();
        private IEnumerable<TrnsEmployeeElementDetail> oListEmployeeElementDetail = new List<TrnsEmployeeElementDetail>();

        TrnsBatch oModel = new TrnsBatch();
        TrnsBatchesDetail oModelDetail = new TrnsBatchesDetail();
        List<TrnsBatch> oBatchAddList = new List<TrnsBatch>();
        List<TrnsBatch> oBatchUpdateList = new List<TrnsBatch>();
        List<TrnsBatch> oListGridTemp = new List<TrnsBatch>();
        private IEnumerable<TrnsBatch> oListGrid = new List<TrnsBatch>();
        private IEnumerable<TrnsBatch> oList = new List<TrnsBatch>();


        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "Batch");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsBatch)result.Data;
                    oModel = res;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private Task SetDocNo()
        {
            try
            {
                oModel.DocNum = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }

        private async Task GetAllEmployees()
        {
            try
            {
                oListEmployee = await _mstEmployeeMaster.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllPayroll()
        {
            try
            {
                oListPayroll = await _CfgPayrollDefination.GetAllData();
                oListPayroll = oListPayroll.Where(x => x.FlgActive == true).ToList();
                var SelectedPayroll = oListPayroll.FirstOrDefault();
                oListPayrollElementLink = SelectedPayroll.MstElementLinks;

                List<MstElement> oListTemp = new List<MstElement>();

                foreach (var PayrollElement in oListPayrollElementLink)
                {
                    var SelectedElement = oElementListPer.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                    if (SelectedElement != null)
                    {
                        oListTemp.Add(SelectedElement);
                    }
                }
                oElementListFilter = oListTemp.ToList();

                oModel.PayrollId = SelectedPayroll.Id;
                oModel.PayrollName = SelectedPayroll.PayrollName;
                oListPayrollPeriod = SelectedPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModel.PayrollId).ToList();
                var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                oModel.PayrollPeriodId = SelectedPeriod.Id;
                oModel.PayrollPeriod = SelectedPeriod.PeriodName;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async void GetAllPayrollElements()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.PayrollName))
                {
                    var SelectedPayroll = oListPayroll.Where(x => x.PayrollName == oModel.PayrollName).FirstOrDefault();
                    oListPayrollElementLink = SelectedPayroll.MstElementLinks;

                    List<MstElement> oListTemp = new List<MstElement>();
                    foreach (var PayrollElement in oListPayrollElementLink)
                    {
                        var SelectedElement = oElementListPer.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                        if (SelectedElement != null)
                        {
                            oListTemp.Add(SelectedElement);
                        }
                    }
                    oElementListFilter = oListTemp.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async Task GetAllElement()
        {
            try
            {
                oElementListPer = await _mstElement.GetAllData();
                oElementListPer = oElementListPer.Where(x => x.FlgActive == true && x.FlgEmployeeBonus != true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmpElementTransaction()
        {
            try
            {
                oListEmployeeElement = await _trnsElementTransaction.GetAllData();
                //if (oList != null && oList.Count() > 0)
                //{
                //    var SelectedHeader = oListEmployeeElement.Where(x => x.FlgActive == true).FirstOrDefault();
                //    oListEmployeeElementDetail = SelectedHeader.TrnsEmployeeElementDetails;
                //}
                oListEmployeeElement = oListEmployeeElement.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<IEnumerable<CfgPayrollDefination>> SearchPayroll(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPayroll.Select(o => new CfgPayrollDefination
                    {
                        Id = o.Id,
                        PayrollName = o.PayrollName,
                    }).ToList();
                var res = oListPayroll.Where(x => x.PayrollName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new CfgPayrollDefination
                {
                    Id = x.Id,
                    PayrollName = x.PayrollName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private bool FilterFuncFiltered(TrnsBatchesDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmployeeId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ValueType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Value.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmplrCont.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/BatchProcessing", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task SearchCriteria()
        {
            //try
            //{
            //    Loading = true;
            //    await Task.Delay(1);
            //    if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId))
            //        || !string.IsNullOrWhiteSpace(oModelPayroll.PayrollName)
            //        || !string.IsNullOrWhiteSpace(oModelDesignation.Description)
            //        || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName)
            //        || !string.IsNullOrWhiteSpace(oModelLocation.Description)
            //        || !string.IsNullOrWhiteSpace(oModelBranch.Description))
            //    {
            //        oListFilteredEmployee = oListEmployee.Where(x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0 && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
            //                                                    || x.PayrollName == oModelPayroll.PayrollName
            //                                                    || x.DesignationName == oModelDesignation.Description
            //                                                    || x.DepartmentName == oModelDepartment.DeptName
            //                                                    || x.LocationName == oModelLocation.Description
            //                                                    || x.BranchName == oModelBranch.Description).ToList();
            //        oModel.TrnsEmployeeBonusDetails.Clear();
            //        if (oModel.ElementType > 0)
            //        {
            //            foreach (var Employee in oListFilteredEmployee)
            //            {
            //                TrnsEmployeeBonusDetail oDetail = new TrnsEmployeeBonusDetail();
            //                var CheckElementInEmployeePayroll = oListPayrollElementLink.Where(x => x.PayrollId == Employee.PayrollId).FirstOrDefault();
            //                if (CheckElementInEmployeePayroll != null)
            //                {
            //                    oDetail.EmployeeId = Employee.Id;
            //                    oDetail.EmployeeName = Employee.FirstName + " " + Employee.MiddleName + " " + Employee.LastName;
            //                    oDetail.BasicSalary = Employee.BasicSalary;
            //                    var GetEmployeeCalculatedGross = oListEmployeeElement.Where(x => x.EmployeeId == Employee.Id).FirstOrDefault();
            //                    if (GetEmployeeCalculatedGross != null)
            //                    {
            //                        oDetail.GrossSalary = GetEmployeeCalculatedGross.EmpGrossSalary;
            //                    }
            //                    else
            //                    {
            //                        oDetail.GrossSalary = Employee.GrossSalary;
            //                    }
            //                    if (!string.IsNullOrWhiteSpace(Employee.BonusCode))
            //                    {
            //                        var SelectedBonus = oBonusList.Where(x => x.Code == Employee.BonusCode).FirstOrDefault();
            //                        if (Convert.ToDateTime(Employee.JoiningDate).Month >= SelectedBonus.MinimumMonthsDuration)
            //                        {
            //                            oDetail.SlabCode = SelectedBonus.Code;
            //                            oDetail.SalaryRange = SelectedBonus.SalaryFrom + "-" + SelectedBonus.SalaryTo;
            //                            oDetail.Percentage = SelectedBonus.BonusPercentage;
            //                            oDetail.FlgActive = true;
            //                            if (SelectedBonus.ValueType == "POB")
            //                            {
            //                                if (Employee.BasicSalary >= SelectedBonus.SalaryFrom && Employee.BasicSalary <= SelectedBonus.SalaryTo)
            //                                {
            //                                    oDetail.CalculatedAmount = Employee.BasicSalary * (oDetail.Percentage / 100);
            //                                }
            //                            }
            //                            else if (SelectedBonus.ValueType == "POG")
            //                            {
            //                                if (oDetail.GrossSalary >= SelectedBonus.SalaryFrom && oDetail.GrossSalary <= SelectedBonus.SalaryTo)
            //                                {
            //                                    oDetail.CalculatedAmount = oDetail.GrossSalary * (oDetail.Percentage / 100);
            //                                }
            //                            }
            //                            else if (SelectedBonus.ValueType == "FIX")
            //                            {
            //                                oDetail.CalculatedAmount = oDetail.Percentage;
            //                            }
            //                            oModel.TrnsEmployeeBonusDetails.Add(oDetail);
            //                        }
            //                        else
            //                        {
            //                            Snackbar.Add("Joining date is smaller then minimum month on bonus", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            Snackbar.Add("Select Element first", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
            //        }
            //    }
            //    Loading = false;
            //}
            //catch (Exception ex)
            //{
            //    Logs.GenerateLogs(ex);
            //    Loading = false;
            //}
        }
        private async Task DeleteFromFilter(int? ID)
        {
            //try
            //{
            //    Loading = true;
            //    await Task.Delay(1);
            //    List<TrnsEmployeeBonusDetail> oListEmployeeBonusTemp = new List<TrnsEmployeeBonusDetail>();
            //    oListEmployeeBonusTemp = oModel.TrnsEmployeeBonusDetails.ToList();
            //    if (oModel.TrnsEmployeeBonusDetails.Count() > 0)
            //    {
            //        var FilterRecord = oModel.TrnsEmployeeBonusDetails.Where(x => x.EmployeeId == ID).FirstOrDefault();
            //        oListEmployeeBonusTemp.Remove(FilterRecord);
            //        oModel.TrnsEmployeeBonusDetails = oListEmployeeBonusTemp;
            //    }
            //    Loading = false;
            //}
            //catch (Exception ex)
            //{
            //    Logs.GenerateLogs(ex);
            //    Loading = false;
            //}
        }
        private async Task EmployeeValidation()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                //if (oModel.ElementType == 0)
                //{
                //    Snackbar.Add($@"Please fill the required field(s).", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //    IsEmployeeValidate = false;
                //}
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                IsEmployeeValidate = false;
            }
        }
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                //if (oModel.TrnsBatchesDetails.Count() > 0 && oModel.ElementType > 0)
                //{
                //    oModel.UserId = LoginUser;
                //    if (oModel.Id > 0)
                //    {
                //        res = await _trnsEmployeeBonus.Update(oModel);
                //    }
                //    else
                //    {
                //        res = await _trnsEmployeeBonus.Insert(oModel);
                //    }

                //    if (res != null && res.Id == 1)
                //    {
                //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //        await Task.Delay(3000);
                //        Navigation.NavigateTo("/BatchProcessing", forceLoad: true);
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //}
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> ProcessedInSalary()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                List<TrnsEmployeeElement> oListTrnsElementHeaderAdd = new List<TrnsEmployeeElement>();
                List<TrnsEmployeeElement> oListTrnsElementHeaderUpdate = new List<TrnsEmployeeElement>();

                //if (oModel.TrnsEmployeeBonusDetails.Count() > 0 && oModel.ElementType > 0)
                //{
                //    foreach (var EmployeeBonusDetail in oModel.TrnsEmployeeBonusDetails)
                //    {
                //        TrnsEmployeeElement oModelTrnsEmplElement = new TrnsEmployeeElement();
                //        TrnsEmployeeElementDetail oModelTrnsEmplElementDetail = new TrnsEmployeeElementDetail();
                //        oModelTrnsEmplElement = oListEmployeeElement.Where(x => x.EmployeeId == EmployeeBonusDetail.EmployeeId).FirstOrDefault();
                //        var FilterElement = oElementListFilter.Where(x => x.Id == oModel.ElementType).FirstOrDefault();
                //        if (oModelTrnsEmplElement.Id > 0)
                //        {
                //            oModelTrnsEmplElement.UpdatedBy = LoginUser;
                //            oModelTrnsEmplElement.UpdateDate = DateTime.Now;

                //            oModelTrnsEmplElementDetail = oModelTrnsEmplElement.TrnsEmployeeElementDetails.Where(x => x.ElementId == oModel.ElementType && x.PeriodName == oModel.PaysInPeriodCode).FirstOrDefault();
                //            if (oModelTrnsEmplElementDetail == null)
                //            {
                //                oModelTrnsEmplElementDetail = new TrnsEmployeeElementDetail();
                //                oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                //                oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                //                oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                //                oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                //                oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                //                oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                //                oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                //                oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                //                oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                //                oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                //                //oModelTrnsEmplElementDetail.EmpContr = 0;
                //                //oModelTrnsEmplElementDetail.EmplrContr = 0;
                //                oModelTrnsEmplElement.TrnsEmployeeElementDetails.Add(oModelTrnsEmplElementDetail);
                //                oListTrnsElementHeaderUpdate.Add(oModelTrnsEmplElement);
                //            }
                //            //else
                //            //{
                //            //    oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                //            //    oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                //            //    oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                //            //    oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                //            //    oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                //            //    oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                //            //    oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                //            //    oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                //            //    oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                //            //    oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                //            //    //oModelTrnsEmplElementDetail.EmpContr = 0;
                //            //    //oModelTrnsEmplElementDetail.EmplrContr = 0;
                //            //    oModelTrnsEmplElement.TrnsEmployeeElementDetails. Add(oModelTrnsEmplElementDetail);
                //            //    oListTrnsElementHeaderUpdate.Add(oModelTrnsEmplElement);
                //            //}
                //        }
                //        else
                //        {
                //            oModelTrnsEmplElement.EmployeeId = EmployeeBonusDetail.EmployeeId;
                //            oModelTrnsEmplElement.UserId = LoginUser;
                //            oModelTrnsEmplElement.CreateDate = DateTime.Now;
                //            oModelTrnsEmplElement.FlgActive = true;

                //            oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                //            oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                //            oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                //            oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                //            oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                //            oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                //            oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                //            oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                //            oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                //            oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                //            oModelTrnsEmplElementDetail.EmpContr = 0;
                //            oModelTrnsEmplElementDetail.EmplrContr = 0;
                //            oModelTrnsEmplElement.TrnsEmployeeElementDetails.Add(oModelTrnsEmplElementDetail);
                //            oListTrnsElementHeaderAdd.Add(oModelTrnsEmplElement);
                //        }
                //    }

                //    if (oListTrnsElementHeaderAdd.Count > 0)
                //    {
                //        res = await _trnsElementTransaction.Insert(oListTrnsElementHeaderAdd);
                //    }
                //    if (oListTrnsElementHeaderUpdate.Count > 0)
                //    {
                //        res = await _trnsElementTransaction.Update(oListTrnsElementHeaderUpdate);
                //    }
                //    if (res != null && res.Id == 1)
                //    {
                //        if (oModel.Id > 0)
                //        {
                //            oModel.Status = "Posted";
                //            res = await _trnsEmployeeBonus.Update(oModel);
                //        }
                //        else
                //        {
                //            res = await _trnsEmployeeBonus.Insert(oModel);
                //        }

                //        if (res != null && res.Id == 1)
                //        {
                //            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //            await Task.Delay(3000);
                //            Navigation.NavigateTo("/EmployeeBonus", forceLoad: true);
                //        }
                //        else
                //        {
                //            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //        }
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //}
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                        Snackbar.Add("Please wait template uploading in process...", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await FillBatchDetailGrid();
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

        private async Task FillBatchDetailGrid()
        {
            try
            {
                Loading = true;
                _ = InvokeAsync(StateHasChanged);
                await Task.Delay(1);
                bool IsForUpdate = false;
                var TemplateFile = excelSheet.Select(x => x.Name).FirstOrDefault();
                TemplateFile = Path.GetFullPath("wwwroot\\Templates\\" + TemplateFile);
                if (!string.IsNullOrWhiteSpace(TemplateFile))
                {
                    Stream stream = excelSheet.FirstOrDefault().OpenReadStream();
                    FileStream fs = File.Create(TemplateFile);
                    await stream.CopyToAsync(fs);
                    stream.Close();
                    fs.Close();
                    using var workBook = new XLWorkbook(TemplateFile);
                    var ws = workBook.Worksheet("Batch");

                    Type type = typeof(VMTrnsBatchesDetail);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelDetail = new TrnsBatchesDetail();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelDetail." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmployeeCode")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                //else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "EmpCode")
                                //{
                                //    //Skip the line if Code has special character
                                //    break;
                                //}
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Employee and his payroll
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmployeeCode")
                                {
                                    var CheckList = oListEmployee.Where(x => x.EmpId == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        if (CheckList.PayrollName == oModel.PayrollName)
                                        {
                                            oModelDetail.GetType().GetProperty(PropertyName).SetValue(oModelDetail, StringValue, null);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmployeeName")
                                {
                                    var CheckList = oListEmployee.Where(x => x.EmpId == oModelDetail.EmployeeCode).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        StringValue = CheckList.FirstName;
                                        oModelDetail.GetType().GetProperty(PropertyName).SetValue(oModelDetail, StringValue, null);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }                                
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(decimal))
                            {
                                var DecimalValue = Convert.ToDecimal(ws.Cell(i, j).Value.ToString());
                                oModelDetail.GetType().GetProperty(PropertyName).SetValue(oModelDetail, DecimalValue, null);
                            }
                        }
                        //if (!string.IsNullOrWhiteSpace(oModelContractor.Code) && !IsForUpdate)
                        //{
                        //    var CheckDuplicate = oContractorAddList.Where(x => x.Code == oModelContractor.Code).FirstOrDefault();
                        //    if (CheckDuplicate == null)
                        //    {
                        //        oContractorAddList.Add(oModelContractor);
                        //    }
                        //}
                        //else if (!string.IsNullOrWhiteSpace(oModelContractor.Code) && IsForUpdate)
                        //{
                        //    var CheckDuplicate = oContractorUpdateList.Where(x => x.Code == oModelContractor.Code).FirstOrDefault();
                        //    if (CheckDuplicate == null)
                        //    {
                        //        oContractorUpdateList.Add(oModelContractor);
                        //    }
                        //}
                        oModel.TrnsBatchesDetails.Add(oModelDetail);
                    }
                    //if (oContractorUpdateList.Count >= 0 && oContractorAddList.Count >= 0)
                    //{
                    //    oListContractorGridTemp.AddRange(oContractorAddList);
                    //    oListContractorGridTemp.AddRange(oContractorUpdateList);
                    //}
                    ////else if(!IsForUpdate && oContractorAddList.Count > 0)
                    ////{
                    ////        oListContractorGridTemp.AddRange(oContractorAddList);
                    ////}
                    //oListContractorGrid = oListContractorGridTemp;
                    File.Delete(TemplateFile);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
            _ = InvokeAsync(StateHasChanged);
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
                    oModel.DocStatus = "Created";
                    await SetDocNo();
                    await GetAllEmployees();
                    await GetAllElement();
                    await GetAllPayroll();
                    await GetAllEmpElementTransaction();
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
