using TecheSoft.DTO.Auth;

namespace TecheSoft.Interface.Auth
{
    public interface IGroupMaster
    {
        Task<GroupMasterDTO> GetGroupCodeDetails(GroupMasterDetailRequestDTO groupMasterDetailRequestDTO );
    }
}
