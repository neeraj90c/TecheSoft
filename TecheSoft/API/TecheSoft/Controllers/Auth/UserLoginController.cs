using DTO;
using EncryptDecrypt.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TecheSoft.Command.Auth;
using TecheSoft.DTO.Auth;

namespace TecheSoft.Controllers.Auth
{
    public class UserLoginController : BaseApiController
    {
        APISettings _settings;
        protected readonly IEncryptDecrypt _encryptDecrypt;
        private ILogger<UserLoginController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserLoginController(IOptions<APISettings> settings, IEncryptDecrypt encryptDecrypt, IWebHostEnvironment webHostEnvironment, ILogger<UserLoginController> logger)
        {
            _logger = logger;
            _settings = settings.Value;
            _encryptDecrypt = encryptDecrypt;
            _webHostEnvironment = webHostEnvironment;

        }
        //[HttpGet("healthCheck")]
        //public async Task<IActionResult> HealthCheck()
        //{
        //    HealthCheckResponseDTO healthCheckResponseDTO = new HealthCheckResponseDTO();
        //    healthCheckResponseDTO.Key = "User Login API";
        //    healthCheckResponseDTO.Value = "Running Successfully!!";
        //    return Ok(healthCheckResponseDTO);
        //}
        [HttpPost("ValidateUserLogin")]
        public async Task<IActionResult> ValidateUserLogin([FromBody] UserLoginRequestDTO requestDTO)
        {
            //string usrname = EncryptDecrypt.Decrypt.deCrypt("ipt1CbNDLYg=", true,".");
            requestDTO.UserPWD = EncryptDecrypt.Encrypt.enCrypt(requestDTO.UserPWD, true,".");
            UserMasterDTO response = new UserMasterDTO();
            response = await mediator.Send(new UserLoginCommand
            {
                reqDTO = requestDTO
            });

            if (response == null)
                return Ok(APIResponse<string>.Unauthorized("Please check login credentials"));

            return Ok(response);
        }

    }
}
