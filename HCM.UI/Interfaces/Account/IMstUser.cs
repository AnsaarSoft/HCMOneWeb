using HCM.API.Models;

namespace HCM.UI.Interfaces.Account
{
    public interface IMstUser
    {
        Task<List<MstUser>> GetAllData();
        Task<MstUser> Login(MstUser oMstUser);
        Task<ApiResponseModel> GenerateOTP(MstUser oMstUser);
        Task<ApiResponseModel> AuthenticateOTP(PasswordReset oPasswordReset);
        Task<ApiResponseModel> ChangePassword(MstUser oMstUser);
        Task<bool> Logout();
        Task<ApiResponseModel> Insert(MstUser oMstUser);
        Task<ApiResponseModel> Update(MstUser oMstUser);
    }
}
