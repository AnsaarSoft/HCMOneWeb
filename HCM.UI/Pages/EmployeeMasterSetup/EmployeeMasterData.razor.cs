using Blazored.LocalStorage;
using HCM.UI.Interfaces.MasterElement;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using Microsoft.JSInterop;
using MudBlazor;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeMasterData
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstDocumentNumberSeries _mstDocumentNumberSeries { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public IMstUser _mstUser { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstPosition _mstPosition { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ICfgPayrollDefinationinit _CfgPayrollDefinationinit { get; set; }

        [Inject]
        public IMstElement _mstElement { get; set; }

        [Inject]
        public IMstGratuity _mstGratuity { get; set; }

        [Inject]
        public IMstBonus _mstBonus { get; set; }

        [Inject]
        public IMstCountryStateCity _mstCountryStateCity { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstDimension _mstDimension { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        private string LoginUser = "";

        [Inject]
        public IMemoryCache _memoryCache { get; set; }
        private const string CacheKey = "EmployeeMaster";
        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledCode = false;
        bool DisableSeries = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private string searchString1 = "";
        private bool FilterFunc(MstEmployeeLeaf element) => FilterFunc(element, searchString1);

        CfgPayrollBasicInitialization oModelPayrollInit = new CfgPayrollBasicInitialization();

        MstDocumentNumberSeries oModelDocumentNumberSeries = new MstDocumentNumberSeries();
        private IEnumerable<MstDocumentNumberSeries> oListDocumentNumberSeries = new List<MstDocumentNumberSeries>();

        MstLove oModelLove = new MstLove();
        private IEnumerable<MstLove> oListLove = new List<MstLove>();

        MstEmployee oModelUser = new MstEmployee();
        private IEnumerable<MstEmployee> oListUser = new List<MstEmployee>();

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstPosition oModelPosition = new MstPosition();
        private IEnumerable<MstPosition> oListPosition = new List<MstPosition>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<MstElementLink> oMstElementLinkList = new List<MstElementLink>();

        private IEnumerable<MstElement> oListElement = new List<MstElement>();

        MstGratuity oModelGratuity = new MstGratuity();
        private IEnumerable<MstGratuity> oListGratuity = new List<MstGratuity>();

        MstBonu oModelBonus = new MstBonu();
        private IEnumerable<MstBonu> oListBonus = new List<MstBonu>();

        MstCountry oModelCountryWork = new MstCountry();
        MstCountry oModelCountryHome = new MstCountry();
        MstCountry oModelCountryPrimary = new MstCountry();
        MstCountry oModelCountrySecondary = new MstCountry();
        private IEnumerable<MstCountry> oListCountry = new List<MstCountry>();

        MstState oModelStateWork = new MstState();
        MstState oModelStateHome = new MstState();
        MstState oModelStatePrimary = new MstState();
        MstState oModelStateSecondary = new MstState();
        private IEnumerable<MstState> oListState = new List<MstState>();

        MstCity oModelCityWork = new MstCity();
        MstCity oModelCityHome = new MstCity();
        MstCity oModelCityPrimary = new MstCity();
        MstCity oModelCitySecondary = new MstCity();
        private IEnumerable<MstCity> oListCity = new List<MstCity>();

        private IEnumerable<MstDimension> oListDimension = new List<MstDimension>();

        private IEnumerable<MstEmployeeLeaf> oListLeaveAllocation = new List<MstEmployeeLeaf>();

        MstEmployee oModel = new MstEmployee();
        List<MstEmployeeAttachment> oListEmployeeAttachment = new List<MstEmployeeAttachment>();
        private IEnumerable<MstEmployee> oList = new List<MstEmployee>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        private bool Clearing = false;
        private static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full";
        private string DragClass = DefaultDragClass;
        IList<IBrowserFile> AttachmentFiles = new List<IBrowserFile>();

        private bool ClearingEmpPicture = false;
        private static string DefaultDragClassEmpPicture = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full";
        private string DragClassEmpPicture = DefaultDragClassEmpPicture;
        private string EmpImagePath = "";
        IList<IBrowserFile> EmpImage = new List<IBrowserFile>();

        #endregion

        #region Functions

        void VisiblePassword()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    DisbaledCode = true;
                    DisableSeries = true;
                    var res = (MstEmployee)result.Data;
                    oModel = res;
                    oModelDocumentNumberSeries.Prefix = oModel.Prefix;
                    if (oModel.MstEmployeeAttachments.Count > 0)
                    {
                        oListEmployeeAttachment = oModel.MstEmployeeAttachments.ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.ManagerName))
                    {
                        oModelUser.Id = (int)oModel.Manager;
                        oModelUser.FirstName = oModel.ManagerName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.DesignationName))
                    {
                        oModelDesignation.Id = (int)oModel.DesignationId;
                        oModelDesignation.Description = oModel.DesignationName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.PositionName))
                    {
                        oModelPosition.Id = (int)oModel.PositionId;
                        oModelPosition.Description = oModel.PositionName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.DepartmentName))
                    {
                        oModelDepartment.Id = (int)oModel.DepartmentId;
                        oModelDepartment.DeptName = oModel.DepartmentName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.LocationName))
                    {
                        oModelLocation.Id = (int)oModel.Location;
                        oModelLocation.Description = oModel.LocationName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.BranchName))
                    {
                        oModelBranch.Id = (int)oModel.BranchId;
                        oModelBranch.Description = oModel.BranchName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.PayrollName))
                    {
                        oModelPayroll.Id = (int)oModel.PayrollId;
                        oModelPayroll.PayrollName = oModel.PayrollName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.BonusCode))
                    {
                        oModelBonus.Code = oModel.BonusCode;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.GratuityName))
                    {
                        oModelGratuity.GrtCode = oModel.GratuityName;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.ImgPath))
                    {
                        EmpImagePath = oModel.ImgPath;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Wacountry))
                    {
                        oModelCountryWork.CountryName = oModel.Wacountry;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Hacountry))
                    {
                        oModelCountryHome.CountryName = oModel.Hacountry;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.PriCountry))
                    {
                        oModelCountryPrimary.CountryName = oModel.PriCountry;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.SecCountry))
                    {
                        oModelCountrySecondary.CountryName = oModel.SecCountry;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Wastate))
                    {
                        oModelStateWork.StateName = oModel.Wastate;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Hastate))
                    {
                        oModelStateHome.StateName = oModel.Hastate;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.PriState))
                    {
                        oModelStatePrimary.StateName = oModel.PriState;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.SecState))
                    {
                        oModelStateSecondary.StateName = oModel.SecState;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Wacity))
                    {
                        oModelCityWork.CityName = oModel.Wacity;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.Hacity))
                    {
                        oModelCityHome.CityName = oModel.Hacity;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.PriCity))
                    {
                        oModelCityPrimary.CityName = oModel.PriCity;
                    }
                    if (!string.IsNullOrWhiteSpace(oModel.SecCity))
                    {
                        oModelCitySecondary.CityName = oModel.SecCity;
                    }

                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<IEnumerable<MstDocumentNumberSeries>> SearchDocumentNumberSeries(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDocumentNumberSeries.Select(o => new MstDocumentNumberSeries
                    {
                        FkformCode = o.FkformCode,
                        Prefix = o.Prefix,
                        StartNo = o.StartNo
                    }).ToList();
                var res = oListDocumentNumberSeries.Where(x => x.Prefix.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDocumentNumberSeries
                {
                    FkformCode = x.FkformCode,
                    Prefix = x.Prefix,
                    StartNo = x.StartNo
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstEmployee>> SearchUser(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListUser.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                        FirstName = o.FirstName,
                    }).ToList();
                var res = oListUser.Where(x => x.FirstName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                    FirstName = x.FirstName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstDesignation>> SearchDesignation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDesignation.Select(o => new MstDesignation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListDesignation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDesignation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstPosition>> SearchPosition(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPosition.Select(o => new MstPosition
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListPosition.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstPosition
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstDepartment>> SearchDepartment(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDepartment.Select(o => new MstDepartment
                    {
                        Id = o.Id,
                        DeptName = o.DeptName,
                    }).ToList();
                var res = oListDepartment.Where(x => x.DeptName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDepartment
                {
                    Id = x.Id,
                    DeptName = x.DeptName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstLocation>> SearchLocation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListLocation.Select(o => new MstLocation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListLocation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstLocation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstBranch>> SearchBranch(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListBranch.Select(o => new MstBranch
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListBranch.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstBranch
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
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
                        MstElementLinks = o.MstElementLinks,
                    }).ToList();
                var res = oListPayroll.Where(x => x.PayrollName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new CfgPayrollDefination
                {
                    Id = x.Id,
                    PayrollName = x.PayrollName,
                    MstElementLinks = x.MstElementLinks,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstGratuity>> SearchGratuity(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListGratuity.Select(o => new MstGratuity
                    {
                        Id = o.Id,
                        Code = o.Code,
                    }).ToList();
                var res = oListGratuity.Where(x => x.GrtCode.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstGratuity
                {
                    Id = x.Id,
                    Code = x.Code,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstBonu>> SearchBonus(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListBonus.Select(o => new MstBonu
                    {
                        Id = o.Id,
                        Code = o.Code,
                    }).ToList();
                var res = oListBonus.Where(x => x.Code.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstBonu
                {
                    Id = x.Id,
                    Code = x.Code,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstCountry>> SearchCountry(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListCountry.Select(o => new MstCountry
                    {
                        Id = o.Id,
                        CountryName = o.CountryName,
                    }).ToList();
                var res = oListCountry.Where(x => x.CountryName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstCountry
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstState>> SearchState(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListState.Select(o => new MstState
                    {
                        Id = o.Id,
                        Cid = o.Cid,
                        StateName = o.StateName,
                    }).ToList();
                var res = oListState.Where(x => x.StateName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstState
                {
                    Id = x.Id,
                    Cid = x.Cid,
                    StateName = x.StateName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstCity>> SearchCity(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListCity.Select(o => new MstCity
                    {
                        Id = o.Id,
                        CityName = o.CityName,
                    }).ToList();
                var res = oListCity.Where(x => x.CityName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstCity
                {
                    Id = x.Id,
                    CityName = x.CityName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task GetPayrollinit()
        {
            try
            {
                oModelPayrollInit = await _CfgPayrollDefinationinit.GetData();
                if (oModelPayrollInit.FlgEmployeeCodeSeries == true)
                {
                    DisbaledCode = true;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDocumentNumberSeriess()
        {
            try
            {
                oListDocumentNumberSeries = await _mstDocumentNumberSeries.GetAllData();
                oListDocumentNumberSeries = oListDocumentNumberSeries.Where(x => x.FkformCode == 1 && x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLove()
        {
            try
            {
                oListLove = await _mstLove.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmployees()
        {
            try
            {
                oList = await _mstEmployeeMaster.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmpUser()
        {
            try
            {
                await Task.Delay(1);
                oListUser = oList;
                oListUser = oListUser.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDesignation()
        {
            try
            {
                oListDesignation = await _mstDesignation.GetAllData();
                oListDesignation = oListDesignation.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllPosition()
        {
            try
            {
                oListPosition = await _mstPosition.GetAllData();
                oListPosition = oListPosition.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDimension()
        {
            try
            {
                oListDimension = await _mstDimension.GetAllData();
                oListDimension = oListDimension.Where(x => x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDepartments()
        {
            try
            {
                oListDepartment = await _mstDepartment.GetAllData();
                oListDepartment = oListDepartment.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLocation()
        {
            try
            {
                oListLocation = await _mstLocation.GetAllData();
                oListLocation = oListLocation.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllBranches()
        {
            try
            {
                oListBranch = await _mstBranch.GetAllData();
                oListBranch = oListBranch.Where(x => x.FlgActive == true).ToList();
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
                //oListGratuity = oListGratuity.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllBonus()
        {
            try
            {
                oListBonus = await _mstBonus.GetAllData();
                oListBonus = oListBonus.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllCountry()
        {
            try
            {
                oListCountry = await _mstCountryStateCity.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task FillEmployeeCode(MstDocumentNumberSeries oModelDocSeries)
        {
            try
            {
                if (oModelDocSeries != null && oModelDocSeries.FkformCode > 0)
                {
                    int MaxNumber = 0;
                    if (oList.Where(x => x.Prefix == oModelDocSeries.Prefix).Select(x => x.SeriesNumber).Max() == null)
                    {
                        MaxNumber = 0;
                    }
                    else
                    {
                        MaxNumber = (int)oList.Where(x => x.Prefix == oModelDocSeries.Prefix).Select(x => x.SeriesNumber).Max();
                    }
                    if (MaxNumber > 0)
                    {
                        int SeriesNumber = MaxNumber + 1;
                        oModel.Prefix = oModelDocSeries.Prefix;
                        oModel.SeriesNumber = SeriesNumber;
                        oModel.EmpId = oModelDocSeries.Prefix + SeriesNumber.ToString();
                    }
                    else
                    {
                        int SeriesNumber = (int)(oModelDocSeries.StartNo + 1);
                        oModel.Prefix = oModelDocSeries.Prefix;
                        oModel.SeriesNumber = SeriesNumber;
                        oModel.EmpId = oModelDocSeries.Prefix + SeriesNumber.ToString();
                    }
                    oModelDocumentNumberSeries = oModelDocSeries;
                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async Task FillCountryWork(MstCountry oModelCountry)
        {
            try
            {
                if (oModelCountry != null && oModelCountry.Id > 0)
                {
                    var SelectedCountry = oListCountry.Where(x => x.Id == oModelCountry.Id).FirstOrDefault();
                    oListState = SelectedCountry.MstStates.ToList();
                    await Task.Delay(1);
                    oModelCountryWork = oModelCountry;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillStateWork(MstState oModelState)
        {
            try
            {
                if (oModelState != null && oModelState.Id > 0)
                {
                    var SelectedState = oListCountry.Where(x => x.Id == oModelState.Cid).FirstOrDefault();
                    oListCity = SelectedState.MstCities.ToList();
                    await Task.Delay(1);
                    oModelStateWork = oModelState;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillCityWork(MstCity oModelCity)
        {
            try
            {
                if (oModelCity != null && oModelCity.Id > 0)
                {
                    await Task.Delay(1);
                    oModelCityWork = oModelCity;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task FillCountryHome(MstCountry oModelCountry)
        {
            try
            {
                if (oModelCountry != null && oModelCountry.Id > 0)
                {
                    var SelectedCountry = oListCountry.Where(x => x.Id == oModelCountry.Id).FirstOrDefault();
                    oListState = SelectedCountry.MstStates.ToList();
                    await Task.Delay(1);
                    oModelCountryHome = oModelCountry;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillStateHome(MstState oModelState)
        {
            try
            {
                if (oModelState != null && oModelState.Id > 0)
                {
                    var SelectedState = oListCountry.Where(x => x.Id == oModelState.Cid).FirstOrDefault();
                    oListCity = SelectedState.MstCities.ToList();
                    await Task.Delay(1);
                    oModelStateHome = oModelState;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillCityHome(MstCity oModelCity)
        {
            try
            {
                if (oModelCity != null && oModelCity.Id > 0)
                {
                    await Task.Delay(1);
                    oModelCityHome = oModelCity;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task FillCountryPri(MstCountry oModelCountry)
        {
            try
            {
                if (oModelCountry != null && oModelCountry.Id > 0)
                {
                    var SelectedCountry = oListCountry.Where(x => x.Id == oModelCountry.Id).FirstOrDefault();
                    oListState = SelectedCountry.MstStates.ToList();
                    await Task.Delay(1);
                    oModelCountryPrimary = oModelCountry;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillStatePri(MstState oModelState)
        {
            try
            {
                if (oModelState != null && oModelState.Id > 0)
                {
                    var SelectedState = oListCountry.Where(x => x.Id == oModelState.Cid).FirstOrDefault();
                    oListCity = SelectedState.MstCities.ToList();
                    await Task.Delay(1);
                    oModelStatePrimary = oModelState;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillCityPri(MstCity oModelCity)
        {
            try
            {
                if (oModelCity != null && oModelCity.Id > 0)
                {
                    await Task.Delay(1);
                    oModelCityPrimary = oModelCity;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }


        private async Task FillCountrySec(MstCountry oModelCountry)
        {
            try
            {
                if (oModelCountry != null && oModelCountry.Id > 0)
                {
                    var SelectedCountry = oListCountry.Where(x => x.Id == oModelCountry.Id).FirstOrDefault();
                    oListState = SelectedCountry.MstStates.ToList();
                    await Task.Delay(1);
                    oModelCountrySecondary = oModelCountry;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillStateSec(MstState oModelState)
        {
            try
            {
                if (oModelState != null && oModelState.Id > 0)
                {
                    var SelectedState = oListCountry.Where(x => x.Id == oModelState.Cid).FirstOrDefault();
                    oListCity = SelectedState.MstCities.ToList();
                    await Task.Delay(1);
                    oModelStateSecondary = oModelState;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task FillCitySec(MstCity oModelCity)
        {
            try
            {
                if (oModelCity != null && oModelCity.Id > 0)
                {
                    await Task.Delay(1);
                    oModelCitySecondary = oModelCity;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task Clear()
        {
            try
            {
                Clearing = true;
                foreach (var Attachment in oListEmployeeAttachment)
                {
                    File.Delete(Attachment.FilePath);
                }
                AttachmentFiles.Clear();
                oListEmployeeAttachment.Clear();
                ClearDragClassAttachment();
                await Task.Delay(100);
                Clearing = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async void OnInputFileChangedEmpPicture(InputFileChangeEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(EmpImagePath))
                {
                    EmpImagePath = Path.GetFullPath("wwwroot\\" + EmpImagePath);
                    File.Delete(EmpImagePath);
                }
                ClearDragClassEmpPicture();
                if (!string.IsNullOrWhiteSpace(oModel.EmpId))
                {
                    if (e.FileCount > 0)
                    {
                        var EmpImageFileName = e.File.Name;
                        EmpImage.Add(e.File);
                        var EmpImageFullPath = Path.GetFullPath("wwwroot\\EmployeeAttachments\\" + oModel.EmpId + "-" + e.File.Name);
                        Stream stream = EmpImage.FirstOrDefault().OpenReadStream();
                        FileStream fs = File.Create(EmpImageFullPath);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                    }
                }
                else
                {
                    Snackbar.Add("Type Employee Code first", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            EmpImagePath = "EmployeeAttachments\\" + oModel.EmpId + "-" + e.File.Name;
            _ = InvokeAsync(StateHasChanged);
        }

        private void SetDragClassEmpPicture()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        private void ClearDragClassEmpPicture()
        {
            DragClass = DefaultDragClass;
        }

        private async void OnInputFileChangedAttachment(InputFileChangeEventArgs e)
        {
            try
            {
                if (oListEmployeeAttachment.Count > 0)
                {
                    foreach (var Attachment in oListEmployeeAttachment)
                    {
                        File.Delete(Attachment.FilePath);
                    }
                    AttachmentFiles.Clear();
                    oListEmployeeAttachment.Clear();
                }
                ClearDragClassAttachment();
                var files = e.GetMultipleFiles();
                if (e.FileCount > 0)
                {

                    foreach (var file in files)
                    {
                        MstEmployeeAttachment oModelEmployeeAttachment = new MstEmployeeAttachment();
                        var EmpAttachFileName = oModel.EmpId + "-" + file.Name;
                        var EmpAttachmentFullPath = Path.GetFullPath("wwwroot\\EmployeeAttachments\\" + EmpAttachFileName);
                        AttachmentFiles.Add(file);
                        Stream stream = file.OpenReadStream(5120000);
                        FileStream fs = File.Create(EmpAttachmentFullPath);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                        oModelEmployeeAttachment.FileName = EmpAttachFileName;
                        oModelEmployeeAttachment.FilePath = EmpAttachmentFullPath;
                        oModelEmployeeAttachment.CreatedBy = LoginUser;
                        oListEmployeeAttachment.Add(oModelEmployeeAttachment);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async void Download()
        {
            try
            {
                if (oListEmployeeAttachment.Count > 0)
                {
                    foreach (var item in oListEmployeeAttachment)
                    {
                        var Paths = Path.GetFullPath("wwwroot\\EmployeeAttachments\\" + item.FileName);
                        var stream = new MemoryStream(File.ReadAllBytes(Paths));
                        await JS.SaveAs(item.FileName, stream.ToArray());
                        stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private void SetDragClassAttachment()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        private void ClearDragClassAttachment()
        {
            DragClass = DefaultDragClass;
        }

        private bool FilterFunc(MstEmployeeLeaf element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.LeavesCarryForward.Equals(searchString1))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
                {
                    _memoryCache.Remove(CacheKey);
                }
                Navigation.NavigateTo("/EmployeeMasterData", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllPayrollElement()
        {
            try
            {
                if (oModelPayroll.Id > 0)
                {
                    oListElement = await _mstElement.GetAllData();
                    oMstElementLinkList = oModelPayroll.MstElementLinks.Where(x => x.PayrollId == oModelPayroll.Id).ToList();

                    List<MstElement> oTempList = new List<MstElement>();
                    foreach (var item in oMstElementLinkList)
                    {
                        var Element = oListElement.Where(x => x.FlgStandardElement == true && x.Id == item.ElementId && x.Type == "Rec").FirstOrDefault();
                        if (Element != null)
                        {
                            oTempList.Add(Element);
                        }
                    }
                    oListElement = oTempList.ToList();
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
                var res = new ApiResponseModel();
                if ((oModelPayrollInit.FlgEmployeeCodeSeries == true && !string.IsNullOrWhiteSpace(oModelDocumentNumberSeries.Prefix)) || !string.IsNullOrWhiteSpace(oModel.EmpId) && !string.IsNullOrWhiteSpace(oModel.FirstName) && !string.IsNullOrWhiteSpace(oModel.LastName) && !string.IsNullOrWhiteSpace(oModelDesignation.Description)
                    && !string.IsNullOrWhiteSpace(oModelPosition.Description) && !string.IsNullOrWhiteSpace(oModelDepartment.DeptName) && !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    && !string.IsNullOrWhiteSpace(oModelBranch.Description) && !string.IsNullOrWhiteSpace(oModelUser.FirstName) && !string.IsNullOrWhiteSpace(oModelPayroll.PayrollName) && !string.IsNullOrWhiteSpace(oModel.FatherName)
                    && !string.IsNullOrWhiteSpace(oModel.MotherName) && !string.IsNullOrWhiteSpace(oModel.GenderId) && !string.IsNullOrWhiteSpace(oModel.MartialStatusId) && !string.IsNullOrWhiteSpace(oModel.ReligionId)
                    && !string.IsNullOrWhiteSpace(oModel.PersonalEmail) && !string.IsNullOrWhiteSpace(oModel.PersonalContactNo) && !string.IsNullOrWhiteSpace(oModel.Nationality) && oModel.BasicSalary > 0
                    && oModel.GrossSalary > 0 && !string.IsNullOrWhiteSpace(oModel.SalaryCurrency) && !string.IsNullOrWhiteSpace(oModel.PaymentMode) && !string.IsNullOrWhiteSpace(oModel.AccountTitle)
                    && !string.IsNullOrWhiteSpace(oModel.AccountNo) && !string.IsNullOrWhiteSpace(oModel.AccountType) && !string.IsNullOrWhiteSpace(oModel.BankName) && !string.IsNullOrWhiteSpace(oModel.BranchName)
                    && !string.IsNullOrWhiteSpace(oModel.HolidayCalendar) && !string.IsNullOrWhiteSpace(oModel.EmployeeContractType) && !string.IsNullOrWhiteSpace(EmpImagePath) && !string.IsNullOrWhiteSpace(oModel.OfficeEmail)
                    && !string.IsNullOrWhiteSpace(oModel.Password))
                {
                    if (oModel.EmpId.Length > 20)
                    {
                        Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.Manager = oModelUser.Id;
                        oModel.ManagerName = oModelUser.FirstName;
                        oModel.DesignationId = oModelDesignation.Id;
                        oModel.DesignationName = oModelDesignation.Description;
                        oModel.PositionId = oModelPosition.Id;
                        oModel.PositionName = oModelPosition.Description;
                        oModel.DepartmentId = oModelDepartment.Id;
                        oModel.DepartmentName = oModelDepartment.DeptName;
                        oModel.Location = oModelLocation.Id;
                        oModel.LocationName = oModelLocation.Description;
                        oModel.BranchId = oModelBranch.Id;
                        oModel.BranchName = oModelBranch.Description;
                        oModel.PayrollId = oModelPayroll.Id;
                        oModel.PayrollName = oModelPayroll.PayrollName;
                        oModel.ImgPath = EmpImagePath;
                        if (!string.IsNullOrWhiteSpace(oModelGratuity.GrtCode))
                        {
                            oModel.GratuityName = oModelGratuity.GrtCode;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelBonus.Code))
                        {
                            oModel.BonusCode = oModelBonus.Code;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCountryWork.CountryName))
                        {
                            oModel.Wacountry = oModelCountryWork.CountryName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCountryHome.CountryName))
                        {
                            oModel.Hacountry = oModelCountryHome.CountryName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCountryPrimary.CountryName))
                        {
                            oModel.PriCountry = oModelCountryPrimary.CountryName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCountrySecondary.CountryName))
                        {
                            oModel.SecCountry = oModelCountrySecondary.CountryName;
                        }

                        if (!string.IsNullOrWhiteSpace(oModelStateWork.StateName))
                        {
                            oModel.Wastate = oModelStateWork.StateName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelStateHome.StateName))
                        {
                            oModel.Hastate = oModelStateHome.StateName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelStatePrimary.StateName))
                        {
                            oModel.PriState = oModelStatePrimary.StateName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelStateSecondary.StateName))
                        {
                            oModel.SecState = oModelStateSecondary.StateName;
                        }

                        if (!string.IsNullOrWhiteSpace(oModelCityWork.CityName))
                        {
                            oModel.Wacity = oModelCityWork.CityName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCityHome.CityName))
                        {
                            oModel.Hacity = oModelCityHome.CityName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCityPrimary.CityName))
                        {
                            oModel.PriCity = oModelCityPrimary.CityName;
                        }
                        if (!string.IsNullOrWhiteSpace(oModelCitySecondary.CityName))
                        {
                            oModel.SecCity = oModelCitySecondary.CityName;
                        }
                        oModel.MstEmployeeAttachments = oListEmployeeAttachment;
                        if (!string.IsNullOrWhiteSpace(oModelPayroll.PayrollName))
                        {
                            #region Apply payroll Standard Elements

                            await GetAllPayrollElement();
                            if (oListElement.Count() > 0)
                            {
                                oModel = BusinessLogic.ApplyPayrolStdlElement(oModel, oListElement, LoginUser);
                            }

                            #endregion

                            if (oModel.Id == 0)
                            {
                                oModel.CreatedBy = LoginUser;
                                res = await _mstEmployeeMaster.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUser;
                                res = await _mstEmployeeMaster.Update(oModel);
                            }
                        }

                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(3000);
                            Navigation.NavigateTo("/EmployeeMasterData", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
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
                    await GetPayrollinit();
                    await GetAllDocumentNumberSeriess();
                    await GetAllEmployees();
                    await GetAllLove();
                    await GetAllEmpUser();
                    await GetAllDesignation();
                    await GetAllDimension();
                    await GetAllPosition();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    await GetAllPayroll();
                    await GetAllGratuity();
                    await GetAllBonus();
                    await GetAllCountry();
                    //await GetAllState();
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
