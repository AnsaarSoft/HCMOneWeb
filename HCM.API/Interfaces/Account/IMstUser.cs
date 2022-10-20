using HCM.API.Models;

namespace HCM.API.Interfaces.Account
{
    public interface IMstUser
    {
        Task<List<MstEmployee>> GetAllData();
        Task<ApiResponseModel> Insert(MstEmployee oMstUser);
        Task<ApiResponseModel> Update(MstEmployee oMstUser);
        Task<MstEmployee> Login(MstEmployee oMstUser);
        Task<ApiResponseModel> GenerateOTP(MstEmployee oMstUser);
        Task<ApiResponseModel> AuthenticateOTP(PasswordReset oPasswordReset);
        Task<ApiResponseModel> ChangePassword(MstEmployee oMstUser);
    }
}
