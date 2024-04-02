using TecheSoft.DTO.Auth;

namespace TecheSoft.Interface.Auth
{
    public interface IUserLogin
    {
        Task<UserMasterDTO> ValidateLoginUser(UserLoginRequestDTO userLoginRequestDTO);
    }
}
