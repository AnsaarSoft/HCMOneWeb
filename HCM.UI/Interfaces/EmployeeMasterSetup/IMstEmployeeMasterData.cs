using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface IMstEmployeeMasterData
    {
        Task<List<MstEmployee>> GetAllData();
        Task<List<MstEmployee>> GetAllData(string EmpID);
        Task<ApiResponseModel> Insert(MstEmployee pMstEmployee);
        Task<ApiResponseModel> Update(MstEmployee pMstEmployee);
        Task<ApiResponseModel> Insert(List<MstEmployee> pMstEmployee);
        Task<ApiResponseModel> Update(List<MstEmployee> pMstEmployee);
    }
}
