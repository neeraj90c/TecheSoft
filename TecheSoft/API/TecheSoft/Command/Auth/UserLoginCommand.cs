using MediatR;
using TecheSoft.DTO.Auth;
using TecheSoft.Interface.Auth;

namespace TecheSoft.Command.Auth
{
    public class UserLoginCommand : IRequest<UserMasterDTO>
    {
        public UserLoginRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginHandler : IRequestHandler<UserLoginCommand, UserMasterDTO>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task<UserMasterDTO> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _userLogin.ValidateLoginUser(request.reqDTO);
        }
    }
}
