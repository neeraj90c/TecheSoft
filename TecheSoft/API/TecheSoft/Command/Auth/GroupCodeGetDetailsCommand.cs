using MediatR;
using TecheSoft.DTO.Auth;
using TecheSoft.Interface.Auth;

namespace TecheSoft.Command.Auth
{
    public class GroupCodeGetDetailsCommand : IRequest<GroupMasterDTO>
    {
        public GroupMasterDetailRequestDTO reqDTO { get; set; }
    }
    internal class GroupCodeGetDetailsHandler : IRequestHandler<GroupCodeGetDetailsCommand, GroupMasterDTO>
    {
        protected readonly IGroupMaster _groupMaster;

        public GroupCodeGetDetailsHandler(IGroupMaster groupMaster)
        {
            _groupMaster = groupMaster;
        }
        public async Task<GroupMasterDTO> Handle(GroupCodeGetDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _groupMaster.GetGroupCodeDetails(request.reqDTO);
        }
    }
}
