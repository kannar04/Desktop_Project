namespace DesktopApp_Project.DTO
{
    public class BatchSendTuitionItemResultDTO
    {
        public int HocPhiId { get; set; }
        public string HocVienName { get; set; }
        public string Email { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
