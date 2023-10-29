namespace Extrato.API.Models.DTO
{
    public enum LaunchStatus
    {
        Valid,
        Canceled
    }
    public class AddTransactionDTO
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool IsAdHoc { get; set; }
        public LaunchStatus Status { get; set; } = LaunchStatus.Valid;
    }
}
