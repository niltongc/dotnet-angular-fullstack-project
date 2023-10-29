namespace Extrato.API.Models.Domain
{
    public enum TransactionStatus
    {
        Valid,
        Canceled
    }
    public class Extract
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public decimal Value { get; set; }
        public bool IsAdHoc { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Valid;
    }
}
