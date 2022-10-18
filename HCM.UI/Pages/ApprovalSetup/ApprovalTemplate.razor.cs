using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.ApprovalSetup
{
    public partial class ApprovalTemplate
    {
        #region Inject Service

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ICfgApprovalTemplate _cfgApprovalTemplateService { get; set; }

        [Inject]
        public NavigationManager navigation { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        public ICfgApprovalStage _mstStageService { get; set; }

        #endregion

        #region Variable

        private IEnumerable<MstEmployee> SelectedEmployee { get; set; } = new HashSet<MstEmployee>();
        private IEnumerable<MstForm> DocNames { get; set; } = new HashSet<MstForm>();

        CfgApprovalTemplate oModel = new CfgApprovalTemplate();

        MstForm oDoc = new MstForm();
        List<MstForm> oDocList = new List<MstForm>();

        CfgApprovalStage oModelCfgApprovalStage = new CfgApprovalStage();
        List<CfgApprovalStage> oListCfgApprovalStage = new List<CfgApprovalStage>();

        CfgApprovalTemplateStage oCfgApprovalTemplateStage = new CfgApprovalTemplateStage();
        List<CfgApprovalTemplateStage> oCfgApprovalTemplateStageList = new List<CfgApprovalTemplateStage>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        private bool Loading = false;
        private string LoginUser = "";

        #endregion

        #region Function 

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ApprovalTemplate");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (CfgApprovalTemplate)result.Data;
                    oModel = res;
                    List<MstEmployee> oListTemp = new List<MstEmployee>();
                    foreach (var item in oModel.CfgApprovalTemplateOriginators)
                    {
                        MstEmployee obj = new MstEmployee();
                        obj.Id = (int)item.Originator;
                        obj.EmpId = item.EmpId;
                        oListTemp.Add(obj);
                    }
                    SelectedEmployee = oListTemp.ToList();
                    DocNames = new HashSet<MstForm>();
                    List<MstForm> oListForm = new List<MstForm>();
                    foreach (var item in oModel.CfgApprovalTemplateDocuments)
                    {
                        if (item.FlgEmpLeave == true)
                        {
                            MstForm LineDoc = new MstForm();
                            LineDoc = oDocList.Where(x => x.FormCode == 2).FirstOrDefault();
                            oListForm.Add(LineDoc);
                        }
                        if (item.FlgLoan == true)
                        {
                            MstForm LineDoc = new MstForm();
                            LineDoc = oDocList.Where(x => x.FormCode == 3).FirstOrDefault();
                            oListForm.Add(LineDoc);
                        }
                        if (item.FlgAdvance == true)
                        {
                            MstForm LineDoc = new MstForm();
                            LineDoc = oDocList.Where(x => x.FormCode == 4).FirstOrDefault();
                            oListForm.Add(LineDoc);
                        }
                        if (item.FlgEmpTransfer == true)
                        {
                            MstForm LineDoc = new MstForm();
                            LineDoc = oDocList.Where(x => x.FormCode == 5).FirstOrDefault();
                            oListForm.Add(LineDoc);
                        }
                        if (item.FlgResignation == true)
                        {
                            MstForm LineDoc = new MstForm();
                            LineDoc = oDocList.Where(x => x.FormCode == 6).FirstOrDefault();
                            oListForm.Add(LineDoc);
                        }
                    }
                    DocNames = oListForm;
                    oCfgApprovalTemplateStageList = oModel.CfgApprovalTemplateStages.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "MultipleEmployeeSelect");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    SelectedEmployee = (HashSet<MstEmployee>)result.Data;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        async Task<List<MstForm>> GetApprovalDocs()
        {
            try
            {
                oDocList = await _cfgApprovalTemplateService.GetApprovalDocs();
                return oDocList;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }

        }

        async Task<List<CfgApprovalStage>> GetAllStages()
        {
            try
            {
                oListCfgApprovalStage = await _mstStageService.GetAllData();
                return oListCfgApprovalStage;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }

        }

        private async Task<IEnumerable<CfgApprovalStage>> SearchCfgApprovalStage(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListCfgApprovalStage.Select(o => new CfgApprovalStage
                    {
                        Id = o.Id,
                        StageName = o.StageName,
                    }).ToList();
                var res = oListCfgApprovalStage.Where(x => x.StageName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new CfgApprovalStage
                {
                    Id = x.Id,
                    StageName = x.StageName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private string GetDocumentSelection(List<string> selectedValues)
        {
            try
            {
                if (selectedValues.Count < 1)
                {
                    return $"Please choose Document";
                }
                return $"{selectedValues.Count} Document{(selectedValues.Count > 1 ? "s have" : " has")} been selected";
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<List<CfgApprovalTemplateStage>> AddRow()
        {
            try
            {
                CfgApprovalTemplateStage One = new()
                {
                    StageId = oModelCfgApprovalStage.Id,
                    StageName = oModelCfgApprovalStage.StageName
                };
                if (One.StageId != null && One.StageId != 0)
                {
                    if (oCfgApprovalTemplateStageList.Count == 0)
                    {
                        One.Priorty = 1;
                    }
                    else
                    {
                        foreach (var a in oCfgApprovalTemplateStageList)
                        {
                            One.Priorty = (byte?)(a.Priorty + 1);
                        }
                    }
                    var chkStage = oCfgApprovalTemplateStageList.Find(x => x.StageId == oModelCfgApprovalStage.Id);
                    if (chkStage == null)
                    {
                        oCfgApprovalTemplateStageList.Add(One);
                    }
                    else
                    {
                        Snackbar.Add("Stage already exists in the list.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModelCfgApprovalStage = new CfgApprovalStage();
                    return oCfgApprovalTemplateStageList;
                }
                else
                {
                    Snackbar.Add("Select Stage.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        public void RemoveRecord(int ID)
        {
            try
            {
                var res = oCfgApprovalTemplateStageList.Find(x => x.Id == ID);
                oCfgApprovalTemplateStageList.Remove(res);
                int count = 1;
                foreach (var a in oCfgApprovalTemplateStageList)
                {
                    a.Priorty = (byte?)count++;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res1 = new ApiResponseModel();
                if (oModel == null || string.IsNullOrWhiteSpace(oModel.Name) || SelectedEmployee == null || SelectedEmployee.Count() < 1 || DocNames == null || DocNames.Count() < 1 || oCfgApprovalTemplateStageList.Count == 0)
                {
                    Loading = false;
                    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    return null;
                }
                else
                {
                    Loading = true;
                    if (SelectedEmployee != null && SelectedEmployee.Count() > 0)
                    {
                        oModel.CfgApprovalTemplateOriginators.Clear();
                        foreach (var Line in SelectedEmployee)
                        {
                            CfgApprovalTemplateOriginator oLine = new CfgApprovalTemplateOriginator();
                            oLine.Originator = Line.Id;
                            oLine.EmpId = Line.EmpId;
                            oModel.CfgApprovalTemplateOriginators.Add(oLine);
                        }
                    }
                    if (DocNames != null && DocNames.Count() > 0)
                    {
                        oModel.CfgApprovalTemplateDocuments.Clear();
                        CfgApprovalTemplateDocument obj = new CfgApprovalTemplateDocument();
                        obj.FlgJobRequisition = false;
                        obj.FlgCandidate = false;
                        obj.FlgEmpHiring = false;
                        obj.FlgEmpLeave = false;
                        obj.FlgResignation = false;
                        obj.FlgLoan = false;
                        obj.FlgAppraisal = false;
                        obj.FlgAdvance = false;
                        obj.FlgEmpTransfer = false;
                        foreach (var Line in DocNames)
                        {
                            switch (Line.FormCode)
                            {
                                case 2:
                                obj.FlgEmpLeave = true;
                                    break;
                                case 3:
                                    obj.FlgLoan = true;
                                    break;
                                case 4:
                                    obj.FlgAdvance = true;
                                    break;
                                case 5:
                                    obj.FlgEmpTransfer= true;
                                    break;
                                case 6:
                                    obj.FlgResignation= true;
                                    break;
                            }
                        }
                        oModel.CfgApprovalTemplateDocuments.Add(obj);
                    }
                    oModel.CfgApprovalTemplateStages = oCfgApprovalTemplateStageList;
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        oModel.CreateDate = DateTime.Now;
                        oModel.Description = oModel.Name;
                        res1 = await _cfgApprovalTemplateService.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdateDate = DateTime.Now;
                        oModel.Description = oModel.Name;
                        res1 = await _cfgApprovalTemplateService.Update(oModel);
                    }
                    //if (res != null && res.Message.Contains("Can't update Approval setup, documents decisions pending.") || res.Message.Contains("Failed to Saved Successfully."))
                    //{
                    //    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.DoneAll; });
                    //}
                    //else if (res != null && res.Message.Contains("Saved Successfully.") || res.Message.Contains("Update Successfully."))
                    //{
                    if (res1 != null && res1.Id == 1)
                    {
                        Snackbar.Add(res1.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(1000);
                        Navigation.NavigateTo("/ApprovalTemplate", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res1.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        Loading = false;
                        return null;
                    }
                    //}
                    //else
                    //{
                    //    Snackbar.Add("An error occurred.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //}
                    Loading = false;
                    return res1;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/ApprovalTemplate", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion

        #region Initialized

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    oModel.FlgActive = true;
                    await GetApprovalDocs();
                    await GetAllStages();
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
            }
        }

        #endregion
    }
}
