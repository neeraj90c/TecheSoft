using Dapper;
using DTO;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TecheSoft.DTO.Auth;
using TecheSoft.Interface.Auth;

namespace TecheSoft.Service.Auth
{
    public class GroupMasterService : DABase, IGroupMaster
    {
        private const string SP_spGetBPCode = "spGetBPCode";
        private ILogger<GroupMasterService> _logger;
        public GroupMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<GroupMasterService> logger) : base(connectionSettings.Value.ESoft)
        {
            _logger = logger;
        }
        public async Task<GroupMasterDTO> GetGroupCodeDetails(GroupMasterDetailRequestDTO groupMasterDetailRequestDTO)
        {

            GroupMasterDTO retObj = null;
            _logger.LogInformation($"Started Fetching Group Master Details by code {groupMasterDetailRequestDTO.BPCode} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<GroupMasterDTO>(SP_spGetBPCode, new
                {
                    GroupCode = groupMasterDetailRequestDTO.BPCode,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
