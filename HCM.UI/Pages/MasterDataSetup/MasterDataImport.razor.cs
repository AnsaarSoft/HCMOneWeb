using Blazored.LocalStorage;
using ClosedXML.Excel;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class MasterDataImport
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }


        [Inject]
        public IMstUser _mstUser { get; set; }

        [Inject]
        public IMstPayroll _mstPayroll { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstContractor _mstContractor { get; set; }

        [Inject]
        public IMstStation _mstStation { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstPosition _mstPosition { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public IMstGrading _mstGrading { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployee { get; set; }

        IList<IBrowserFile> excelSheet = new List<IBrowserFile>();

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        int ModuleType = 0;
        string AlphanumericMask = @"^[a-zA-Z0-9_]*$";

        private string searchStringDepartment = "";
        private bool FilterFuncDepartment(MstDepartment element) => FilterFuncDepartment(element, searchStringDepartment);
        MstDepartment oModelDepartment = new MstDepartment();
        List<MstDepartment> oDepartmentAddList = new List<MstDepartment>();
        List<MstDepartment> oDepartmentUpdateList = new List<MstDepartment>();
        List<MstDepartment> oListDepartmentGridTemp = new List<MstDepartment>();
        private IEnumerable<MstDepartment> oListDepartmentGrid = new List<MstDepartment>();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        private string searchStringContractor = "";
        private bool FilterFuncContractor(MstContractor element) => FilterFuncContractor(element, searchStringContractor);
        MstContractor oModelContractor = new MstContractor();
        List<MstContractor> oContractorAddList = new List<MstContractor>();
        List<MstContractor> oContractorUpdateList = new List<MstContractor>();
        List<MstContractor> oListContractorGridTemp = new List<MstContractor>();
        private IEnumerable<MstContractor> oListContractorGrid = new List<MstContractor>();
        private IEnumerable<MstContractor> oListContractor = new List<MstContractor>();

        private string searchStringStation = "";
        private bool FilterFuncStation(MstStation element) => FilterFuncStation(element, searchStringStation);
        MstStation oModelStation = new MstStation();
        List<MstStation> oStationAddList = new List<MstStation>();
        List<MstStation> oStationUpdateList = new List<MstStation>();
        List<MstStation> oListStationGridTemp = new List<MstStation>();
        private IEnumerable<MstStation> oListStationGrid = new List<MstStation>();
        private IEnumerable<MstStation> oListStation = new List<MstStation>();

        private IEnumerable<MstUser> oListUser = new List<MstUser>();
        private IEnumerable<MstPayroll> oListPayroll = new List<MstPayroll>();

        private string searchStringDesignation = "";
        private bool FilterFuncDesignation(MstDesignation element) => FilterFuncDesignation(element, searchStringDesignation);
        MstDesignation oModelDesignation = new MstDesignation();
        List<MstDesignation> oDesignationAddList = new List<MstDesignation>();
        List<MstDesignation> oDesignationUpdateList = new List<MstDesignation>();
        List<MstDesignation> oListDesignationGridTemp = new List<MstDesignation>();
        private IEnumerable<MstDesignation> oListDesignationGrid = new List<MstDesignation>();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        private string searchStringLocation = "";
        private bool FilterFuncLocation(MstLocation element) => FilterFuncLocation(element, searchStringLocation);
        MstLocation oModelLocation = new MstLocation();
        List<MstLocation> oLocationAddList = new List<MstLocation>();
        List<MstLocation> oLocationUpdateList = new List<MstLocation>();
        List<MstLocation> oListLocationGridTemp = new List<MstLocation>();
        private IEnumerable<MstLocation> oListLocationGrid = new List<MstLocation>();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        private string searchStringPosition = "";
        private bool FilterFuncPosition(MstPosition element) => FilterFuncPosition(element, searchStringPosition);
        MstPosition oModelPosition = new MstPosition();
        List<MstPosition> oPositionAddList = new List<MstPosition>();
        List<MstPosition> oPositionUpdateList = new List<MstPosition>();
        List<MstPosition> oListPositionGridTemp = new List<MstPosition>();
        private IEnumerable<MstPosition> oListPositionGrid = new List<MstPosition>();
        private IEnumerable<MstPosition> oListPosition = new List<MstPosition>();

        private string searchStringBranch = "";
        private bool FilterFuncBranch(MstBranch element) => FilterFuncBranch(element, searchStringBranch);
        MstBranch oModelBranch = new MstBranch();
        List<MstBranch> oBranchAddList = new List<MstBranch>();
        List<MstBranch> oBranchUpdateList = new List<MstBranch>();
        List<MstBranch> oListBranchGridTemp = new List<MstBranch>();
        private IEnumerable<MstBranch> oListBranchGrid = new List<MstBranch>();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        private string searchStringGrading = "";
        private bool FilterFuncGrading(MstGrading element) => FilterFuncGrading(element, searchStringGrading);
        MstGrading oModelGrading = new MstGrading();
        List<MstGrading> oGradingAddList = new List<MstGrading>();
        List<MstGrading> oGradingUpdateList = new List<MstGrading>();
        List<MstGrading> oListGradingGridTemp = new List<MstGrading>();
        private IEnumerable<MstGrading> oListGradingGrid = new List<MstGrading>();
        private IEnumerable<MstGrading> oListGrading = new List<MstGrading>();

        private string searchStringMstEmployee = "";
        private bool FilterFuncMstEmployee(MstEmployee element) => FilterFuncMstEmployee(element, searchStringMstEmployee);
        MstEmployee oModelMstEmployee = new MstEmployee();
        List<MstEmployee> oMstEmployeeAddList = new List<MstEmployee>();
        List<MstEmployee> oMstEmployeeUpdateList = new List<MstEmployee>();
        List<MstEmployee> oListMstEmployeeGridTemp = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListMstEmployeeGrid = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListMstEmployee = new List<MstEmployee>();

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
                    if (ModuleType > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(TemplateFile))
                        {
                            Snackbar.Add("Please wait template uploading in process...", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            if (ModuleType == 1)//Department
                            {
                                await FillDepartmentTemplateGrid();
                            }
                            else if (ModuleType == 2)//Contractor
                            {
                                await FillContractorTemplateGrid();
                            }
                            else if (ModuleType == 3)//Station
                            {
                                await FillStationTemplateGrid();
                            }
                            else if (ModuleType == 4)//Designation
                            {
                                await FillDesignationTemplateGrid();
                            }
                            else if (ModuleType == 5)//Location
                            {
                                await FillLocationTemplateGrid();
                            }
                            else if (ModuleType == 6)//Position
                            {
                                await FillPositionTemplateGrid();
                            }
                            else if (ModuleType == 7)//Branch
                            {
                                await FillBranchTemplateGrid();
                            }
                            else if (ModuleType == 8)//Grading
                            {
                                await FillGradingTemplateGrid();
                            }
                            else if (ModuleType == 9)//Mst Employee
                            {                                
                                await FillMstEmployeeTemplateGrid();
                            }
                        }
                        else
                        {
                            Snackbar.Add("Select template to import", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            excelSheet.Clear();
                        }
                    }
                    else
                    {
                        Snackbar.Add("Select Module to import", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task GenerateTemplate()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                if (ModuleType > 0)
                {
                    if (ModuleType == 1)//Department
                    {
                        await DepartmentTemplate();
                    }
                    else if (ModuleType == 2)//Contractor
                    {
                        await ContractorTemplate();
                    }
                    else if (ModuleType == 3)//Station
                    {
                        await StationTemplate();
                    }
                    else if (ModuleType == 4)//Designation
                    {
                        await DesignationTemplate();
                    }
                    else if (ModuleType == 5)//Location
                    {
                        await LocationTemplate();
                    }
                    else if (ModuleType == 6)//Position
                    {
                        await PositionTemplate();
                    }
                    else if (ModuleType == 7)//Branch
                    {
                        await BranchTemplate();
                    }
                    else if (ModuleType == 8)//Grading
                    {
                        await GradingTemplate();
                    }
                    else if (ModuleType == 9)//Mst Employee
                    {
                        await MstEmployeeTemplate();
                    }
                }
                else
                {
                    Snackbar.Add("Select Module to generate template", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        private async Task GetAllUsers()
        {
            try
            {
                oListUser = await _mstUser.GetAllData();
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
                oListPayroll = await _mstPayroll.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        #region Mst Department
        private async Task GetAllDepartments()
        {
            try
            {
                oListDepartment = await _mstDepartment.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncDepartment(MstDepartment element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringDepartment))
                return true;
            if (element.Description.Contains(searchStringDepartment, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringDepartment))
                return true;
            return false;
        }
        private async Task FillDepartmentTemplateGrid()
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
                    var ws = workBook.Worksheet("DepartmentTemplate");

                    Type type = typeof(MstDepartment);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelDepartment = new MstDepartment();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelDepartment." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListDepartment.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelDepartment.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelDepartment.GetType().GetProperty(PropertyName).SetValue(oModelDepartment, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelDepartment.GetType().GetProperty(PropertyName).SetValue(oModelDepartment, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelDepartment.GetType().GetProperty(PropertyName).SetValue(oModelDepartment, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelDepartment.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oDepartmentAddList.Where(x => x.Code == oModelDepartment.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oDepartmentAddList.Add(oModelDepartment);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelDepartment.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oDepartmentUpdateList.Where(x => x.Code == oModelDepartment.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oDepartmentUpdateList.Add(oModelDepartment);
                            }
                        }

                    }
                    if (oDepartmentUpdateList.Count >= 0 && oDepartmentAddList.Count >= 0)
                    {
                        oListDepartmentGridTemp.AddRange(oDepartmentAddList);
                        oListDepartmentGridTemp.AddRange(oDepartmentUpdateList);
                    }
                    //else if(!IsForUpdate && oDepartmentAddList.Count > 0)
                    //{
                    //        oListDepartmentGridTemp.AddRange(oDepartmentAddList);
                    //}
                    oListDepartmentGrid = oListDepartmentGridTemp;
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
        private async Task DepartmentTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "DepartmentTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstDepartment);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Contractor
        private async Task GetAllContractors()
        {
            try
            {
                oListContractor = await _mstContractor.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncContractor(MstContractor element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringContractor))
                return true;
            if (element.Description.Contains(searchStringContractor, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringContractor))
                return true;
            return false;
        }
        private async Task FillContractorTemplateGrid()
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
                    var ws = workBook.Worksheet("ContractorTemplate");

                    Type type = typeof(MstContractor);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelContractor = new MstContractor();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelContractor." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListContractor.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelContractor.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelContractor.GetType().GetProperty(PropertyName).SetValue(oModelContractor, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelContractor.GetType().GetProperty(PropertyName).SetValue(oModelContractor, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelContractor.GetType().GetProperty(PropertyName).SetValue(oModelContractor, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelContractor.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oContractorAddList.Where(x => x.Code == oModelContractor.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oContractorAddList.Add(oModelContractor);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelContractor.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oContractorUpdateList.Where(x => x.Code == oModelContractor.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oContractorUpdateList.Add(oModelContractor);
                            }
                        }

                    }
                    if (oContractorUpdateList.Count >= 0 && oContractorAddList.Count >= 0)
                    {
                        oListContractorGridTemp.AddRange(oContractorAddList);
                        oListContractorGridTemp.AddRange(oContractorUpdateList);
                    }
                    //else if(!IsForUpdate && oContractorAddList.Count > 0)
                    //{
                    //        oListContractorGridTemp.AddRange(oContractorAddList);
                    //}
                    oListContractorGrid = oListContractorGridTemp;
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
        private async Task ContractorTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "ContractorTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstContractor);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Station
        private async Task GetAllStations()
        {
            try
            {
                oListStation = await _mstStation.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncStation(MstStation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringStation))
                return true;
            if (element.Description.Contains(searchStringStation, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringStation))
                return true;
            return false;
        }
        private async Task FillStationTemplateGrid()
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
                    var ws = workBook.Worksheet("StationTemplate");

                    Type type = typeof(MstStation);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelStation = new MstStation();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelStation." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListStation.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelStation.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelStation.GetType().GetProperty(PropertyName).SetValue(oModelStation, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelStation.GetType().GetProperty(PropertyName).SetValue(oModelStation, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelStation.GetType().GetProperty(PropertyName).SetValue(oModelStation, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelStation.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oStationAddList.Where(x => x.Code == oModelStation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oStationAddList.Add(oModelStation);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelStation.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oStationUpdateList.Where(x => x.Code == oModelStation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oStationUpdateList.Add(oModelStation);
                            }
                        }

                    }
                    if (oStationUpdateList.Count >= 0 && oStationAddList.Count >= 0)
                    {
                        oListStationGridTemp.AddRange(oStationAddList);
                        oListStationGridTemp.AddRange(oStationUpdateList);
                    }
                    //else if(!IsForUpdate && oStationAddList.Count > 0)
                    //{
                    //        oListStationGridTemp.AddRange(oStationAddList);
                    //}
                    oListStationGrid = oListStationGridTemp;
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
        private async Task StationTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "StationTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstStation);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Designation
        private async Task GetAllDesignation()
        {
            try
            {
                oListDesignation = await _mstDesignation.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncDesignation(MstDesignation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringDesignation))
                return true;
            if (element.Description.Contains(searchStringDesignation, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringDesignation))
                return true;
            return false;
        }
        private async Task FillDesignationTemplateGrid()
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
                    var ws = workBook.Worksheet("DesignationTemplate");

                    Type type = typeof(MstDesignation);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelDesignation = new MstDesignation();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelDesignation." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListDesignation.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelDesignation.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelDesignation.GetType().GetProperty(PropertyName).SetValue(oModelDesignation, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelDesignation.GetType().GetProperty(PropertyName).SetValue(oModelDesignation, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelDesignation.GetType().GetProperty(PropertyName).SetValue(oModelDesignation, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelDesignation.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oDesignationAddList.Where(x => x.Code == oModelDesignation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oDesignationAddList.Add(oModelDesignation);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelDesignation.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oDesignationUpdateList.Where(x => x.Code == oModelDesignation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oDesignationUpdateList.Add(oModelDesignation);
                            }
                        }
                    }
                    if (oDesignationUpdateList.Count >= 0 && oDesignationAddList.Count >= 0)
                    {
                        oListDesignationGridTemp.AddRange(oDesignationAddList);
                        oListDesignationGridTemp.AddRange(oDesignationUpdateList);
                    }
                    //else if(!IsForUpdate && oDesignationAddList.Count > 0)
                    //{
                    //        oListDesignationGridTemp.AddRange(oDesignationAddList);
                    //}
                    oListDesignationGrid = oListDesignationGridTemp;
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
        private async Task DesignationTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "DesignationTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstDesignation);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Location
        private async Task GetAllLocation()
        {
            try
            {
                oListLocation = await _mstLocation.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncLocation(MstLocation element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringLocation))
                return true;
            if (element.Description.Contains(searchStringLocation, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringLocation))
                return true;
            return false;
        }
        private async Task FillLocationTemplateGrid()
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
                    var ws = workBook.Worksheet("LocationTemplate");

                    Type type = typeof(MstLocation);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelLocation = new MstLocation();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelLocation." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListLocation.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelLocation.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelLocation.GetType().GetProperty(PropertyName).SetValue(oModelLocation, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelLocation.GetType().GetProperty(PropertyName).SetValue(oModelLocation, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelLocation.GetType().GetProperty(PropertyName).SetValue(oModelLocation, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelLocation.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oLocationAddList.Where(x => x.Code == oModelLocation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oLocationAddList.Add(oModelLocation);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelLocation.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oLocationUpdateList.Where(x => x.Code == oModelLocation.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oLocationUpdateList.Add(oModelLocation);
                            }
                        }
                    }
                    if (oLocationUpdateList.Count >= 0 && oLocationAddList.Count >= 0)
                    {
                        oListLocationGridTemp.AddRange(oLocationAddList);
                        oListLocationGridTemp.AddRange(oLocationUpdateList);
                    }
                    //else if(!IsForUpdate && oLocationAddList.Count > 0)
                    //{
                    //        oListLocationGridTemp.AddRange(oLocationAddList);
                    //}
                    oListLocationGrid = oListLocationGridTemp;
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
        private async Task LocationTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "LocationTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstLocation);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Position
        private async Task GetAllPosition()
        {
            try
            {
                oListPosition = await _mstPosition.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncPosition(MstPosition element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringPosition))
                return true;
            if (element.Description.Contains(searchStringPosition, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringPosition))
                return true;
            return false;
        }
        private async Task FillPositionTemplateGrid()
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
                    var ws = workBook.Worksheet("PositionTemplate");

                    Type type = typeof(MstPosition);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelPosition = new MstPosition();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelPosition." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListPosition.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelPosition.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelPosition.GetType().GetProperty(PropertyName).SetValue(oModelPosition, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelPosition.GetType().GetProperty(PropertyName).SetValue(oModelPosition, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelPosition.GetType().GetProperty(PropertyName).SetValue(oModelPosition, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelPosition.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oPositionAddList.Where(x => x.Code == oModelPosition.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oPositionAddList.Add(oModelPosition);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelPosition.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oPositionUpdateList.Where(x => x.Code == oModelPosition.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oPositionUpdateList.Add(oModelPosition);
                            }
                        }
                    }
                    if (oPositionUpdateList.Count >= 0 && oPositionAddList.Count >= 0)
                    {
                        oListPositionGridTemp.AddRange(oPositionAddList);
                        oListPositionGridTemp.AddRange(oPositionUpdateList);
                    }
                    //else if(!IsForUpdate && oPositionAddList.Count > 0)
                    //{
                    //        oListPositionGridTemp.AddRange(oPositionAddList);
                    //}
                    oListPositionGrid = oListPositionGridTemp;
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
        private async Task PositionTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "PositionTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstPosition);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Branch
        private async Task GetAllBranch()
        {
            try
            {
                oListBranch = await _mstBranch.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncBranch(MstBranch element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringBranch))
                return true;
            if (element.Description.Contains(searchStringBranch, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringBranch))
                return true;
            return false;
        }
        private async Task FillBranchTemplateGrid()
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
                    var ws = workBook.Worksheet("BranchTemplate");

                    Type type = typeof(MstBranch);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelBranch = new MstBranch();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelBranch." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListBranch.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelBranch.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelBranch.GetType().GetProperty(PropertyName).SetValue(oModelBranch, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelBranch.GetType().GetProperty(PropertyName).SetValue(oModelBranch, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelBranch.GetType().GetProperty(PropertyName).SetValue(oModelBranch, DatetimeValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelBranch.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oBranchAddList.Where(x => x.Code == oModelBranch.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oBranchAddList.Add(oModelBranch);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelBranch.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oBranchUpdateList.Where(x => x.Code == oModelBranch.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oBranchUpdateList.Add(oModelBranch);
                            }
                        }
                    }
                    if (oBranchUpdateList.Count >= 0 && oBranchAddList.Count >= 0)
                    {
                        oListBranchGridTemp.AddRange(oBranchAddList);
                        oListBranchGridTemp.AddRange(oBranchUpdateList);
                    }
                    //else if(!IsForUpdate && oBranchAddList.Count > 0)
                    //{
                    //        oListBranchGridTemp.AddRange(oBranchAddList);
                    //}
                    oListBranchGrid = oListBranchGridTemp;
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
        private async Task BranchTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "BranchTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstBranch);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Grading
        private async Task GetAllGrading()
        {
            try
            {
                oListGrading = await _mstGrading.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncGrading(MstGrading element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringGrading))
                return true;
            if (element.Description.Contains(searchStringGrading, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringGrading))
                return true;
            return false;
        }
        private async Task FillGradingTemplateGrid()
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
                    var ws = workBook.Worksheet("GradingTemplate");

                    Type type = typeof(MstGrading);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count(); i++)
                    {
                        IsForUpdate = false;
                        oModelGrading = new MstGrading();
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;

                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelGrading." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "Code")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "Code")
                                {
                                    var CheckList = oListGrading.Where(x => x.Code == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelGrading.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelGrading.GetType().GetProperty(PropertyName).SetValue(oModelGrading, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelGrading.GetType().GetProperty(PropertyName).SetValue(oModelGrading, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelGrading.GetType().GetProperty(PropertyName).SetValue(oModelGrading, DatetimeValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<decimal>))
                            {
                                var DecimalValue = Convert.ToDecimal(ws.Cell(i, j).Value.ToString());
                                oModelGrading.GetType().GetProperty(PropertyName).SetValue(oModelGrading, DecimalValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelGrading.Code) && !IsForUpdate)
                        {
                            var CheckDuplicate = oGradingAddList.Where(x => x.Code == oModelGrading.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oGradingAddList.Add(oModelGrading);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelGrading.Code) && IsForUpdate)
                        {
                            var CheckDuplicate = oGradingUpdateList.Where(x => x.Code == oModelGrading.Code).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oGradingUpdateList.Add(oModelGrading);
                            }
                        }
                    }
                    if (oGradingUpdateList.Count >= 0 && oGradingAddList.Count >= 0)
                    {
                        oListGradingGridTemp.AddRange(oGradingAddList);
                        oListGradingGridTemp.AddRange(oGradingUpdateList);
                    }
                    //else if(!IsForUpdate && oGradingAddList.Count > 0)
                    //{
                    //        oListGradingGridTemp.AddRange(oGradingAddList);
                    //}
                    oListGradingGrid = oListGradingGridTemp;
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
        private async Task GradingTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "GradingTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstGrading);

                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        #region Mst Employee

        private async Task GetAllMstEmployee()
        {
            try
            {
                oListMstEmployee = await _mstEmployee.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private bool FilterFuncMstEmployee(MstEmployee element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchStringMstEmployee))
                return true;
            if (element.EmpId.Contains(searchStringMstEmployee, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchStringMstEmployee))
                return true;
            return false;
        }
        private async Task FillMstEmployeeTemplateGrid()
        {
            try
            {
                Loading = true;
                _ = InvokeAsync(StateHasChanged);
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
                    var ws = workBook.Worksheet("MstEmployeeTemplate");

                    Type type = typeof(MstEmployeeVM);
                    int NumberOfRecords = type.GetProperties().Length;
                    for (int i = 2; i <= ws.Rows().Count() - 1; i++)
                    {
                        IsForUpdate = false;
                        oModelMstEmployee = new MstEmployee();
                        bool IsMasterFound = true;
                        for (int j = 1; j < ws.Rows().Cells().Count(); j++)
                        {
                            if (NumberOfRecords == j)//Read column only based on Model Properties
                            {
                                break;
                            }
                            string PropertyName = type.GetProperties()[j].Name;
                            PropertyInfo PropertyInfo = type.GetProperties()[j];

                            var CreatingDynamicModel = "oModelMstEmployee." + PropertyName;

                            if (PropertyInfo.PropertyType == typeof(string))
                            {
                                var StringValue = ws.Cell(i, j).Value.ToString();
                                if (StringValue == null)
                                {
                                    StringValue = "";
                                }
                                else if (string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmpId")
                                {
                                    //Skip the line if Code is Null or Empty
                                    break;
                                }
                                else if (!Regex.IsMatch(StringValue, AlphanumericMask) && PropertyName == "EmpId")
                                {
                                    //Skip the line if Code has special character
                                    break;
                                }
                                else if (StringValue.Contains("Null", StringComparison.OrdinalIgnoreCase))
                                {
                                    //Skip the line if Code has Null String
                                    break;
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "DesignationName")
                                {
                                    //Set ID of line from Mst Designation
                                    var CheckList = oListDesignation.Where(x => x.Description == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.DesignationId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "ManagerName")
                                {
                                    //Set ID of line from Mst User
                                    var CheckList = oListUser.Where(x => x.UserName == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.ManagerId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "PositionName")
                                {
                                    //Set ID of line from Mst Position
                                    var CheckList = oListPosition.Where(x => x.Description == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.PositionId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "DepartmentName")
                                {
                                    //Set ID of line from Mst Department
                                    var CheckList = oListDepartment.Where(x => x.Description == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.DepartmentId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "LocationName")
                                {
                                    //Set ID of line from Mst Location
                                    var CheckList = oListLocation.Where(x => x.Description == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.LocationId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "BranchName")
                                {
                                    //Set ID of line from Mst Branch
                                    var CheckList = oListBranch.Where(x => x.Description == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.BranchId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                else if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "PayrollName")
                                {
                                    //Set ID of line from Mst Payroll
                                    var CheckList = oListPayroll.Where(x => x.PayrollName == StringValue && x.FlgActive == true).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.PayrollId = CheckList.Id;
                                    }
                                    else
                                    {
                                        IsMasterFound = false;
                                        break;
                                    }
                                }
                                //Check for Add and Update
                                if (!string.IsNullOrWhiteSpace(StringValue) && PropertyName == "EmpId")
                                {
                                    var CheckList = oListMstEmployee.Where(x => x.EmpId == StringValue).FirstOrDefault();
                                    if (CheckList != null)
                                    {
                                        oModelMstEmployee.Id = CheckList.Id;
                                        IsForUpdate = true;
                                    }
                                }
                                oModelMstEmployee.GetType().GetProperty(PropertyName).SetValue(oModelMstEmployee, StringValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<bool>))
                            {
                                var BoolValue = Convert.ToBoolean(ws.Cell(i, j).Value.ToString());
                                oModelMstEmployee.GetType().GetProperty(PropertyName).SetValue(oModelMstEmployee, BoolValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var DatetimeValue = Convert.ToDateTime(ws.Cell(i, j).Value.ToString());
                                oModelMstEmployee.GetType().GetProperty(PropertyName).SetValue(oModelMstEmployee, DatetimeValue, null);
                                continue;
                            }
                            else if (PropertyInfo.PropertyType == typeof(Nullable<decimal>))
                            {
                                var DecimalValue = Convert.ToDecimal(ws.Cell(i, j).Value.ToString());
                                oModelMstEmployee.GetType().GetProperty(PropertyName).SetValue(oModelMstEmployee, DecimalValue, null);
                                continue;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(oModelMstEmployee.EmpId) && !IsForUpdate && IsMasterFound)
                        {
                            var CheckDuplicate = oMstEmployeeAddList.Where(x => x.EmpId == oModelMstEmployee.EmpId).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oMstEmployeeAddList.Add(oModelMstEmployee);
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(oModelMstEmployee.EmpId) && IsForUpdate && IsMasterFound)
                        {
                            var CheckDuplicate = oMstEmployeeUpdateList.Where(x => x.EmpId == oModelMstEmployee.EmpId).FirstOrDefault();
                            if (CheckDuplicate == null)
                            {
                                oMstEmployeeUpdateList.Add(oModelMstEmployee);
                            }
                        }

                    }
                    if (oMstEmployeeUpdateList.Count >= 0 && oMstEmployeeAddList.Count >= 0)
                    {
                        oListMstEmployeeGridTemp.AddRange(oMstEmployeeAddList);
                        oListMstEmployeeGridTemp.AddRange(oMstEmployeeUpdateList);
                    }
                    //else if(!IsForUpdate && oDepartmentAddList.Count > 0)
                    //{
                    //        oListDepartmentGridTemp.AddRange(oDepartmentAddList);
                    //}
                    oListMstEmployeeGrid = oListMstEmployeeGridTemp;
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
        private async Task MstEmployeeTemplate()
        {
            try
            {
                await Task.Delay(1);
                string FileName = "MstEmployeeTemplate";
                //string excelFilePath = "..\\wwwroot\\Templates\\" + FileName + ".xlsx";
                string excelFilePath = Path.GetFullPath("wwwroot\\Templates\\" + FileName + ".xlsx");
                using var workBook = new XLWorkbook();
                var ws = workBook.Worksheets.Add(FileName);
                Type type = typeof(MstEmployeeVM);
                //int SetColumnIndex = 0;
                int NumberOfRecords = type.GetProperties().Length;
                for (int i = 1; i <= NumberOfRecords - 1; i++)
                {
                    var PropertyName = type.GetProperties()[i].Name;
                    ws.Cell(1, i).Value = PropertyName;
                    ws.Cell(1, i).Style.Border.OutsideBorder = XLBorderStyleValues.Double;                    

                }
                //workBook.SaveAs(excelFilePath); 
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workBook.SaveAs(stream);
                    await JS.SaveAs(FileName + ".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }

        #endregion

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/MasterData", forceLoad: true);
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
                if (ModuleType > 0)
                {
                    if (ModuleType == 1) //Department
                    {
                        if (oDepartmentAddList.Count > 0)
                        {
                            res = await _mstDepartment.Insert(oDepartmentAddList);
                        }
                        if (oDepartmentUpdateList.Count > 0)
                        {
                            res = await _mstDepartment.Update(oDepartmentUpdateList);
                        }
                    }
                    else if (ModuleType == 2) //Contractor
                    {
                        if (oContractorAddList.Count > 0)
                        {
                            res = await _mstContractor.Insert(oContractorAddList);
                        }
                        if (oContractorUpdateList.Count > 0)
                        {
                            res = await _mstContractor.Update(oContractorUpdateList);
                        }
                    }
                    else if (ModuleType == 3) //Station
                    {
                        if (oStationAddList.Count > 0)
                        {
                            res = await _mstStation.Insert(oStationAddList);
                        }
                        if (oStationUpdateList.Count > 0)
                        {
                            res = await _mstStation.Update(oStationUpdateList);
                        }
                    }
                    else if (ModuleType == 4) //Designation
                    {
                        if (oDesignationAddList.Count > 0)
                        {
                            res = await _mstDesignation.Insert(oDesignationAddList);
                        }
                        if (oDesignationUpdateList.Count > 0)
                        {
                            res = await _mstDesignation.Update(oDesignationUpdateList);
                        }
                    }
                    else if (ModuleType == 5) //Location
                    {
                        if (oLocationAddList.Count > 0)
                        {
                            res = await _mstLocation.Insert(oLocationAddList);
                        }
                        if (oLocationUpdateList.Count > 0)
                        {
                            res = await _mstLocation.Update(oLocationUpdateList);
                        }
                    }
                    else if (ModuleType == 6) //Position
                    {
                        if (oPositionAddList.Count > 0)
                        {
                            res = await _mstPosition.Insert(oPositionAddList);
                        }
                        if (oPositionUpdateList.Count > 0)
                        {
                            res = await _mstPosition.Update(oPositionUpdateList);
                        }
                    }
                    else if (ModuleType == 7) //Branch
                    {
                        if (oBranchAddList.Count > 0)
                        {
                            res = await _mstBranch.Insert(oBranchAddList);
                        }
                        if (oBranchUpdateList.Count > 0)
                        {
                            res = await _mstBranch.Update(oBranchUpdateList);
                        }
                    }
                    else if (ModuleType == 8) //Grading
                    {
                        if (oGradingAddList.Count > 0)
                        {
                            res = await _mstGrading.Insert(oGradingAddList);
                        }
                        if (oGradingUpdateList.Count > 0)
                        {
                            res = await _mstGrading.Update(oGradingUpdateList);
                        }
                    }
                    else if (ModuleType == 9) //Mst Employee
                    {
                        if (oMstEmployeeAddList.Count > 0)
                        {
                            res = await _mstEmployee.Insert(oMstEmployeeAddList);
                        }
                        if (oMstEmployeeUpdateList.Count > 0)
                        {
                            res = await _mstEmployee.Update(oMstEmployeeUpdateList);
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/MasterData", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Select Module to generate template", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    await GetAllUsers();
                    await GetAllPayroll();
                    await GetAllDepartments();
                    await GetAllContractors();
                    await GetAllStations();
                    await GetAllDesignation();
                    await GetAllLocation();
                    await GetAllPosition();
                    await GetAllBranch();
                    await GetAllGrading();
                    await GetAllMstEmployee();
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
