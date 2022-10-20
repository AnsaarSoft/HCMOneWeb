using HCM.API.Models;

namespace HCM.UI.Interfaces.Account
{
    public interface IMstUser
    {
        Task<List<MstEmployee>> GetAllData();
        Task<MstEmployee> Login(MstEmployee oMstUser);
        Task<ApiResponseModel> GenerateOTP(MstEmployee oMstUser);
        Task<ApiResponseModel> AuthenticateOTP(PasswordReset oPasswordReset);
        Task<ApiResponseModel> ChangePassword(MstEmployee oMstUser);
        Task<bool> Logout();
        Task<ApiResponseModel> Insert(MstEmployee oMstUser);
        Task<ApiResponseModel> Update(MstEmployee oMstUser);
    }
}
