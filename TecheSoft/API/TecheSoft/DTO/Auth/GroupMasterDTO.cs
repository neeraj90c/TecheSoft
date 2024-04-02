namespace TecheSoft.DTO.Auth
{
    public class GroupMasterDTO
    {
        public int BPId { get; set; }
        public int Uid { get; set; }
        public string? BPShortCode { get; set; }
        public string? ToknNum { get; set; }
        public string? BPCode { get; set; }
        public string? DBName { get; set; }
        public string? TradeName { get; set; }
        public int isWebAttendance { get; set; }
        public int isNewRegAllowed { get; set; }
        public DateTime? clDate { get; set; }
    }
}
