using ClosedXML.Excel;
using HCM.API.Models;
using HCM.UI.General;
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
        public IMstDepartment _mstDepartment { get; set; }

        IList<IBrowserFile> excelSheet = new List<IBrowserFile>();

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
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        #endregion

        #region Functions

        private void UploadFile(InputFileChangeEventArgs e)
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
                            if (ModuleType == 1)//Department
                            {
                                FillDepartmentTemplateGrid();
                            }
                            else if (ModuleType == 2)//Designation
                            {

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
        private async void FillDepartmentTemplateGrid()
        {
            try
            {
                Loading = true;
                _ = InvokeAsync(StateHasChanged);
                await Task.Delay(1);
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
                        if (!string.IsNullOrWhiteSpace(oModelDepartment.Code))
                        {
                            oDepartmentAddList.Add(oModelDepartment);
                        }

                    }
                    oListDepartment = oDepartmentAddList;
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
                    else if (ModuleType == 2)//Designation
                    {

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
                    await JS.SaveAs(FileName+".xlsx", stream.ToArray());
                }
                Snackbar.Add("Template saved: " + excelFilePath, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/MasterDataImport", forceLoad: true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            Loading = false;
        }
        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oListDepartment.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    //oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    //DisbaledCode = true;
                    //oModel.Description = res.Description;
                    //oModel.FlgActive = res.FlgActive;
                    oModelDepartment = res;
                    oListDepartment = oListDepartment.Where(x => x.Id != LineNum);
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
