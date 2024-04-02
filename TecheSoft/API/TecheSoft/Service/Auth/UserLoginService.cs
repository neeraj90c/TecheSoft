using DTO;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using TecheSoft.DTO.Auth;
using TecheSoft.Interface.Auth;
using Dapper;

namespace TecheSoft.Service.Auth
{
    public class UserLoginService : DABase, IUserLogin
    {
        private const string SP_spGetBPCode = "spGetBPCode";
        private ILogger<UserLoginService> _logger;
        public UserLoginService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserLoginService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<UserMasterDTO> ValidateLoginUser(UserLoginRequestDTO userLoginRequestDTO)
        {

            UserMasterDTO retObj = null;
            _logger.LogInformation($"Validating Logged In User");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<UserMasterDTO>(SP_spGetBPCode, new
                {
                    GroupCode = userLoginRequestDTO.GroupCode,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
