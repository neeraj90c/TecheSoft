namespace TecheSoft.DTO.Auth
{
    public class UserLoginRequestDTO
    {
        public string? GroupCode { get; set; }
        public DateTime? DateToday { get; set; }
        public string? UserName { get; set;}
        public string? Password { get; set;}
    }
}
