using DTO;
using EncryptDecrypt.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TecheSoft.Command.Auth;
using TecheSoft.DTO.Auth;

namespace TecheSoft.Controllers.Auth
{
    public class GroupMasterController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<GroupMasterController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GroupMasterController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<GroupMasterController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpGet("healthCheck")]
        public async Task<IActionResult> HealthCheck()
        {
            HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
            healthCheckResponseDTO.Key = "Group Master API";
            healthCheckResponseDTO.Value = "Running Successfully!!";
            return Ok(healthCheckResponseDTO);
        }
        [HttpPost("GetGroupCodeDetails")]
        public async Task<IActionResult> GetGroupCodeDetails([FromBody] GroupMasterDetailRequestDTO requestDTO)
        {

            GroupMasterDTO response = new GroupMasterDTO();
            response = await mediator.Send(new GroupCodeGetDetailsCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }
    }
}
