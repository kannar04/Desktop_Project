namespace DesktopApp_Project.DTO
{
    public class PaymentDebugRequestDTO
    {
        public string StudentName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ClassName { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceCode { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentContent { get; set; }
        public string DebugNote { get; set; }
        public bool IsDebugPayment { get; set; }
    }
}
