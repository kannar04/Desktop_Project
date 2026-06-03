using System;

namespace DesktopApp_Project.DTO
{
    public class PaymentDebugResultDTO
    {
        public int TransactionId { get; set; }
        public int TuitionPaymentId { get; set; }
        public string ExternalTransactionRef { get; set; }
        public string StudentName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ClassName { get; set; }
        public string InvoiceCode { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentUrl { get; set; }
        public string PaymentStatus { get; set; }
        public string TuitionStatus { get; set; }
        public bool PaymentEmailSent { get; set; }
        public DateTime? PaymentEmailSentAt { get; set; }
        public string PaymentEmailError { get; set; }
        public bool StatusEmailSent { get; set; }
        public DateTime? StatusEmailSentAt { get; set; }
        public string StatusEmailError { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastStatusUpdateAt { get; set; }
        public string DebugNote { get; set; }
        public bool IsDebugPayment { get; set; }

        public bool PaymentUrlExists
        {
            get { return !string.IsNullOrWhiteSpace(PaymentUrl); }
        }
    }
}
